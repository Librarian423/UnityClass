using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 8f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        var v = Input.GetAxis("Vertical");//-1.0 ~ 1.0
        var h = Input.GetAxis("Horizontal");//-1.0 ~ 1.0

        //rb.AddForce(new Vector3(h, 0f, v) * speed);
        rb.velocity = new Vector3(h, 0f, v) * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        var findGO = GameObject.FindWithTag("GameController");
        findGO.SendMessage("EndGame");
    }
}
