using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour
{
    public bool gameHasStarted = false;
    public bool level1 = true; //the stains
    public bool level2 = false;//the bookshelves
    public bool level3 = false;//hat level
    public bool victory = false; //cake

    private GameObject stain;
    public GameObject bookshelf1;
    public GameObject bookshelf2;
    public GameObject desiredHat;
    public GameObject cake;

    public AudioSource voice1;
    public AudioSource voice2;
    public AudioSource voice3;
    public AudioSource voice4;
    public AudioSource voice5;
    private bool dialog1Said = false;
    private bool dialog2Said = false;
    private bool dialog3Said = false;
    private bool dialog4Said = false;
    private bool dialog5Said = false;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        voice1.GetComponent<AudioSource>();
        voice2.GetComponent<AudioSource>();
        voice3.GetComponent<AudioSource>();
        voice4.GetComponent<AudioSource>();
        voice5.GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
        Debug.Log(anim);
    }

    // Update is called once per frame
    void Update()
    {

        if ((level1)&&(gameHasStarted))
        {
            firstLevel();
        }
        if (level2)
        {
            secondLevel();
        }
        if (level3)
        {
            thirdLevel();
        }
        if (victory)
        {
            Ending();
        }

    }

    public void firstLevel()
    {
        //launch UI
        if (!dialog1Said)
        {
            StartCoroutine(Talking(voice1));//launch audio + animation
            dialog1Said = true;
        }

        stain = GameObject.FindWithTag("Stain");
        if (stain == null) //when all the stains are found, level2 begins and level1 ends
        {
            level2 = true;
            level1 = false;
        }
        
    }

    public void secondLevel()
    {
        if (!dialog2Said)
        {
            StartCoroutine(Talking(voice2));//launch audio + animation
            dialog2Said = true;
        }
        //launch talking animation
        //lauch audio
        //lauch UI explaining the level
        //at the end of audio, stop talking animation

        if (bookshelf1.GetComponent<allBooksOk>().levelDone)
        {
            voice3.Play();
            //launch second talking animation
            //lauch second audio
            //at the end of audio, stop talking animation

            if (bookshelf2.GetComponent<allBooksOk>().levelDone)
            {
                level3 = true;
                level2 = false;
            }
        }
    }

    public void thirdLevel()
    {
        voice4.Play();
        //launch talking animation
        //lauch audio
        //lauch UI explaining the level
        //at the end of audio, stop talking animation

        

    }

    public void Ending()
    {
        voice5.Play();
        //launch talking animation
        //lauch audio
        //lauch UI explaining the level
        //at the end of audio, stop talking animation
        cake.SetActive(true);
    }

    IEnumerator Talking(AudioSource audio)
    {
        audio.Play();
        while (audio.isPlaying)
        {
            Debug.Log(audio.isPlaying);
            anim.SetBool("isTalking",true);
        }
        anim.SetBool("isTalking", false);
        yield return null;
    }
}
