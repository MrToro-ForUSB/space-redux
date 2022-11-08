using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class Explosion : Entity
{
    [SerializeField] float timeoutToDestroy = 1;

    void Start()
    {
        DestroyEntity();
    }

    protected override void DeleteEntity(object[] args)
    {
        DestroyEntity();
    }

    protected override void DestroyEntity()
    {
        Destroy(gameObject, timeoutToDestroy);
    }
}