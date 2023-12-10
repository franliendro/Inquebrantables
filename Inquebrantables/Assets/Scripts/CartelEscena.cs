using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartelEscena : MonoBehaviour
{
    [SerializeField] private GameObject cartel;
    [SerializeField] private GameObject ingleses;
    [SerializeField] private GameObject atacar;
    [SerializeField] private GameObject guemes;
    [SerializeField] private GameObject infernales;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    public void Despausar()
    {
        atacar.SetActive(true);
        ingleses.SetActive(true);
        guemes.SetActive(true);
        cartel.SetActive(false);
        infernales.SetActive(true);
    }
    public void Ir(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
