using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private int itemsOnButton = 0;
    public List<GameObject> objectsToBeActivated = new List<GameObject>();
    private List<Activatable> activation = new List<Activatable>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject objectToBeActivated in objectsToBeActivated)
        {
            activation.Add(objectToBeActivated.GetComponent<Activatable>());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        itemsOnButton++;
        Debug.Log("eyyyy it collided");
        if (itemsOnButton == 1)
        {
            this.transform.localPosition += this.transform.up.normalized * -.1f;
            collision.collider.gameObject.transform.position += this.transform.up.normalized * -.1f;
            foreach (Activatable activate in activation)
            {
                activate.Activate();
            }
            
        }
        Debug.Log("Items on button: " + itemsOnButton);

    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("something left the button");
        itemsOnButton--;
        if (itemsOnButton == 0)
        {
            Debug.Log("o it uncollided");
            this.transform.localPosition += this.transform.up.normalized * .1f;
            foreach (Activatable activate in activation)
            {
                activate.DeActivate();
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
