using UnityEngine;

public class NetworkedPaddle : MonoBehaviour
{
    void Start() {
        Debug.Log("Spawn");
    }

    void Update() {
       if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space)) {
           transform.Translate(0.5f, 0, 0);
       } 

       if (transform.position.x > 5) {
           transform.position = Vector3.zero;
       }
    }
}
