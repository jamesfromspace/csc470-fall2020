using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;


public class Raycast : MonoBehaviour {

    public int gunDamage = 1;                                           
    public float fireRate = 0.25f;                                     
    public float weaponRange = 50f;                                    
    public float hitForce = 100f;                                      
    public Transform gunEnd;                                           
    public TextMeshProUGUI scoreText;

    private int count;
    private Camera fpsCam;                                               
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private LineRenderer laserLine;       
    private AudioSource gunAudio;		                                
    private float nextFire;                                               

    void Start () 
    {
        count = 0;
        SetScoreText();
        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInParent<Camera>();
        gunAudio = GetComponent<AudioSource>();
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + count.ToString();
    }
    
    void Update () 
    {




        // Check if player has fired weapon
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire) 
        {
            
            StartCoroutine (ShotEffect());
               
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
                    count = count + 1;
                    SetScoreText();
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
        if (count >= 5)
        {
            SceneManager.LoadScene("Winner");
        }
    }
    
   

   	private IEnumerator ShotEffect()
    {
        // Turn on our line renderer
        laserLine.enabled = true;

        gunAudio.Play ();

        //Wait for .07 seconds
        yield return shotDuration;

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
    }
}