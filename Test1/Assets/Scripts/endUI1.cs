using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endUI1 : MonoBehaviour
{
    public GameObject pauseUI;
    // Start is called before the first frame update
    public bool pause = false, Bpause = false;
    public SoundManager sound;

    // Use this for initialization
    void Start()
    {
        pauseUI.SetActive(false);
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Bpause = true;
        if (Bpause == true && pause == false)
        {
            pause = !pause;
            sound.Playsound("die");
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
        SceneManager.LoadScene(0);
        
    }

    public void quit()
    {
        Application.Quit();
    }
}


