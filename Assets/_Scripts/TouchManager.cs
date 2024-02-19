using UnityEngine;
using UnityEngine.InputSystem;
//15:24 touch finished, debugs output is 1
public class TouchManager : MonoBehaviour
{
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
        float value = context.ReadValue<float>();
        Debug.Log(value);
        context.ReadValueAsObject();
    }
}
