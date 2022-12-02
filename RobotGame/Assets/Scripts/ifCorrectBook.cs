using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ifCorrectBook : MonoBehaviour
{
    public string lookingForThisTag;
    public Material lightMaterial;
    public Material fadeMaterial;
    //static bool aBookIsOn = false; //this is dealt with the event part in the socket in unity
    public bool correctTag = false;
    public Collider theBook;
    private bool addedAOneYet = false;

    

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.XR.Interaction.Toolkit.XRSocketInteractor socket = this.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRSocketInteractor>();
    }
    [SerializeField]
    public bool m_aBookIsOn = false;
    public bool aBookIsOn
    {
        get => m_aBookIsOn;
        set => m_aBookIsOn = value;
    }

    // Update is called once per frame
    void Update()
    {
        correctBook();
    }

    private void OnTriggerEnter(Collider other) //if this is the right book, the color get lighter
    {
        theBook = other;
        if (other.gameObject.tag == lookingForThisTag)
        {
            this.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRSocketInteractor>().interactableHoverMeshMaterial = lightMaterial;
            correctTag = true;
        }
        else
        {
            this.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRSocketInteractor>().interactableHoverMeshMaterial = fadeMaterial;
            correctTag = false;
        }
    }

    private void correctBook()
    {

        if((correctTag)&&(aBookIsOn)&&(!addedAOneYet))
        {
            this.GetComponent<allBooksOk>().AllBooksAreGood += 1;
            addedAOneYet = true;
            Debug.Log("1ere sortie");
        }
        if ((correctTag) && (m_aBookIsOn) && (!addedAOneYet))
        {
            this.GetComponent<allBooksOk>().AllBooksAreGood += 1;
            addedAOneYet = true;
            Debug.Log("1ere sortie");
        }
        if ((addedAOneYet)&& (!correctTag) && (!m_aBookIsOn)) //this happen only if the book is removed
        {
            this.GetComponent<allBooksOk>().AllBooksAreGood -= 1;
            addedAOneYet = false;
        }
    }



}
