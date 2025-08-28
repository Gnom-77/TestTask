using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float _speed = 10f;
    [SerializeField] Rigidbody _rigidbody;
    [Space, Header("Plane Settings")]
    [SerializeField] private float _planeSize = 25f;
    [Space, Header("Mobile Settings")]
    [SerializeField] private MobileJoystick _joystick;

    private InputController _inputController;

    public float Speed => _speed;

    private void Awake()
    {
        _inputController = new InputController(_joystick);
    }

    private void FixedUpdate()
    {
        Vector3 direction = _inputController.GetDirection();
        
        Vector3 velocity = direction.normalized * _speed;

        Vector3 newPosition = _rigidbody.position + velocity * Time.fixedDeltaTime;

        float halfSize = _planeSize / 2f;
        newPosition.x = Mathf.Clamp(newPosition.x, -halfSize, halfSize);
        newPosition.z = Mathf.Clamp(newPosition.z, -halfSize, halfSize);

        _rigidbody.MovePosition(newPosition);
    }

    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }
}
