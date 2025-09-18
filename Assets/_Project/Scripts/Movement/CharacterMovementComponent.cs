using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovementComponent : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController;
    public CharacterController CharacterController => _characterController;

    protected virtual void Awake()
    {
        if (!_characterController)
        {
            _characterController = GetComponent<CharacterController>();
        }
    }

    public CollisionFlags Move(Vector3 direction, float speed)
    {
        return _characterController.Move(direction.normalized * speed);
    }

    public bool SimpleMove(Vector3 direction, float speed)
    {
        return _characterController.SimpleMove(direction.normalized * speed);
    }
}
