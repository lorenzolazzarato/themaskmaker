using System;
using UnityEngine;

public class Cliente : MonoBehaviour
{
    public DataCliente cliente;
    
    private String richiesta; 
    private String shortRequest;
    private String rispostaPositiva;
    private String rispostaNeutra;
    private String rispostaNegativa;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        richiesta = cliente.richiesta;
        shortRequest = cliente.shortRequest;
        rispostaPositiva = cliente.rispostaPositiva;
        rispostaNeutra = cliente.rispostaNeutra;
        rispostaNegativa = cliente.rispostaNegativa;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
