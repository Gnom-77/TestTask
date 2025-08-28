using UnityEngine;

public class MobileJoystickInputController : IInputController
{
    private readonly MobileJoystick _joystick;

    public MobileJoystickInputController(MobileJoystick joystick)
    {
        _joystick = joystick;
    }

    public Vector3 GetDirection()
    {
        Vector2 input = _joystick.InputVector;
        return new Vector3(input.x, 0f, input.y);
    }
}
