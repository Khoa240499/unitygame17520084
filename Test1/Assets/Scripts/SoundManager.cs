using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip coins, die, jump, backgound;

    public AudioSource adisrc;
    // Use this for initialization
    void Start()
    {
        coins = Resources.Load<AudioClip>("coin");
        die = Resources.Load<AudioClip>("die");
        jump = Resources.Load<AudioClip>("jump");
        backgound = Resources.Load<AudioClip>("music");
        adisrc = GetComponent<AudioSource>();

    }

    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "coins":
                adisrc.clip = coins;
                adisrc.PlayOneShot(coins, 0.6f);
                break;

            case "die":
                adisrc.clip = die;
                adisrc.PlayOneShot(die, 3f);
                break;

            case "jump":
                adisrc.clip = jump;
                adisrc.PlayOneShot(jump, 1f);
                break;
            case "backgound":
                adisrc.clip = backgound;
                adisrc.PlayOneShot(backgound, 1f);
                break;
        }
    }
}
