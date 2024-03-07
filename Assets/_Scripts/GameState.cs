using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//simpleton that is permanent. always knows the state

public class GameState : MonoBehaviour
{
    public string currentSceneName = "";//unused

    [SerializeField] Text statetext; //HUD shows state for FSM
    public static GameState Instance; //makes sure there is only one THERE CAN BE ONLY ONE
    private void Awake()
    {
        if (Instance != null)//if instance is present 
        {
            Destroy(gameObject);//destroy t
        }
        Instance = this;//this is the new instance
        DontDestroyOnLoad(gameObject); // gets the gameobject on the object specified "this" "gameObject" both are the same
    }

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        currentSceneName = scene.name;
        //Debug.Log(currentSceneName);
        if (currentSceneName == "Main Menu")
        {
            statetext.text = "main menu";
        }

    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        currentSceneName = scene.name;
        if (currentSceneName != "Main Menu")
        {
            if (Goober.isgrounded && Goofer.isgroundedgoof)
            {
                if (Goober.istouched == true)
                {
                    statetext.text = "fight";
                }
                if (Goober.istouched == false)
                {
                    statetext.text = "fleed";
                }
            }
            if (Goober.isgrounded && !Goofer.isgroundedgoof) {
                statetext.text = "won";
            }
            if (!Goober.isgrounded) {
                statetext.text = "lost";
                
            }
            //Debug.Log("gaaa");
        }
    }
}
