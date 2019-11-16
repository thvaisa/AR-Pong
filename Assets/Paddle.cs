using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paddle : MonoBehaviour
{
    public AudioClip hit;
    float speed = 0;
    float deceleration = 0.5f;
    float maxSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dT = Time.deltaTime;
        Vector3 position = this.transform.position;

        if(position.z > -2 && speed < 0)
        {
            position.z += speed* dT;
            this.transform.position = position;
         

        }

        if (position.z < 10 && speed > 0) {
            position.z += speed * dT;
            this.transform.position = position;
        }

        speed = speed * deceleration;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed = maxSpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed = -maxSpeed;
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