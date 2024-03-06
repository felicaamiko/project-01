using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Scene game;//fix

    [SerializeField] AudioClip buttonpop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playbuttonclicked()
    {
        // GetComponent<AudioSource>().PlayOneShot(buttonpop);
        //buttonpop.isReadyToPlay();
        //GetComponent<AudioSource>().Play();
        //since audiosource cannot play because the scene reloads, play on awake when the next scene loads...



        SceneManager.LoadScene("Game");
        Debug.Log("Game");
    }
}
