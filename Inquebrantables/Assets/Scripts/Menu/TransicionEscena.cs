using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscena : MonoBehaviour
{
    private Animator animator;
    
    [SerializeField] private AnimationClip animacionFinal;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void TransicionSalida(string scene)
    {
        StartCoroutine(Transiciona(scene));
    }
    IEnumerator Transiciona(string scene)
    {
        animator.SetTrigger("salida");
        yield return new WaitForSeconds(animacionFinal.length);
        SceneManager.LoadScene(scene);
    }
}
