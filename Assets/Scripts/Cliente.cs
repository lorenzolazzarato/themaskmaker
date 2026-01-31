using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cliente : MonoBehaviour
{
    public DataCliente cliente;
    public int indexCliente = 0;
    private int maxIndexCliente;
    [SerializeField] public SpriteRenderer spriteCliente;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*setCliente(indexCliente);
        maxIndexCliente = cliente.Count;
        //levelText.text = cliente[indexCliente].richiesta;
        spriteCliente.sprite = cliente[indexCliente].sprite;*/
    }

    private void setCliente(int index)
    {
        
    }
    public String getShortReq()
    {
        //return cliente[indexCliente].shortRequest;
    }

    public String getDescr()
    {
        //return cliente[indexCliente].richiesta;
    }
}
