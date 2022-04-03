using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    public float pushForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb != null)
        {
            Vector3 dir = hit.gameObject.transform.position - transform.position;
            dir.y = 0;
            dir.Normalize();

            rb.AddForceAtPosition(dir * pushForce, transform.position, ForceMode.Impulse);
        }
    }
}
