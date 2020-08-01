using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropperButton : Activatable
{
    public List<GameObject> objectToDrop = new List<GameObject>();
    public bool multipleOrRandom;
    //what numbers cant be used
    public override void Activate()
    {
        if (multipleOrRandom == true)
        {
            foreach (GameObject thisObject in objectToDrop)
            {
                GameObject objectBeingDropped = Instantiate(thisObject);
                objectBeingDropped.transform.position = this.transform.position + this.transform.up * -.1f;
                
            }
        }
        else
        {
            GameObject objectBeingDropped = Instantiate(objectToDrop[Random.Range(1, objectToDrop.Count())]);
            objectBeingDropped.transform.position = this.transform.position + this.transform.up * -.1f;

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
