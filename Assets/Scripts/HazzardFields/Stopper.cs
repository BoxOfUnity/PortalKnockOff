using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopper : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Stoppable>())
        {
            other.attachedRigidbody.isKinematic = true;
            other.attachedRigidbody.isKinematic = false;
            other.attachedRigidbody.MovePosition(other.gameObject.transform.position + this.transform.forward * .8f);
            //other.transform.rotation = this.transform.rotation;
            //other.transform.position += other.transform.forward * 1f;
            //other.attachedRigidbody.isKinematic = false;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
