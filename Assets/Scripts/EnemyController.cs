using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator animator;
    public float speed;
    Rigidbody2D rigidBody2d;
    public bool vertical;
    // Timer to handle object move Back and Fourth
    public float moveTimeInterval = 3.0f;
    public float timer;
    public int direction = 1;
    public bool isBroken = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        timer = moveTimeInterval;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        if (!isBroken){
            return;
        }
        Vector2 position = rigidBody2d.position;
        timer = timer - Time.deltaTime;
        // if timer < 0 then reverse move direction
        if (timer < 0){
            direction =  - direction;
            timer = moveTimeInterval;
        }
    }
    void FixedUpdate()
    {
        if (!isBroken){
            return;
        }
        Vector2 pos = rigidBody2d.position;
        if (vertical){
            pos.y = pos.y + Time.deltaTime * speed * direction;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
        }
        else {
            pos.x = pos.x + Time.deltaTime * speed * direction;
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
        }

        rigidBody2d.MovePosition(pos);
    }

    void OnCollisionEnter2D(Collision2D other){
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null){
            player.UpdateHealth(-1);
            // player.animator.SetTrigger("Hit");
            // Debug.Log("NOT NULL");
        }  
        // Debug.Log("NULLLL");
    }

    public void Fix(){
        isBroken = false;
        rigidBody2d.simulated = false;
        animator.SetTrigger("Fixed");
    }
}
