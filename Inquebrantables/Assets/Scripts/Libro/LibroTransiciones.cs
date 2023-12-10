using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibroTransiciones : MonoBehaviour
{
    [SerializeField] private GameObject primerLibro;
    [SerializeField] private GameObject primerFondo;
    [SerializeField] private GameObject segundoFondo;
    [SerializeField] private GameObject segundoLibro;
    [SerializeField] private GameObject audioNarrando;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiarSiguiente()
    {
        primerLibro.SetActive(false);
        primerFondo.SetActive(false);
        segundoLibro.SetActive(true);
        segundoFondo.SetActive(true); 
        audioNarrando.SetActive(true);
    }
}
