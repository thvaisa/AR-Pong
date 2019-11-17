using UnityEngine;
using Mirror;
using System.Collections;


public class Ball : NetworkBehaviour
{

    public AudioClip ballhitSound;
    private Rigidbody rb;
    private RespawnBoxes[] boxes;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = isClient;
        if (isServer)
            rb.AddForce(new Vector3(400, 0, Random.Range(50,100)));
        boxes = FindObjectsOfType<RespawnBoxes>();
    }
 


    [ServerCallback]
    void OnTriggerEnter(Collider collision)
    {
        if (isClient)
            return;

        GetComponent<AudioSource>().PlayOneShot(ballhitSound);
        if (collision.gameObject.name == "zone")
        {
            StartCoroutine(respawn());
        }
    }

    IEnumerator respawn()
    {
        yield return new WaitForSeconds(1);
        rb.position = new Vector3(11, 0, 2);
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(Random.Range(400, 600), 0, Random.Range(150, 250)));

    }
     /*
     [ServerCallback]
    void OnCollisionEnter(Collision collision)
    {
        if (isClient)
            return;
        GetComponent<AudioSource>().PlayOneShot(ballhitSound);

        if (collision.gameObject.name == "zone")
        {
            rb.position = new Vector3(11,0,2);
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(400, 0, Random.Range(50, 100)));
            Debug.Log(boxes.Length);
            for(int i=0;i<boxes.Length;++i)
            {
                boxes[i].Reset();
            }
        }
     }
     */
}
