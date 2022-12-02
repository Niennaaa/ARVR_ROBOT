using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allBooksOk : MonoBehaviour
{
    public int AllBooksAreGood;
    // Start is called before the first frame update
    void Start()
    {
        AllBooksAreGood = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (AllBooksAreGood == 5)
        {
            //next scene begin
            Debug.Log("all books are in order for this shelf");
        }
    }
}
