using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static TargetManager Instance;
    private Target target;
    void Start()
    {

    }

    public Target GetTarget()
    {
        return target;
    }
}
