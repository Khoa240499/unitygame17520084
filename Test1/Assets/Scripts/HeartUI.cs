using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] Heartsprite;

    public Player player;

    public Image Heart;
    public SoundManager sound;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.ourHealth > 5)
            player.ourHealth = 5;


        if (player.ourHealth < 0)
        {
            player.ourHealth = 0;
            
        }

        Heart.sprite = Heartsprite[player.ourHealth];
    }
}
