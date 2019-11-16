using UnityEngine;

public class CustomTrackableEventHandler : DefaultTrackableEventHandler {

    protected override void Start() {
        base.Start();
        foreach (Rigidbody body in transform.GetComponentsInChildren<Rigidbody>()) {
            body.isKinematic = true;
        }
    }

    protected override void OnTrackingFound() {
        base.OnTrackingFound();
        foreach (Rigidbody body in transform.GetComponentsInChildren<Rigidbody>()) {
            body.isKinematic = false;
        }
    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();
        foreach (Rigidbody body in transform.GetComponentsInChildren<Rigidbody>()) {
            body.isKinematic = true;
        }
    }
}