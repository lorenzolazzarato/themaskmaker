using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DataCliente", menuName = "Scriptable Objects/DataCliente")]
public class DataCliente : ScriptableObject
{
    public int userID;
    public String userName;
    public int woodID;
    public int faceID;
    public int runeID;
    
    public String richiesta;
    public String shortRequest;
    public String rispostaPositiva;
    public String rispostaNeutra;
    public String rispostaNegativa;
    
    public Sprite sprite;
}
