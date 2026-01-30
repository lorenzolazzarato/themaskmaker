using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "DataCliente", menuName = "Scriptable Objects/DataCliente")]
public class DataCliente : ScriptableObject
{
    public TMP_Text richiesta;
    public TMP_Text rispostaPositiva;
    public TMP_Text rispostaNeutra;
    public TMP_Text rispostaNegativa;
    
}
