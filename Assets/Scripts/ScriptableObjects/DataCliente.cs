using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DataCliente", menuName = "Scriptable Objects/DataCliente")]
public class DataCliente : ScriptableObject
{
    public int userID;
    public string displayName;
    public int woodID;
    public int faceID;
    public int runeID;
    public Sprite sprite;
}
