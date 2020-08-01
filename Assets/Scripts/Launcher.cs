using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    
    public GameObject projectile;
    public float maxSpeed;
    public float chargeRate = 100f;
    private bool charging = false;
    private float currentSpeedCharged = 0f;

    private void FireProjectile()
    {
        GameObject objectToFire = GameObject.Instantiate(projectile);
        objectToFire.transform.position = this.gameObject.transform.position + this.gameObject.transform.forward;
        objectToFire.transform.rotation = this.transform.rotation;
        Vector3 v3 = this.gameObject.transform.forward.normalized * currentSpeedCharged;
        objectToFire.GetComponent<Rigidbody>().AddForce(v3);
        Debug.Log("your vectory stuff: " + v3);
        Debug.Log("your current speed charge: " + currentSpeedCharged);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello?");

    }

    // Update is called once per frame
    void Update()
    {
        
      
        if (Input.GetButtonDown("Fire"))
        {
            Debug.Log("is charging");
            charging = true;
            
        }
        if(Input.GetButtonUp("Fire"))
        {
            Debug.Log("nope, no more charge. much fire");
            charging = false;
            FireProjectile();
            currentSpeedCharged = 0f;

        }
        if (charging)
        {
            currentSpeedCharged += chargeRate * Time.deltaTime;
            Debug.Log("much charge: " + currentSpeedCharged);
        }
    }
}
