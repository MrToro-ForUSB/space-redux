using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] backgrounds;

    void Start()
    {
        int randomBackground = Random.Range(0, backgrounds.Length);
        Instantiate(backgrounds[randomBackground], transform);
    }
}
