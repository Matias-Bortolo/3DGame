using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody ownBody;
    public Transform charCam;
    public Animator anim;
    public GameObject sword;

    public CharacterController charControl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 logicMove = new Vector3(horizontal, 0, vertical).normalized;
        anim.SetFloat("Movement", logicMove.magnitude);

        if(logicMove.magnitude >= 0.1f)
        {
            float angle = Mathf.Atan2(logicMove.x, logicMove.z) * Mathf.Rad2Deg + charCam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0, angle, 0) * Vector3.forward;
            charControl.Move(moveDir * moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown("q"))
        {
            sword.GetComponent<Collider>().enabled = true;
            anim.Play("SwordAttack");
        }
        else
            sword.GetComponent<Collider>().enabled = false;
        
    }
}
