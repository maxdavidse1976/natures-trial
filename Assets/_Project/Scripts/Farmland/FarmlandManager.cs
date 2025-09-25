using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FarmlandManager : MonoBehaviour
{
    [SerializeField]
    private FarmlandTile[] _farmlandTiles;

    [Header("Configuration")]
    [SerializeField]
    private float _interval;
    [SerializeField]
    private float _intervalVariation;
    [SerializeField]
    private float _affectedCount;

    [Header("Events")]
    [SerializeField]
    private UnityEvent _onPlantWithered;
    [SerializeField]
    private UnityEvent _onPlantDustAffected;
    [SerializeField]
    private UnityEvent _onPlantDustCleared;

    private List<FarmlandTile> _activePlants = new();
    private List<FarmlandTile> _healthyPlants = new();
    private List<FarmlandTile> _inactivePlants = new();
    private float _iterationVariation;
    private float _time;

    private void Awake()
    {
        foreach (var tile in _farmlandTiles)
        {
            tile.OnDustAffected += PlantDustAffected;
            tile.OnDustCleared += PlantDustCleared;
            tile.OnWithered += PlantWithered;
            _activePlants.Add(tile);
            _healthyPlants.Add(tile);
        }
    }

    private void Start()
    {
        StartNewInterval();
    }

    private void OnDisable()
    {
        foreach (var tile in _farmlandTiles)
        {
            tile.OnDustAffected -= PlantDustAffected;
            tile.OnDustCleared -= PlantDustCleared;
            tile.OnWithered -= PlantWithered;
        }
    }

    private void Update()
    {
        if (_time < GetIterationInterval())
        {
            _time += Time.deltaTime;
        }
        else
        {
            StartNewInterval();
        }
    }

    private float GetIterationInterval()
    {
        return _interval + _iterationVariation;
    }

    private void StartNewInterval()
    {
        _time = 0.0f;
        _iterationVariation = Random.Range(-_intervalVariation, _intervalVariation); // For now either up or down for slight variation
        AffectRandomHealthyPlants();
    }

    private void AffectRandomHealthyPlants()
    {
        if (_healthyPlants.Count <= 0)
        {
            return;
        }

        int initialCount, count, index;
        initialCount = _healthyPlants.Count;
        for (int i = 0; i < Mathf.Min(_affectedCount, initialCount); i++)
        {
            count = _healthyPlants.Count;
            index = Random.Range(0, count);
            _healthyPlants[index].ApplyDustEffect();
            _healthyPlants.RemoveAt(index);
        }
    }

    private void PlantDustCleared(FarmlandTile tile)
    {
        _healthyPlants.Add(tile);
        _onPlantDustCleared?.Invoke();
    }

    private void PlantDustAffected(FarmlandTile tile)
    {
        // Dust affected does not remove from healthy due to apply already handling it.
        _onPlantDustAffected?.Invoke();
    }

    private void PlantWithered(FarmlandTile tile)
    {
        _activePlants.Remove(tile);
        _inactivePlants.Add(tile);
        _onPlantWithered?.Invoke();
    }
}
