using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerPuerta : MonoBehaviour
{
    [SerializeField] private GameObject puerta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogoCerca.cantidad>0)
        {
            puerta.SetActive(true);
        }
    }
}
