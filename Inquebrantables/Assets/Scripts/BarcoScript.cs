using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarcoScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject MostrarCartel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MostrarCartel.SetActive(true);
        }
        
        
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene("Batalla");
                Debug.Log("Si aprieta la E");
            }
        }
        
        
    }
    
}
