using UnityEngine;
using UnityEngine.InputSystem.Utilities;

[CreateAssetMenu]
public class Resource : ScriptableObject
{
    public string resourceName;
    public string description;
    public Sprite image;
    public float processDuration;
}
