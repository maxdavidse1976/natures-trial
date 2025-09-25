using UnityEngine;
using Utils;

public class FarmlandTile : MonoBehaviour, ILookHoverer
{
    public event System.Action<FarmlandTile> OnWithered;
    public event System.Action<FarmlandTile> OnDustAffected;
    public event System.Action<FarmlandTile> OnDustCleared;

    [SerializeField]
    private GameObject _plantRoot;
    [SerializeField]
    private ParticleSystem _dustEffect;
    [SerializeField]
    private Renderer _plantRenderer;
    [SerializeField]
    private Material _highlightMaterial;

    [SerializeField, Tooltip("Health of the plant before it withers, each health point represents one second.")]
    private float _health = 60.0f;

    private Material _defaultMaterial;
    private bool _isAffected = false;
    private Color _tint;

    private void Awake()
    {
        this.AssertReference(_plantRoot);
        this.AssertReference(_dustEffect);
        this.AssertReference(_plantRenderer);
        this.AssertReference(_highlightMaterial);

        _defaultMaterial = _plantRenderer.material;
        _tint = _plantRenderer.material.color;  
    }

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
            SetPlantTint(Color.gray); // Change color to indicate dust effect
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
        SetPlantTint(Color.white);
    }

    private void SetPlantTint(Color color)
    {
        _tint = color;
        _plantRenderer.material.color = _tint;
    }

    #region ILookHoverer Interface
    public void OnLookHoverEnter()
    {
        _plantRenderer.material = _highlightMaterial; 
        _plantRenderer.material.color = _tint; // Maintain the current tint
    }

    public void OnLookHoverInteract()
    {
        TryClearDust();
    }

    public void OnLookHoverExit()
    {
        _plantRenderer.material = _defaultMaterial;
        _plantRenderer.material.color = _tint; // Maintain the current tint
    }

    #endregion
}
