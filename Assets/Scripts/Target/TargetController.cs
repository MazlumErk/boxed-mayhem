using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public static TargetController Instance;
    [SerializeField] private Transform player;

    private void Awake()
    {
        Instance = this;
    }

    private void Update() {
        TargetLookToPlayer();
    }

    public void TargetLookToPlayer()
    {
        Quaternion lookRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
