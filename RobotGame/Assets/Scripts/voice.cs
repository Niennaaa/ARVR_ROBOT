using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voice : MonoBehaviour
{
    public AudioSource source;
    public bool on;
    // Start is called before the first frame update
    void Start()
    {
        source.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            source.Play();
        }
    }
}
