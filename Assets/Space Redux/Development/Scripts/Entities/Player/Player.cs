using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Player : Entity, IMovable, IDamagable, IShootable
{
    [TitleGroup("Stats")]
    [SerializeField] int helmetPoints = 10;


    [TitleGroup("Movement")]
    [SerializeField] float speedMult = 8;
    [SerializeField, ReadOnly] Vector3 targetDirection;

    [TitleGroup("Shoot")]
    [SerializeField, PreviewField] GameObject shot;
    [SerializeField] int fireRate = 2;
    public bool canShoot = true;

    [TitleGroup("Collision")]
    [SerializeField] GameObject explosionCollision;
    [SerializeField] float explosionScale = 1f;


    void Start()
    {
        targetDirection = transform.position;
    }

    void Update()
    {
        Move();
        TryShoot();
    }


    public void Move()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            targetDirection = Camera.main.ScreenToWorldPoint(touch.position);
            targetDirection.z = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetDirection, Time.deltaTime * speedMult);
    }
    public void TryShoot()
    {
        if (Input.touchCount > 0 && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }
    public IEnumerator Shoot()
    {
        canShoot = false;
        Factory.Create(shot, transform.position);

        yield return new WaitForSeconds(1.0f / fireRate);
        canShoot = true;
    }

    public void Damage(int damage, int criticalHitRange)
    {
        damage *= (Random.Range(0, 100) < criticalHitRange) ? 2 : 1;
        helmetPoints -= damage;

        if (helmetPoints <= 0)
        {
            DeleteEntity();
        }
    }

    protected override void DeleteEntity(object[] args)
    {
        GameObject explosion = Factory.Create(explosionCollision, transform.position);
        explosion.transform.localScale *= explosionScale;

        Asyncs.Wait(() => SceneManager.LoadScene(1), 1.5f);
        DestroyEntity();
    }

    protected override void DestroyEntity()
    {
        Destroy(gameObject);
    }
}
