using UnityEngine;

public class SoilTile : MonoBehaviour
{
    [SerializeField] SoilState _state = SoilState.Healthy;
    [SerializeField] MeshRenderer _renderer;
    [SerializeField] Material _healthyMaterial;
    [SerializeField] Material _dryMaterial;
    [SerializeField] Material _crackedMaterial;
    [SerializeField] Material _deadMaterial;

    float _healthTimer = 10f; // Time before degrading

    public bool hasCrop = false;
    public bool hasGrass = false;

    void Start()
    {
        UpdateVisual();
    }

    void Update()
    {
        _healthTimer -= Time.deltaTime;
        if (_healthTimer <= 0)
        {
            DegradeSoil();
            ResetTimer(); //
        }
    }

    void ResetTimer()
    {
        _healthTimer = 10f;
    }

    void DegradeSoil()
    {
        if (_state == SoilState.Healthy) _state = SoilState.Dry;
        else if (_state == SoilState.Dry) _state = SoilState.Cracked;
        else if (_state == SoilState.Cracked) _state = SoilState.Dead;
        UpdateVisual();
    }

    void UpdateVisual()
    {
        switch (_state)
        {
            case SoilState.Healthy: _renderer.material = _healthyMaterial; break;
            case SoilState.Dry: _renderer.material = _dryMaterial; break;
            case SoilState.Cracked: _renderer.material = _crackedMaterial; break;
            case SoilState.Dead: _renderer.material = _deadMaterial; break;
        }
    }

    public void PlantCrop()
    {
        if (_state == SoilState.Healthy || _state == SoilState.Dry)
        {
            hasCrop = true;
            Debug.Log("Planted crop!");
        }
    }

    public void PlantGrass()
    {
        hasGrass = true;
        _state = SoilState.Healthy; // Planting grass restores soil
        UpdateVisual();
        Debug.Log("Grass planted");
    }

    public void Water()
    {
        if (_state == SoilState.Dry || _state == SoilState.Cracked)
        {
            _state = SoilState.Healthy;
            UpdateVisual();
            Debug.Log("Tile watered");
        }
    }

    public void DustStormDamage()
    {
        DegradeSoil();
        if (hasCrop)
        {
            hasCrop = false; // DustStorm destroys crops
            Debug.Log("Storm wiped crops");
        }
    }
}
