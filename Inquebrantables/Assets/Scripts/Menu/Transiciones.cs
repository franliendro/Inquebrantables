using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transiciones : MonoBehaviour
{
    private Animator transicionesAnim;
    // Start is called before the first frame update
    void Start()
    {
        transicionesAnim=GetComponent<Animator>();   
    }
    public void LoadScene(string scene)
    {
        StartCoroutine(Transiciona(scene));
    }
    IEnumerator Transiciona(string scene)
    {
        transicionesAnim.SetTrigger("salida");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
