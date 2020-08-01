using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fizzler : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FizzlerDestroyable>())
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            Destroy(other.gameObject);
            
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
