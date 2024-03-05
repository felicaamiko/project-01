using UnityEngine;


//simpleton

public class GameState : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
