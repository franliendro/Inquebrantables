using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum TypeMovement { Pie, Caballo, NPC };
    [SerializeField] private float speed=3.5f;
    [SerializeField] private Vector2 direction;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.velocity = direction*speed;
    }
    private void Update()
    {
        Movement();
        Animations();
        FlipPlayer();
        pasosSonido();
    }
    private void Movement()
    {
        
        direction=new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        
    }
    private void Animations()
    {

        animator.SetBool("caminando", false);
        if (direction.magnitude != 0)
        {
            
            animator.SetFloat("horizontal", direction.x);
            animator.SetFloat("vertical", direction.y);
            animator.SetBool("caminando",true);
        }
        
    }
    private void pasosSonido()
    {
        if (direction.magnitude != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
            
        }
        else
        {
            audioSource.Stop();
        }

    }
    private void FlipPlayer()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX = true;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = false;
        }
        
    }
}
