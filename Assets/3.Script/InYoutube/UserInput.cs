using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static PlayerInput playerInput { get; private set; }
  
    //==========================================
    //now gemini

    public static InputAction touchPositionAction;
    public static InputAction touchPressAction;

    public void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPositionAction = playerInput.actions["TouchPosition"];
        touchPressAction = playerInput.actions["TouchPress"];
    }
}
