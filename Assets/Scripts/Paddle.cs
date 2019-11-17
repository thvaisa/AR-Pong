using UnityEngine;
using Mirror;


public class Paddle : NetworkBehaviour
{
    public AudioClip hit;
    [SyncVar]
    float speed = 0;
    float deceleration = 0.5f;
    float maxSpeed = 20;
    private int screenWidth;

    void Start() {
        screenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        float dT = Time.deltaTime;
        Vector3 position = this.transform.position;

 
        if(position.z > -6 && speed < 0)
        {
            position.z += speed* dT;
            this.transform.position = position;
         

        }

        if (position.z < 5 && speed > 0) {
            position.z += speed * dT;
            this.transform.position = position;
 
        }

        speed = speed * deceleration;


        if (!isLocalPlayer)
            return;

        float touches = 0;
        foreach (Touch touch in Input.touches) {
            float xpos = touch.position.x;
            if (xpos < screenWidth / 2) {
                touches++;
            } else {
                touches--;
            }
        }
        if (touches != 0) {
            speed = Mathf.Sign(touches) * maxSpeed;
        }

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
        //GetComponent<AudioSource>().PlayOneShot(hit);
        //print(collision.gameObject.name);
        //Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        //rb.AddForce(Vector3.left * 500); ;

    }

}