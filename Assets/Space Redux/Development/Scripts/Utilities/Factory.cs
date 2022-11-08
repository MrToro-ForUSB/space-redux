using System;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public static GameObject Create(GameObject gameObject)
    {
        return Instantiate(gameObject);
    }

    public static GameObject Create(GameObject gameObject, Transform location)
    {
        return Instantiate(gameObject, location.position, location.rotation);
    }

    public static GameObject Create(GameObject gameObject, Vector3 position)
    {
        return Instantiate(gameObject, position, Quaternion.identity);
    }

    public static GameObject Create(GameObject gameObject, Vector3 position, Transform parent)
    {
        GameObject gameObjectInstance = Instantiate(gameObject, position, Quaternion.identity);
        gameObjectInstance.transform.SetParent(parent);
        return gameObjectInstance;
    }
}