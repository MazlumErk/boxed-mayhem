using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [SerializeField] private AudioSource shootingSound;
    [SerializeField, Range(0.1f, 9f)] private float sensitivity = 2f;
    [SerializeField, Range(0f, 90f)] private float xRotationLimit = 88f;
    [SerializeField] private Transform target;

    private Vector2 rotation = Vector3.zero;
    private const string xAxis = "Mouse X";
    private const string yAxis = "Mouse Y";

    private void Awake()
    {
        Instance = this;
    }

    public void SetMouseSensitivity(float newMouseSensitivity)
    {
        sensitivity = newMouseSensitivity;
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
        }

        if (LevelManager.Instance.GetLevel().gameStatus == GameStatus.Finished)
        {
            ShowTargetToPlayer();
        }
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

    public void ShowTargetToPlayer()
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3f);
    }
}