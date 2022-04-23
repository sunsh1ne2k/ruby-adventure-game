using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        RubyController controller = other.GetComponent<RubyController>();

        // Debug.Log("Object that entered the trigger " + other);

        if (controller != null){
            if (controller.health < controller.maxHealth){
            controller.UpdateHealth(1);
            Destroy(gameObject);
            }
        }
    }
}
