using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootLaser : MonoBehaviour
{
    public GameObject muzzle;
    public GameObject beamPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.Space))
        {
            //Vector3 pos = new Vector3(muzzle.transform.position.x, muzzle.transform.position.y - 0.12f,
                //muzzle.transform.position.z);

                Instantiate(beamPrefab, transform.localPosition,Quaternion.Euler(transform.forward));

            //Destroy(beamPrefab, 30f);
        }

    }
}
