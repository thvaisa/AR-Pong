using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

    public AudioClip ballhitSound;
    private Rigidbody rb;
    private RespawnBoxes[] boxes;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.AddForce(transform.forward * 600);
        rb.AddForce(new Vector3(400, 0, Random.Range(50,100)));
        boxes = FindObjectsOfType<RespawnBoxes>();
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    void OnTriggerEnter(Collider collision)
    {
        GetComponent<AudioSource>().PlayOneShot(ballhitSound);

        if (collision.gameObject.name == "zone")
        {
            StartCoroutine(respawn());

            //boxes[0].Reset();
            //boxes[1].Reset();
        }
        //print(collision.gameObject.name);
        //Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        //rb.AddForce(Vector3.left * 500); ;

    }

    IEnumerator respawn()
    {   
        yield return new WaitForSeconds(1);
        rb.position = new Vector3(11, 0, 2);
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(Random.Range(400,600), 0, Random.Range(150, 250)));
         

    }
}
