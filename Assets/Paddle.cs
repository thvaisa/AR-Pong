using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paddle : MonoBehaviour
{
    public AudioClip hit;
    float speed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 position = this.transform.position;

        if(position.z > -2 && speed < 0)
        {
            position.z += speed;
            this.transform.position = position;
         

        }

        if (position.z < 10 && speed > 0) {
            position.z += speed;
            this.transform.position = position;
        }


 
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = 0.3f;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = -0.3f;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().PlayOneShot(hit);
        //print(collision.gameObject.name);
        //Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        //rb.AddForce(Vector3.left * 500); ;

    }

}