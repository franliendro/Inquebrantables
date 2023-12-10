using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasaste : MonoBehaviour
{
    private int b = 0;
    [SerializeField] private GameObject cartelVictoria;
    [SerializeField] private GameObject guemes;
    [SerializeField] private GameObject gauchos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogoCerca.cantidad ==4&&b==0)
        {
            StartCoroutine(MostrarCartel());
            b = 1;
        }
    }
    IEnumerator MostrarCartel()
    {
        yield return new WaitForSeconds(3);
        final();
    }
    private void final()
    {
        cartelVictoria.SetActive(true);
        guemes.SetActive(false);
        gauchos.SetActive(false);
    }
}
