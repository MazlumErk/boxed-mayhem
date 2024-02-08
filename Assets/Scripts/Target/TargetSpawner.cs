using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public static TargetSpawner Instance;
    [SerializeField] private GameObject areaSideA, areaSideB, target;
    [SerializeField] private ParticleSystem targetSpawnParticleSystem, targetTrackParticleSystem;
    [SerializeField] private int areaSideBFirstPosition = 8;


    private void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SetNewPosition();
        }
    }

    public void SetNewPosition()
    {
        TargetSpawnParticle();
        StartCoroutine(TargetTrackParticle());
        SetSpawnAreaSize();
        int randomX = Mathf.RoundToInt(Random.Range(areaSideA.transform.position.x, areaSideB.transform.position.x));
        int randomY = Mathf.RoundToInt(Random.Range(areaSideA.transform.position.y, areaSideB.transform.position.y));
        int randomZ = Mathf.RoundToInt(Random.Range(areaSideA.transform.position.z, areaSideB.transform.position.z));
        target.transform.position = new Vector3(randomX, randomY, randomZ);
    }

    private void TargetSpawnParticle()
    {
        targetSpawnParticleSystem.Play();
    }

    private IEnumerator TargetTrackParticle()
    {
        targetTrackParticleSystem.Play();
        yield return new WaitForSeconds(0.4f);
        targetTrackParticleSystem.gameObject.transform.position = target.transform.position;
    }

    private void SetSpawnAreaSize()
    {
        int newAreaSideBZ = PlayerManager.Instance.GetPlayer().score / 5;
        areaSideB.transform.position = new Vector3(areaSideB.transform.position.x, areaSideB.transform.position.y, areaSideBFirstPosition - newAreaSideBZ);
    }
}
