using UnityEngine;

[CreateAssetMenu(fileName = "Mask Face", menuName = "Scriptable Objects/Mask/Face")]
public class MaskFaceType : ScriptableObject
{
    public int id;
    public string displayName;
    public Sprite sprite;
}
