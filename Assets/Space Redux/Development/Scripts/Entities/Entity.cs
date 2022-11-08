using System.Collections.Generic;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected abstract void DeleteEntity(params object[] args);
    protected abstract void DestroyEntity();
}