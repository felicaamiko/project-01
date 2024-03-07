using UnityEngine;
using UnityEngine.InputSystem;
//15:24 touch finished, debugs output is 1
//17:16 instantiate finished, but i don't think is too necessary. 

public class TouchManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerInput pinput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;
    private void Awake()
    {
        pinput = GetComponent<PlayerInput>();
        touchPressAction = pinput.actions.FindAction("TouchPress");
        //touchPressAction = pinput.actions.["TouchPress"]; //apparent old school way
        touchPositionAction = pinput.actions.FindAction("TouchPosition");
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context) {

        //Vector2 position = touchPositionAction.ReadValue<Vector2>();//gets screen coordinates?
        Vector3 position = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());//convert to world coordinates?
        position.y = player.transform.position.y; //in case it made the z pos funky
        player.transform.position = position;
        float value = context.ReadValue<float>();
        Debug.Log(value);
        context.ReadValueAsObject();


        Goober.istapped = true;
        //Goober.rb.AddForce(transform.forward * 20);


    }
}
