using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidBody2d;
    // Start is called before the first frame update
    void Awake()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(Vector2 direction, float force){
        rigidBody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other){
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e!= null){
            e.Fix();
        }
        Debug.Log("Projectile collided with " + other.gameObject);
        Destroy(gameObject);
    }
}
