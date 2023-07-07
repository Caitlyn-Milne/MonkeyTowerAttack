#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(SplineMovementComponent))]
public class Minion : MonoBehaviour
{
    public SpriteRenderer _spriteRenderer;
    public SplineMovementComponent _splineMovement;
    public MinionSettings? Settings { get; private set; }

    public void SetSettings(MinionSettings settings)
    {
        Settings = settings;
        _spriteRenderer.sprite = settings.Sprite;
        _splineMovement.SetSpeed(settings.Speed);
    }

    private void NextState()
    {
        if (Settings?.NextState is null)
            Cleanup();
        else
            SetSettings(Settings.NextState); 
    }

    private void Cleanup()
    {
        MinionSpawner.Instance.ReleaseMinion(this);
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
