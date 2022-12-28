using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            //other.SendMessage("Die");

            var player = other.GetComponent<PlayerController>();
            if (player != null) 
            {
                player.Die();
            }
            
        }

        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
    
}
