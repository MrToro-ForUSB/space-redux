using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> players;

    void Awake()
    {
        Spawn();
    }

    public void Spawn()
    {
        int playerIndex = Random.Range(0, players.Count);
        Factory.Create(players[playerIndex]);
    }
}
