using UnityEngine;
using Mirror;

public class ball : NetworkBehaviour
{

    public AudioClip ballhitSound;
    private Rigidbody rb;
    private RespawnBoxes[] boxes;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = isLocalPlayer;
        rb.AddForce(new Vector3(400, 0, Random.Range(50,100)));
        boxes = FindObjectsOfType<RespawnBoxes>();
    }

    [ServerCallback]
    void OnCollisionEnter(Collision collision)
    {
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
}
