using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private enum NPC { Ingles, Realista };
    [SerializeField] private GameObject thisPlayer;
    [SerializeField] private float vel;
    [SerializeField] private NPC npc;
    [SerializeField] private GameObject PlayerM;
    public float vida = 10f;
    public static int cantEnemigos = 0;
    private Animator animator;
    private Rigidbody2D rb;
    Vector2 EnemyPos;
    void Start()
    {
        animator = GetComponent<Animator>();
        cantEnemigos++;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 velocidad = rb.velocity;
        if (velocidad.x > 0)
        {
            Debug.Log("El personaje se está moviendo hacia la derecha.");
        }
        else if (velocidad.x < 0)
        {
            Debug.Log("El personaje se está moviendo hacia la izquierda.");
        }
        if (PlayerM)
        {
            EnemyPos = PlayerM.transform.position;
        }
        if (vida>0)
        {
            if (npc == NPC.Ingles)
            {
                if (Vector2.Distance(transform.position, EnemyPos) > 1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, EnemyPos, vel * Time.deltaTime);
                }
                else
                {
                    animator.Play("Golpe");
                }
            }
            if (npc == NPC.Realista)
            {
                if (Vector2.Distance(transform.position, EnemyPos) > 6f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, EnemyPos, vel * Time.deltaTime);
                }
                else
                {
                    animator.Play("Golpe");
                }
            }
           

            // Verificar la dirección en X
            
            animations();
        }
        if (vida<=0)
        {
            animator.Play("Death");
            StartCoroutine(Muerte());
        }
    }
    void animations()
    {
        if (npc == NPC.Ingles)
        {
            if (Vector2.Distance(transform.position, EnemyPos) > 1f)
            {
                animator.SetBool("caminando", true);
            }
            else
            {
                animator.SetBool("caminando", false);
            }
        }
        
        if (npc == NPC.Realista)
        {
            if (Vector2.Distance(transform.position, EnemyPos) > 6f)
            {
                animator.SetBool("caminando", true);
            }
            else
            {
                animator.SetBool("caminando", false);
            }
        }
    }
    public void RecibirGolpe(float dmg)
    {
        vida -= dmg;
    }
    void Desaparecer()
    {

        
        Destroy(thisPlayer);
    }
    IEnumerator Muerte()
    {
        
        yield return new WaitForSeconds(3);
        Desaparecer();
        
    }
    private void OnDestroy()
    {
        cantEnemigos--;
    }
}
