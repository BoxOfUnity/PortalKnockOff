using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravable : MonoBehaviour
{
    public bool gravApplied = true;
    private int twiceCount = 1;
    public void GravSwitch()
    {
        Debug.Log("da count of two before floaty flotations " +twiceCount);
        Debug.Log("YoU WEnt THRouGh tHE AnTIGrAvFieLD?! how do i know? cause you got to this function: GravSwitch");
        Debug.Log("you speak " + gravApplied + "ly?");
        if (gravApplied)
        {
            if (twiceCount == 2)
            {
                Debug.Log("Gravity is applied on this Gam-ubjec!!!!1!!");
                gravApplied = false;
                this.GetComponent<Rigidbody>().useGravity = false;
                twiceCount = 0;
            }
            twiceCount++;
        }
        else
        {
            if (twiceCount == 2)
            {
                Debug.Log("grav not aplie to mr this thing");
                gravApplied = true;
                this.GetComponent<Rigidbody>().useGravity = true;
                twiceCount = 0;
            }
            twiceCount++;
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
