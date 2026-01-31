using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cliente : MonoBehaviour
{
    public List<DataCliente> cliente;
    public int indexCliente = 0;
    private int maxIndexCliente;
    [SerializeField] public SpriteRenderer spriteCliente;
    
    [SerializeField] TMP_Text levelText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxIndexCliente = cliente.Count;
        levelText.text = cliente[indexCliente].richiesta;
        spriteCliente.sprite = cliente[indexCliente].sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
