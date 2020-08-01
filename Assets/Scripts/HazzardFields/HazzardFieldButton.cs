using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardFieldButton : Activatable
{
    public GameObject HazzardFieldSide1;
    public GameObject HazzardFieldSide2;
    public bool startActive;
    public override void Activate()
    {
        if (startActive)
        {
            HazzardFieldSide1.SetActive(false);
            HazzardFieldSide2.SetActive(false);
            AudioSource[] audio = GetComponentsInChildren<AudioSource>();
            foreach (AudioSource source in audio)
            {
                if (source.clip.name == "HazzardFieldActivate")
                {
                    source.Stop();
                }
            }
        }
        else
        {
            HazzardFieldSide1.SetActive(true);
            HazzardFieldSide2.SetActive(true);
            AudioSource[] audio = GetComponentsInChildren<AudioSource>();
            foreach (AudioSource source in audio)
            {
                if (source.clip.name == "HazzardFieldActivate")
                {
                    source.Play();
                }
            }
        }
    }
    public override void DeActivate()
    {
        if (!startActive)
        {
            HazzardFieldSide1.SetActive(false);
            HazzardFieldSide2.SetActive(false);
            AudioSource[] audio = GetComponentsInChildren<AudioSource>();
            foreach (AudioSource source in audio)
            {
                if (source.clip.name == "HazzardFieldActivate")
                {
                    source.Stop();
                }
            }
        }
        else
        {
            HazzardFieldSide1.SetActive(true);
            HazzardFieldSide2.SetActive(true);
            AudioSource[] audio = GetComponentsInChildren<AudioSource>();
            foreach (AudioSource source in audio)
            {
                if (source.clip.name == "HazzardFieldActivate")
                {
                    source.Play();
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (startActive)
        {
            HazzardFieldSide1.SetActive(true);
            HazzardFieldSide2.SetActive(true);
            AudioSource[] audio = GetComponentsInChildren<AudioSource>();
            foreach (AudioSource source in audio)
            {
                if (source.clip.name == "HazzardFieldActivate")
                {
                    source.Play();
                }
            }
            
        }
        else
        {
            HazzardFieldSide1.SetActive(false);
            HazzardFieldSide2.SetActive(false);
            AudioSource[] audio = GetComponentsInChildren<AudioSource>();
            foreach (AudioSource source in audio)
            {
                if (source.clip.name == "HazzardFieldActivate")
                {
                    source.Stop();
                }
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
