using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public int Health = 100;

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            gameObject.GetComponent<Animation>().Play("destroy");
            Destroy(gameObject);
        }
    }

    void Damage(int damage)
    {
        Health -= damage;
        gameObject.GetComponent<Animation>().Play("redflash");
    }
}
