using UnityEngine;

public class InputController : IInputController
{
    private readonly KeyboardInputController _keyboard;
    private readonly MobileJoystickInputController _joystick;

    private IInputController _activeController;

    public InputController(MobileJoystick joystick)
    {
        _keyboard = new KeyboardInputController();
        _joystick = joystick != null ? new MobileJoystickInputController(joystick) : null;
        _activeController = _keyboard;
    }

    public Vector3 GetDirection()
    {
        Vector3 keyboardDir = _keyboard.GetDirection();
        Vector3 joystickDir = _joystick != null ? _joystick.GetDirection() : Vector3.zero;

        // если есть ввод с клавы
        if (keyboardDir.sqrMagnitude > 0.01f)
        {
            _activeController = _keyboard;
        }
        // если есть ввод со стика
        else if (joystickDir.sqrMagnitude > 0.01f)
        {
            _activeController = _joystick;
        }

        return _activeController.GetDirection();
    }
}
