using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightButton : Activatable
{
    public override void Activate()
    {
        Light lights = this.GetComponent<Light>();
        lights.enabled = false;
    }
    public override void DeActivate()
    {
        Light lights = this.GetComponent<Light>();
        lights.enabled = true;
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
