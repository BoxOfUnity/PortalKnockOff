using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    Collider thisCollider;
    public int distanceToGoForward;



    // Start is called before the first frame update
    void Start()
    {
        thisCollider = this.gameObject.GetComponent<Collider>();
        Debug.Log("Testing: " + thisCollider);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("is indeed a trigger collider");
        GameObject portal = other.gameObject;
        if (portal.CompareTag("FirstPortal"))
        {
            Debug.Log("is indeed the first portal cube :D");
            Collider[] otherColliders = Physics.OverlapSphere(this.gameObject.transform.position, 100000f);
            foreach (Collider c in otherColliders)
            {
                if (c.CompareTag("SecondPortal"))
                {
                    Debug.Log("we found the other cube");
                    this.gameObject.transform.SetPositionAndRotation(c.gameObject.transform.position, c.gameObject.transform.rotation);
                    this.transform.position += this.transform.forward * distanceToGoForward;
                }
            }

        }
        else if (portal.CompareTag("SecondPortal"))
        {
            Debug.Log("is indeed the second portal");
            Collider[] otherColliders = Physics.OverlapSphere(this.gameObject.transform.position, 10000000f);
            Debug.Log("all colliders found: " + otherColliders.Length);
            foreach (Collider c in otherColliders)
            {
                if (c.CompareTag("FirstPortal"))
                {
                    Debug.Log("f o u n d the other portal");
                    this.gameObject.transform.SetPositionAndRotation(c.gameObject.transform.position, c.gameObject.transform.rotation);
                    this.transform.position += this.transform.forward * distanceToGoForward;
                    
                }
            }

        }
    }
   
    // Update is called once per frame
    void Update()
    {


    }
}
