using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldingDoorButton : Activatable
{
    private Vector3 v3;
    public override void Activate()
    {
        this.transform.RotateAround(v3, this.transform.position + this.transform.forward * -5, -90f);
    }
    public override void DeActivate()
    {
        this.transform.RotateAround(v3, this.transform.position + this.transform.forward * -5f, 90f);
    }
    // Start is called before the first frame update
    void Start()
    {
        v3 = this.transform.position;// + this.transform.right * -2f;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
