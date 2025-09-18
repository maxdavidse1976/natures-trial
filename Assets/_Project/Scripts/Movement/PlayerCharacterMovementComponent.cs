using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterMovementComponent : CharacterMovementComponent, IMoveListener
{
    [SerializeField]
    private InputBinder _inputBinder;

    [SerializeField]
    private float _speed = 5.0f;

    private Vector3 _movementInput;
    private Vector3 _playerVelocity;
    private bool _isGrounded = false;

    protected override void Awake()
    {
        base.Awake();
        if (!_inputBinder)
        {
            throw new System.NullReferenceException($"Object {name} {nameof(_inputBinder)} is not assigned in the inspector. Please assign it before playing.");
        }
    }

    private void Start()
    {
        _inputBinder?.AddMoveListener(this);
    }

    private void OnDisable()
    {
        _inputBinder?.RemoveMoveListener(this);
    }

    private void Update()
    {
        SimpleMoveOnUpdate();
    }

    private void SimpleMoveOnUpdate()
    {
        if (_isGrounded && _movementInput == Vector3.zero)
        {
            return;
        }

        _isGrounded = SimpleMove(GetRelativeMovement(), _speed);
    }

    private Vector3 GetRelativeMovement()
    {
        Vector3 forward = transform.forward * _movementInput.y;
        Vector3 right = transform.right * _movementInput.x;
        Vector3 direction = forward + right;
        return direction.normalized;
    }

    #region IMoveListener Interface

    public void OnMovePerformed(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }

    public void OnMoveStart(InputAction.CallbackContext context)
    {
        
    }

    public void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _movementInput = Vector3.zero;
    }

    #endregion
}
