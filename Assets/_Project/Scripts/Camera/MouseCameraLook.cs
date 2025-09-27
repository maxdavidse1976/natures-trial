using UnityEngine;
using UnityEngine.InputSystem;

public class MouseCameraLook : MonoBehaviour, ILookListener
{

    [SerializeField]
    private InputBinder _inputBinder;

    [SerializeField]
    private CursorLockMode _cursorMode = CursorLockMode.Locked;
    [SerializeField]
    private float _sensitivityX = 15.0f;
    [SerializeField]
    private float _sensitivityY = 15.0f;

    [SerializeField]
    private Vector2 _yRotationRange = new Vector2(-60.0f, 60.0f);

    private float _rotationY;

    private void Awake()
    {
        if (!_inputBinder)
        {
            throw new System.NullReferenceException($"Object {name} {nameof(_inputBinder)} is not assigned in the inspector. Please assign it before playing.");
        }   

        _rotationY = transform.localEulerAngles.x;
        Cursor.lockState = _cursorMode;
    }

    private void Start()
    {
        _inputBinder?.AddLookListener(this);
    }

    private void OnDisable()
    {
        _inputBinder?.RemoveLookListener(this);
    }

    public void SetIsCursorLock(bool isLocked)
    {
        _cursorMode = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.lockState = _cursorMode;
    }

    #region ILookListener Interface

    public void OnLookCanceled(InputAction.CallbackContext context)
    {

    }

    public void OnLookPerformed(InputAction.CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        float rotationX = transform.localEulerAngles.y + lookInput.x * _sensitivityX * Time.deltaTime;
        _rotationY += lookInput.y * _sensitivityY * Time.deltaTime;
        _rotationY = Mathf.Clamp(_rotationY, _yRotationRange.x, _yRotationRange.y);

        transform.localEulerAngles = new Vector3(-_rotationY, rotationX, 0);
    }

    public void OnLookStart(InputAction.CallbackContext context)
    {

    }

    #endregion
}
