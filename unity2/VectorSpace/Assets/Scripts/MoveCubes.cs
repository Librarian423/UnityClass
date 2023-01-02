using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubes : MonoBehaviour
{
    private GameObject targetObj;
    private Transform target;
    public float rotationSpeed = 2f;
    public float moveSpeed = 20f;

    private Rigidbody rb;

    public Transform Target
    {
        get { return target; }
        set
        {
            target = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        SpinCube();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null && GameObject.FindWithTag("Target") != null)
        {
            target = GameObject.FindWithTag("Target").transform;
        }
        if (target != null)
        {
            var direction = (target.position - transform.position).normalized;


            rb.velocity = direction * moveSpeed;

            //target = targetObj.GetComponent<Transform>();
            Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);

            rb.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

            //SpinCube();
        }
        
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Destroy(other.gameObject);
            //var shpere = other.GetComponent<Sphere>();

            //if (shpere != null)
            //{
            //    shpere.Erase();
            //    target = null;
            //}
        }
    }

    private void SpinCube()
    {
        target = targetObj.GetComponent<Transform>();
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);

        rb.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }
}
