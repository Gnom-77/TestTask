using UnityEngine;

public class KeyboardInputController : IInputController
{
    public Vector3 GetDirection()
    {
        float horizontalDirection = Input.GetAxisRaw("Horizontal");
        float verticalDirection = Input.GetAxisRaw("Vertical");
        
        return new Vector3 (horizontalDirection, 0f, verticalDirection);
    }
}
