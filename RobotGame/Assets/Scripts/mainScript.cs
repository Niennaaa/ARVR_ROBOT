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
    public GameObject kyleHead;
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
    public GameObject welcomeCanva;
    public GameObject instructionsCanva;
    public GameObject textCanva;
    public GameObject secondLevelBookshelf;
    public GameObject debugsound;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        voice1.GetComponent<AudioSource>();
        voice2.GetComponent<AudioSource>();
        voice3.GetComponent<AudioSource>();
        voice4.GetComponent<AudioSource>();
        voice5.GetComponent<AudioSource>();
        bookshelf1.GetComponent<allBooksOk>();
        bookshelf2.GetComponent<allBooksOk>();
        anim = gameObject.GetComponent<Animator>();
        UnityEngine.XR.Interaction.Toolkit.XRSocketInteractor socket = this.GetComponentInChildren<UnityEngine.XR.Interaction.Toolkit.XRSocketInteractor>();
        kyleHead.GetComponent<lookForTheRightHat>();
        textCanva.GetComponent<TMPro.TextMeshProUGUI>();

        debugsound.GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {

        if (gameHasStarted == true) //the player clicked the start button
        {
            
            instructionsCanva.SetActive(true);
            
        }

        if ((level1)&&(gameHasStarted))
        {
            debugsound.GetComponent<AudioSource>().Play();
            firstLevel();
        }
        if (level2)
        {
            debugsound.GetComponent<AudioSource>().Play();
            textCanva.GetComponent<TMPro.TextMeshProUGUI>().text = "Human, arrange the bookshelf colorwise";
            secondLevel();
        }
        if (level3)
        {
            debugsound.GetComponent<AudioSource>().Play();
            textCanva.GetComponent<TMPro.TextMeshProUGUI>().text = "Human, take a sombrero from the hat chest and put it on my head";
            thirdLevel();
        }
        if (victory)
        {
            debugsound.GetComponent<AudioSource>().Play();
            textCanva.GetComponent<TMPro.TextMeshProUGUI>().text = "Human, you did good. Have this cake !";
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

    public void secondLevel() //book 1 & 2
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
            textCanva.GetComponent<TMPro.TextMeshProUGUI>().text = "Human, arrange the second bookshelf also colorwise";
            debugsound.GetComponent<AudioSource>().Play();
            secondLevelBookshelf.SetActive(true);
            if (!dialog3Said)
            {
                StartCoroutine(Talking(voice3));//launch audio + animation
                dialog3Said = true;
            }
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

    public void thirdLevel() //hat
    {
        if (!dialog4Said)
        {
            StartCoroutine(Talking(voice4));//launch audio + animation
            dialog4Said = true;
        }
        //launch talking animation
        //lauch audio
        //lauch UI explaining the level
        //at the end of audio, stop talking animation
        if (kyleHead.GetComponent<lookForTheRightHat>().levelDone)
        {
            victory = true;
            level3 = false;
        }


    }

    public void Ending()
    {
        if (!dialog5Said)
        {
            StartCoroutine(Talking(voice5));//launch audio + animation
            dialog5Said = true;
        }
        //launch talking animation
        //lauch audio
        //lauch UI explaining the level
        //at the end of audio, stop talking animation
        cake.SetActive(true);
    }

    public void startGame()
    {
        gameHasStarted = true;
    }

    IEnumerator Talking(AudioSource audio)
    {
        audio.Play();
        anim.SetBool("isTalking",true);
        yield return new WaitForSeconds(audio.clip.length);
        anim.SetBool("isTalking", false);
        
    }
}
