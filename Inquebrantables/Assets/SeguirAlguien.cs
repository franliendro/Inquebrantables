using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirAlguien : MonoBehaviour
{
    private enum NPC { Infernal, SanMartin };
    [SerializeField] private NPC npc;
    Vector2 EnemyPos;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject PlayerM;
    [SerializeField] private int vel;
    [SerializeField] private bool reclutado=false;

    void Start()
    {

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (PlayerM)
        {
            EnemyPos = PlayerM.transform.position;
        }
        if (reclutado)
        {
            if (npc == NPC.Infernal)
            {
                if (Vector2.Distance(transform.position, EnemyPos) > 2f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, EnemyPos, vel * Time.deltaTime);
                }
            }
            animations();
        }
        
    }

    void animations()
    {

        if (npc == NPC.Infernal)
        {
            if (Vector2.Distance(transform.position, EnemyPos) > 2f)
            {
                animator.SetBool("caminando", true);
            }
            else
            {
                animator.SetBool("caminando", false);
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                reclutado = true;
            }
        }
    }
}
