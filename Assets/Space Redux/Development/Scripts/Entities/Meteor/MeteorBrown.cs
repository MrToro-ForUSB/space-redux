using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class MeteorBrown : Meteor, IDamagable
{
    [TitleGroup("Stats")]
    [SerializeField] int helmetPoints = 1;

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
        ScoreManager.AddScore(scorePoints);
        base.DeleteEntity();
    }
}
