using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogoCerca : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject panelTexto;
    [SerializeField] private TMP_Text escrituraTexto;
    [SerializeField] private Rigidbody2D rigidbody2;
    [SerializeField, TextArea(4, 6)] private string[] escrituraCant;
    [SerializeField] private AudioSource[] Audios;
    [SerializeField] private GameObject aprietaE;
    private int b = 0;
    public static int cantidad=0;
    private bool isPlayerInRange;
    private bool didDialogueStart=false;
    private int escrituraIndex;
    private int audiosIndex;
    
    
    private void Update()
    {
        if (escrituraIndex < escrituraCant.Length && escrituraTexto.text == escrituraCant[escrituraIndex])
        {
            aprietaE.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.E)&& isPlayerInRange)
        {
            
            if (!didDialogueStart&&b==0)
            {
                IniciarEscritura();
                b = 1;
                rigidbody2.constraints= RigidbodyConstraints2D.FreezePosition;
            }
            else if (escrituraIndex < escrituraCant.Length && escrituraTexto.text == escrituraCant[escrituraIndex]) //aca hay error
            {
                aprietaE.SetActive(false);
                NextDialogueLine();
            }
            else
            {
                if (escrituraIndex < escrituraCant.Length)
                {
                    Audios[audiosIndex].Stop();
                    StopAllCoroutines();
                    escrituraTexto.text = escrituraCant[escrituraIndex];
                    aprietaE.SetActive(true);
                }
            }

        }
        
    }
    private void IniciarEscritura()
    {
        didDialogueStart = true;
        panelTexto.SetActive(true);
        dialogueMark.SetActive(false);
        escrituraIndex = 0;
        audiosIndex = 0;
        Audios[audiosIndex].Play();
        StartCoroutine(MostrarLinea());
    }
    private void NextDialogueLine() //en este modulo teoricamente
    {
        audiosIndex++;
        escrituraIndex++;
        if (escrituraIndex< escrituraCant.Length)
        {
            Audios[audiosIndex].Play(); 
            StartCoroutine(MostrarLinea()); //INDEX
        }
        else
        {
            panelTexto.SetActive(false);
            didDialogueStart = false;
            rigidbody2.constraints = RigidbodyConstraints2D.None;
            rigidbody2.constraints = RigidbodyConstraints2D.FreezeRotation;
            cantidad++;
        }
    }
    private IEnumerator MostrarLinea() //sera aca?
    {
        escrituraTexto.text = string.Empty;
        foreach (char ch in escrituraCant[escrituraIndex]) //INDEX
        {
            escrituraTexto.text += ch;
            yield return new WaitForSeconds(0.05f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&b==0)
        {
            dialogueMark.SetActive(true);
            isPlayerInRange = true;
        }
        
    }
}

