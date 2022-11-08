using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Meteor : Entity, IMovable, IRotable
{
    // ———————————— fields ————————————
    [TitleGroup("Dependencies")]
    [SerializeField, ReadOnly] Rigidbody2D rigidbody;


    [TitleGroup("Movement")]
    [SerializeField] Vector2 direction;
    [SerializeField] float speedMult = 10;
    [SerializeField] float rotateMult = 10;


    [TitleGroup("Damage")]
    [SerializeField] protected int damageByCollision = 1;
    [SerializeField] protected int criticalHitRange = 30;
    [SerializeField] protected GameObject explosionCollision;
    [SerializeField] protected float explosionScale = 1f;


    [TitleGroup("Score")]
    [SerializeField] protected int scorePoints;


    // ———————————— unity methods ————————————
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Move();
        Rotate();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Limit"))
        {
            DestroyEntity();
        }

        if (col.CompareTag("Entity"))
        {
            if (col.TryGetComponent(out Player player))
            {
                player.Damage(damageByCollision, criticalHitRange);

                DeleteEntity();
            }
        }
    }

    // ———————————— meteor methods ————————————
    public void Move()
    {
        rigidbody.velocity = direction * speedMult;
    }

    public void Rotate()
    {
        rigidbody.angularVelocity = rotateMult;
    }

    protected override void DeleteEntity(object[] args)
    {
        GameObject explosion = Factory.Create(explosionCollision, transform.position);
        explosion.transform.localScale *= explosionScale;

        DestroyEntity();
    }

    protected override void DestroyEntity()
    {
        Destroy(gameObject);
    }
}
