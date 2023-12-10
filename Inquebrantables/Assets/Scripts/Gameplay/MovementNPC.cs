using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNPC : MonoBehaviour
{
    private enum NPC { Infernal,  SanMartin};
    [SerializeField] private NPC npc;
    Vector2 EnemyPos;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject PlayerM;
    [SerializeField] private int vel;
    
    
    void Start()
    {
        
        animator=GetComponent<Animator>();
    }

    void Update()
    {
        if (PlayerM)
        {
            EnemyPos = PlayerM.transform.position;
        } 
        if (npc == NPC.Infernal)
        {
            if (Vector2.Distance(transform.position, EnemyPos) > 2f)
            {
                transform.position = Vector2.MoveTowards(transform.position, EnemyPos, vel * Time.deltaTime);
            }
            else
            {
                animator.Play("Attack");
            }
        }
        animations();
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
}
