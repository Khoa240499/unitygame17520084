using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplat : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.05f, changeDirection = -1,max = 10;
    Vector3 Move,Mid;

    public PauseUI pausep;

    // Use this for initialization
    void Start()
    {
        Move = this.transform.position;
        Mid = this.transform.position;
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
                
            }

            this.transform.position = Move;
        }




    }

    
}
