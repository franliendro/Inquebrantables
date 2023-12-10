using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerVictoria : MonoBehaviour
{
    [SerializeField] private GameObject Aparecer;
    [SerializeField] private GameObject Guemes;
    [SerializeField] private GameObject Atacar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemigo.cantEnemigos==1)
        {
            Aparecer.SetActive(true);
            Guemes.SetActive(false);
            Atacar.SetActive(false);
        }
    }
}
