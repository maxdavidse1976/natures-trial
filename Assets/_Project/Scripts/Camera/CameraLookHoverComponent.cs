using UnityEngine;
using Utils;

public interface ILookHoverer
{
    void OnLookHoverEnter();
    void OnLookHoverExit();
}

public class CameraLookHoverComponent : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private float _range = 5.0f;

    private ILookHoverer _currentLookHoverer;

    private void Awake()
    {
        this.AssertReference(_camera);
    }

    private void Update()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, _range, _layerMask.value))
        {
            if (hit.collider.TryGetComponent(out ILookHoverer lookHoverer))
            {
                if (_currentLookHoverer == lookHoverer)
                {
                    return;
                }
                else if (_currentLookHoverer != null)
                {
                    _currentLookHoverer.OnLookHoverExit();
                }

                _currentLookHoverer = lookHoverer;
                _currentLookHoverer.OnLookHoverEnter();
            }
            else
            {
                TryExitCurrent();
            }
        }
        else
        {
            TryExitCurrent();
        }
    }

    private void TryExitCurrent()
    {
        _currentLookHoverer?.OnLookHoverExit();
        _currentLookHoverer = null;
    }
}
