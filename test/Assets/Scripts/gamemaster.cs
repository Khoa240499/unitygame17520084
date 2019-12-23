using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemaster : MonoBehaviour
{
    public int points = 0;

    public Text pointtext;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pointtext.text = ("Points: " + points);
    }
}