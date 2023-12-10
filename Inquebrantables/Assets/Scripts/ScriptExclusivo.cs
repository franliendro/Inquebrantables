using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptExclusivo : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private string sala;
    [SerializeField] private AnimationClip animacionFinal;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            StartCoroutine(Transiciona(sala));
        }
    }
    IEnumerator Transiciona(string scene)
    {
        animator.SetTrigger("salida");
        yield return new WaitForSeconds(animacionFinal.length);
        SceneManager.LoadScene(scene);
    }
}
