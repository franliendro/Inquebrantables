using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private AudioSource attackSound;
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dmgGolpe = 2f;
    [SerializeField] private float tiempoEspera=1f;
    [SerializeField] private float tiempoRestante;
    private Rigidbody2D rigidBody;
    private Animator animator;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempoRestante-= Time.deltaTime;
        
            if (Input.GetMouseButtonDown(0))
            {
                if (tiempoRestante <= 0)
                {
                    Golpe();
                    Debug.Log("Golpe");
                    tiempoRestante = tiempoEspera;
                    StartCoroutine(golpeEspera());
                }
                
            }

    }
    IEnumerator golpeEspera()
    {
        rigidBody.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(1); 
        

    }
    private void Golpe()
    {
        if (rigidBody.velocity.x == 0 && rigidBody.velocity.y == 0)
        {
            animator.SetTrigger("Golpe");
            attackSound.Play();
        }
        else
        {
            animator.SetTrigger("GolpeCorriendo");
        }
            
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);
        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigo"))
            {
                colisionador.transform.GetComponent<Enemigo>().RecibirGolpe(dmgGolpe);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position,radioGolpe);
    }
}
