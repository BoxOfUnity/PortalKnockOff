using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFunnleScript : MonoBehaviour
{
    private bool gravCheckExit;
    public float textureSpeed = 3f;
    private Renderer textureRenderer = new Renderer();
    public float moveSpeedUp = .5f;
    public float moveSpeedIn = .5f;
    private List<Collider> collidersInField = new List<Collider>();
    // Start is called before the first frame update
    void Start()
    {
        textureRenderer = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.attachedRigidbody.isKinematic)
        {
            bool gravCheck = other.GetComponent<Rigidbody>().useGravity;
            if (gravCheck)
            {
                other.attachedRigidbody.useGravity = false;
                gravCheckExit = true;
            }
            collidersInField.Add(other);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gravCheckExit)
        {
            other.attachedRigidbody.useGravity = true;
        }
        collidersInField.Remove(other);
    }

    // Update is called once per frame
    void Update()
    {
        float offSet = Time.deltaTime * textureSpeed;
        textureRenderer.material.SetTextureOffset("_MainTex", new Vector2(offSet, offSet));
        foreach (Collider other in collidersInField)
        {
            other.transform.Translate(transform.up.normalized * moveSpeedUp * Time.deltaTime);

            Vector3 perpendicular = Vector3.Cross(this.transform.up, other.transform.position - this.transform.position);
            
            other.transform.Translate(perpendicular.normalized * Time.deltaTime * -moveSpeedIn*perpendicular.magnitude);


        }
    }
}
