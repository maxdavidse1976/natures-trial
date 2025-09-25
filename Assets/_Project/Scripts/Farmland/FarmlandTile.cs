using UnityEngine;
using UnityEngine.Events;

public class FarmlandTile : MonoBehaviour, ILookHoverer
{
    public event System.Action<FarmlandTile> OnWithered;
    public event System.Action<FarmlandTile> OnDustAffected;
    public event System.Action<FarmlandTile> OnDustCleared;

    [SerializeField]
    private GameObject _plantRoot;
    [SerializeField]
    private ParticleSystem _dustEffect;

    [SerializeField, Tooltip("Health of the plant before it withers, each health point represents one second.")]
    private float _health = 60.0f;

    private bool _isAffected = false;

    private void Update()
    {
        if (_isAffected && _health > 0)
        {
            _health -= Time.deltaTime;
            if (_health <= 0)
            {
                Wither();
            }
        }
    }

    public void ApplyDustEffect()
    {
        if (!_isAffected)
        {
            _isAffected = true;
            _dustEffect.Play();
            OnDustAffected?.Invoke(this);
        }
    }

    public void TryClearDust()
    {
        if (_isAffected)
        {
            ClearDustEffect();
            OnDustCleared?.Invoke(this);
        }
    }

    private void Wither()
    {
        // Logic for withering the plant
        Debug.Log("The plant has withered.");
        ClearDustEffect();
        _plantRoot.SetActive(false);
        OnWithered?.Invoke(this);
    }

    private void ClearDustEffect()
    {
        _isAffected = false;
        _dustEffect.Stop();
    }

    #region ILookHoverer Interface
    public void OnLookHoverEnter()
    {
        
    }

    public void OnLookHoverInteract()
    {
        TryClearDust();
    }

    public void OnLookHoverExit()
    {
        
    }

    #endregion
}
