using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Shot : Entity, IMovable
{
    [TitleGroup("Dependencies")]
    [SerializeField, ReadOnly] Rigidbody2D rigidbody;


    [TitleGroup("Movement")]
    [SerializeField] Vector2 direction;
    [SerializeField] float speedMult = 10;


    [TitleGroup("Damage")]
    [SerializeField] int damageByCollision = 1;
    [SerializeField] int criticalHitRange = 30;
    [SerializeField, PreviewField] GameObject explosionCollision;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Limit"))
        {
            DestroyEntity();
        }

        if (col.CompareTag("Entity"))
        {
            if (col.TryGetComponent(out IDamagable entity))
            {
                entity.Damage(damageByCollision, criticalHitRange);
            }

            DeleteEntity(col);
        }
    }

    public void Move()
    {
        rigidbody.velocity = direction * speedMult;
    }

    protected override void DeleteEntity(object[] args)
    {
        Collider2D col = args[0] as Collider2D;
        Vector3 collisionPoint = col.ClosestPoint(transform.position);
        Factory.Create(explosionCollision, collisionPoint, col.transform);

        DestroyEntity();
    }

    protected override void DestroyEntity()
    {
        Destroy(gameObject);
    }
}
