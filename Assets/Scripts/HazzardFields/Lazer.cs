using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LazerDestroyable>())
        {
            if (other.GetComponentInChildren<CameraControl>())
            {
                Destroy(other.gameObject.GetComponentInChildren<CameraControl>());
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
