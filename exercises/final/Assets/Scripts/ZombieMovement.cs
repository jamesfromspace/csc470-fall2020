using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{

    public float forwardSpeed = 1.0f;
   // public float rotationSpeed = 1.0f;

   // public float Speed 4.0f;
    public Transform Player;
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, Player.position, forwardSpeed * Time.deltaTime);
        rigid.MovePosition(pos);
        transform.LookAt(Player);

    }

    
}
