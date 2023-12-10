using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource m_Source;
    // Start is called before the first frame update
    void Start()
    {
        m_Source = GetComponent<AudioSource>();
        StartCoroutine(iniciarSonido());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator iniciarSonido()
    {
        yield return new WaitForSeconds(1);
        m_Source.Play();
    }
}
