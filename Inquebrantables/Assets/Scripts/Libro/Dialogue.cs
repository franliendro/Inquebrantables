using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject siguientePagina;
    [SerializeField] private GameObject jugarNivel;
    [SerializeField] private GameObject panelTexto;
    [SerializeField] private GameObject botonAdelantar;
    
    [SerializeField] private GameObject boceto;
    [SerializeField] private TMP_Text escrituraTexto;
    [SerializeField,TextArea(4,6)] private string[] escrituraCant;
    private int escrituraIndex;
    [SerializeField] AudioSource sonidoNarrador;
    public void Comenzar()
    {
        StartCoroutine(Narrar());
    }
    private void Update()
    {
        if (escrituraTexto.text == escrituraCant[escrituraIndex])
        {
            escrituraTexto.text = escrituraCant[escrituraIndex];
            boceto.SetActive(true);
            StopAllCoroutines();
            botonAdelantar.SetActive(false);
            jugarNivel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            escrituraTexto.text = escrituraCant[escrituraIndex];
            sonidoNarrador.Stop();
            boceto.SetActive(true);
            StopAllCoroutines();
            botonAdelantar.SetActive(false);
        }
    }
    private IEnumerator Narrar()
    {
        yield return new WaitForSeconds(1);
        IniciarEscritura();
    }
    private void IniciarEscritura()
    {
            siguientePagina.SetActive(false);
            botonAdelantar.SetActive(true);
            panelTexto.SetActive(true);
            escrituraIndex = 0;
            StartCoroutine(MostrarLinea()); 
    }
    private IEnumerator MostrarLinea()
    {
        escrituraTexto.text = string.Empty;
        foreach (char ch in escrituraCant[escrituraIndex])
        {
            escrituraTexto.text += ch;
            yield return new WaitForSeconds(0.05f);
        }
    }
    
}
