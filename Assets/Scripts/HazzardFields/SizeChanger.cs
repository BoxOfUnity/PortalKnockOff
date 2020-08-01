using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    public bool grow;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ReSizable>())
        {
            if (grow)
            {
                other.transform.localScale *= 1.2f;
            }
            else
            {
                other.transform.localScale *= -1.2f;
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
