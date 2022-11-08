using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGray : Meteor
{
    protected override void DeleteEntity(object[] args)
    {
        ScoreManager.RemoveScore(scorePoints);
        base.DeleteEntity();
    }
}
