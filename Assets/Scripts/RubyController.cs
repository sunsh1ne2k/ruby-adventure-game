using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public int maxHealth = 5;
    public float speed = 3.0f;
    public int health {get {return currentHealth;}}
    int currentHealth;
    Rigidbody2D rigidBody2d;
    float horizontal;
    float vertical;

    // Check that Ruby is being immortal or not - To handle damagable whenever she stay in a damageable object
    public float timeImmortal = 1.5f;
    bool isImmortal = false;
    float immortalTimer;
    // Start is called before the first frame update
    void Start()
    {
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 60;
        rigidBody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // sync immortalTimer with framerate
        if (isImmortal){
            immortalTimer -= Time.deltaTime;
            // if immortal time of Ruby ended, reset it to false value
            if (immortalTimer < 0)
                isImmortal = false;
        }
    }

    void FixedUpdate(){
               
        Vector2 position = rigidBody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
       
        rigidBody2d.MovePosition(position);
    }

    public void UpdateHealth(int amount){
        if (amount < 0){
            if (isImmortal)
                return;
            isImmortal = true;
            immortalTimer = timeImmortal;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
