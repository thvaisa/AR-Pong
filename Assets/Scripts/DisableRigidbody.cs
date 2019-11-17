using UnityEngine;
using Mirror;

[RequireComponent(typeof(Rigidbody))]
public class DisableRigidbody : NetworkBehaviour {
    private void Start() {
        GetComponent<Rigidbody>().isKinematic = isClient;
    }
}
