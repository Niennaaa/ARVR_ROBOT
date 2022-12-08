using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour
{
    public bool level1 = true; //the stains
    public bool level2 = false;//the bookshelves
    public bool level3 = false;//hat level
    public bool victory = false; //cake

    private GameObject stain;
    public GameObject bookshelf1;
    public GameObject bookshelf2;
    public GameObject desiredHat;
    public GameObject cake;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (level1)
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
        //launch talking animation
        //lauch audio
        //lauch UI explaining the level
        //at the end of audio, stop talking animation

        stain = GameObject.FindWithTag("Stain");
        if (stain == null) //when all the stains are found, level2 begins and level1 ends
        {
            level2 = true;
            level1 = false;
        }
        
    }

    public void secondLevel()
    {
        //launch talking animation
        //lauch audio
        //lauch UI explaining the level
        //at the end of audio, stop talking animation

        if (bookshelf1.GetComponent<allBooksOk>().levelDone)
        {
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
        //launch talking animation
        //lauch audio
        //lauch UI explaining the level
        //at the end of audio, stop talking animation

        

    }

    public void Ending()
    {
        //launch talking animation
        //lauch audio
        //lauch UI explaining the level
        //at the end of audio, stop talking animation
        cake.SetActive(true);
    }
}
