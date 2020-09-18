using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    GameObject muzzle;
    Vector3 direction;
    GameObject gReference;

  
    // Start is called before the first frame update
    void Start()
    {
        gReference = GameObject.FindGameObjectWithTag("Plane");
        muzzle = GameObject.Find("muzzle");
        direction = muzzle.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0f, 0f, 1f * Time.deltaTime);
        Rigidbody rboby = GetComponent<Rigidbody>();
        rboby.velocity = direction * 40f;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("stormtrooper"))
        {
            
            Destroy(other.gameObject);

            GameManager.score += 1;
        }
    }
}