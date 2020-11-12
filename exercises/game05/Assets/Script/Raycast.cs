using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

    public int gunDamage = 1;                                           
    public float fireRate = 0.25f;                                     
    public float weaponRange = 50f;                                    
    public float hitForce = 100f;                                      
    public Transform gunEnd;                                           

    private Camera fpsCam;                                               
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private LineRenderer laserLine;                                       
    private float nextFire;                                               

    void Start () 
    {
        
        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInParent<Camera>();
    }


    void Update () 
    {
        // Check if player has fired weapon
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire) 
        {
            
            nextFire = Time.time + fireRate;

            
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));

            
            RaycastHit hit;

            
            laserLine.SetPosition (0, gunEnd.position);

            // Check if raycast has hit anything
            if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
               
                laserLine.SetPosition (1, hit.point);
                
                Target health = hit.collider.GetComponent<Target>();
                
                if (health != null)
                {
                    health.Damage (gunDamage);
                }

                
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce (-hit.normal * hitForce);
                }
            }
            else
            {
                laserLine.SetPosition (1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }
}