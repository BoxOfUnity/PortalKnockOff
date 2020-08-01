using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : Activatable
{
    public List<GameObject> doors = new List<GameObject>();
    public override void Activate()
    {
        Debug.Log("activated");
        foreach (GameObject gameObject in doors)
        {
            gameObject.transform.position += gameObject.transform.right * 3;
        }

    }
    public override void DeActivate()
    {
        Debug.Log("deactivated");
        foreach (GameObject gameObject in doors)
        {
            gameObject.transform.position += gameObject.transform.right * -3;

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
