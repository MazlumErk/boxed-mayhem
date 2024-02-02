using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public static TargetSpawner Instance;
    [SerializeField] private GameObject areaSideA, areaSideB, target;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SetNewPosition();
        }
    }

    public void SetNewPosition()
    {
        int randomX = Mathf.RoundToInt(Random.Range(areaSideA.transform.position.x, areaSideB.transform.position.x));
        int randomY = Mathf.RoundToInt(Random.Range(areaSideA.transform.position.y, areaSideB.transform.position.y));
        int randomZ = Mathf.RoundToInt(Random.Range(areaSideA.transform.position.z, areaSideB.transform.position.z));
        target.transform.position = new Vector3(randomX, randomY, randomZ);

        // Debug.Log($"X:{randomX} - Y:{randomY} - Z:{randomZ}");
    }
}
