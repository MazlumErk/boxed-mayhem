using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource shootingSound;
    [SerializeField, Range(0.1f, 9f)] private float sensitivity = 2f;
    [SerializeField, Range(0f, 90f)] private float xRotationLimit = 88f;

    private Vector2 rotation = Vector3.zero;
    private const string xAxis = "Mouse X";
    private const string yAxis = "Mouse Y";

    private void Start()
    {
        // LockAndHideCursor();
    }

    private void Update()
    {
        if (LevelManager.Instance.GetLevel().gameStatus == GameStatus.Started)
        {
            HandleRotationInput();
            ClampVerticalRotation();
            UpdateCameraRotation();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Fire();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                LevelManager.Instance.SetLevel(GameStatus.Pause);
            }
        }
    }

    private void LockAndHideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void HandleRotationInput()
    {
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
    }

    private void ClampVerticalRotation()
    {
        rotation.y = Mathf.Clamp(rotation.y, -xRotationLimit, xRotationLimit);
    }

    private void UpdateCameraRotation()
    {
        Quaternion xQuaternion = Quaternion.AngleAxis(rotation.x, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = xQuaternion * yQuaternion;
    }

    private void Fire()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject.tag == "target")
            {
                TargetSpawner.Instance.SetNewPosition();
                PlayerManager.Instance.SetPlayer(newScore: PlayerManager.Instance.GetPlayer().score + 1);
                CanvasManager.Instance.ResetCount();
                CanvasManager.Instance.UiTextUpdate();
                shootingSound.Play();
            }
        }
    }
}