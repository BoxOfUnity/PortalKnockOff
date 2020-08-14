using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public bool overrideMovableCheck = false;
    public GameObject player;
    public float maxInteractDistance = 1.5f;
    private Camera playerCamera;
    private GameObject heldObject;
    private Vector3 heldObjectStartPosition;
    public float pickupSpeed = .1f;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = player.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Interact"))
        {
            if (!heldObject)
            {
                RaycastHit hit;
                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
                {
                    if (hit.distance <= maxInteractDistance)
                    {
                        if (hit.collider.gameObject.GetComponent<Pickupable>())
                        {
                            Debug.Log("PICKEDEDUP A THINGY LIKE CUBE THING I GUESS");
                            heldObject = hit.collider.gameObject;
                            heldObject.transform.parent = player.transform;
                            //heldObjectStartPosition = heldObject.transform.position;
                        }
                        else if (overrideMovableCheck)
                        {
                            Debug.Log("PICKEDEDUP A THINGY LIKE CUBE THING I GUESS");

                            heldObject = hit.collider.gameObject;
                            Destroy(heldObject.GetComponent<Collider>());
                            heldObject.transform.parent = player.transform;
                            //heldObjectStartPosition = heldObject.transform.position;
                        }
                    }
                }
            }
        }
        if (heldObject)
        {
            if (heldObject.GetComponent<Rigidbody>())
            {
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
            }
            heldObject.transform.position = Vector3.Lerp(heldObject.transform.position, playerCamera.transform.position + playerCamera.transform.forward * 1.5f, Time.deltaTime / pickupSpeed);
            heldObject.transform.rotation = Quaternion.Lerp(heldObject.transform.rotation, playerCamera.transform.rotation, Time.deltaTime / pickupSpeed);
        }
        if (Input.GetButtonUp("Interact")&&heldObject != null)
        {
            if (overrideMovableCheck)
            {
                heldObject.AddComponent<BoxCollider>();
            }
            heldObject.transform.parent = null;
            if (heldObject.GetComponent<Rigidbody>())
            {
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
            }
            heldObject = null;
                
        }

    }
}
