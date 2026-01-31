using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cliente : MonoBehaviour
{
    public List<DataCliente> cliente;
    public int indexCliente = 0;
    private int maxIndexCliente;
    
    [SerializeField] TMP_Text levelText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxIndexCliente = cliente.Count;
        levelText.text = cliente[indexCliente].richiesta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
