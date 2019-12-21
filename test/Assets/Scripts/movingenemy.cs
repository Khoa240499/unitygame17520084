using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingenemy : MonoBehaviour
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
            if (Move.x < Mid.x + max && Move.x > Mid.x - max)
            {
                Move.x += speed;
            }
            if (Move.x > Mid.x + max || Move.x < Mid.x - max)
            {
                speed *= changeDirection;
                Move.x += speed;
                Flip();
            }
            
            this.transform.position = Move;
        }



    }
        public void Flip()
        {
            Vector3 Scale;
            Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
       
}
