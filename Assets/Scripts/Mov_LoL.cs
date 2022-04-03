using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mov_LoL : MonoBehaviour
{
    public float dashSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovementLogic();
    }

    void MovementLogic()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool isHit = Physics.Raycast(ray, out hit);
            if (isHit)
            {
                GetComponent<NavMeshAgent>().destination = hit.point;
                GetComponent<NavMeshAgent>().isStopped = false;
            }
        }

        if (Input.GetKeyDown("x"))
        {
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * dashSpeed, ForceMode.Impulse);
            GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.layer == 7)
    //    {
    //        Instantiate(this);
    //    }
    //}
}
