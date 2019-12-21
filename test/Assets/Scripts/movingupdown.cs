using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingupdown : MonoBehaviour
{
    public float speed = -0.05f, changeDirection = -1, max = 10;

    Vector3 Move, Mid;

    public PauseUI pausep;

    // Use this for initialization
    void Start()
    {
        Mid = this.transform.position;
        Move = this.transform.position;

        pausep = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PauseUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pausep.pause)
        {
            this.transform.position = this.transform.position;

        }
        if (pausep.pause == false)
        {
            if (Move.y < Mid.y + max && Move.y > Mid.y - max)
            {
                Move.y += speed;
            }
            if (Move.y > Mid.y + max || Move.y < Mid.y - max)
            {
                speed *= changeDirection;
                Move.y += speed;
               
            }

            this.transform.position = Move;
        }



    }
}
