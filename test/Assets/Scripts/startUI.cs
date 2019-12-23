using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startUI : MonoBehaviour
{
    public GameObject pauseUI;
    // Start is called before the first frame update
    public bool pause = false, Bpause = false;


    // Use this for initialization
    void Start()
    {
        pauseUI.SetActive(false);
        Bpause = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Bpause == true && pause == false)
        {
            pause = !pause;

        }

        if (pause)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (pause == false)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }


    }
    public void bpause(bool x)
    {
        Bpause = x;
    }
    public void resume()
    {
        pause = false;
    }
      
    public void restart()
    {
        pause = false;
        bpause(false);
    }

   
}


