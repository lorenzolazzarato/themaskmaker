using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DataCliente", menuName = "Scriptable Objects/DataCliente")]
public class DataCliente : ScriptableObject
{
    public String richiesta;
    public String shortRequest;
    public String rispostaPositiva;
    public String rispostaNeutra;
    public String rispostaNegativa;
    public Sprite sprite;
}
