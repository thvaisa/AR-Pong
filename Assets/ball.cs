using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.AddForce(transform.forward * 600);
        rb.AddForce(new Vector3(200, 0, 600));
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "zone")
        {
            rb.position = new Vector3(11,0,2);
          // rb.AddForce(new Vector3(Random.Range(100, 100), 0, Random.Range(100, 100)));

        }
        //print(collision.gameObject.name);
        //Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        //rb.AddForce(Vector3.left * 500); ;

    }
}
