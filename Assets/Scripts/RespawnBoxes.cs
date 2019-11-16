using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBoxes : MonoBehaviour
{
    private Vector3[] positions;
    private Quaternion[] rotations;
    private Rigidbody[] rBodies;

    // Start is called before the first frame update
    void Start()
    {
        positions = new Vector3[transform.childCount];
        rotations = new Quaternion[transform.childCount];
        rBodies = new Rigidbody[transform.childCount];
        int indx = 0;
        foreach (Transform cTransform in transform.GetComponentInChildren<Transform>())
        {
            positions[indx] = cTransform.position;
            rotations[indx] = cTransform.rotation;
            rBodies[indx] = cTransform.GetComponent<Rigidbody>();
            indx++;
        }
    }

    public void Reset()
    {
        int indx = 0;
        foreach (Rigidbody rBody in rBodies)
        {
            Transform cTransform = rBody.transform; 
            cTransform.position = positions[indx];
            cTransform.rotation = rotations[indx];
            rBody.velocity = Vector3.zero;
            rBody.angularVelocity = Vector3.zero;
            indx++;
        }
    }


}
