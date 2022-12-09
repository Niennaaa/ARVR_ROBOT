using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookForTheRightHat : MonoBehaviour
{

    private GameObject hat;
    public GameObject desiredHat;
    public bool correctHat = false ;
    public bool levelDone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField]
    public bool m_aHatIsOn = false;
    public bool aHatIsOn
    {
        get => m_aHatIsOn;
        set => m_aHatIsOn = value;
    }
    // Update is called once per frame
    void Update()
    {
        if (aHatIsOn)
        {
            Debug.Log("a hat is on");
        }
        if ((aHatIsOn) && (correctHat))
        {
            levelDone = true;
        }
    }

    private void OnTriggerEnter(Collider other) //if this is the right book, the color get lighter
    {
        hat = other.gameObject;
        if (hat.tag == "correctHat")
        {
            Debug.Log("good hat");
            correctHat = true;
        }
        else
        {
            correctHat = false;
        }
    }
}
