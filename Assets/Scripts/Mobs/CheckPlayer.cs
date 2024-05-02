using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CheckPlayer
{
    [field: SerializeField] public Color color { private set; get; }
    [field: SerializeField] public float radius { private set; get; }
    [SerializeField] private LayerMask layerMask;

    public bool Check(Transform transform)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layerMask);
        return colliders.Length > 0;
    }

}
