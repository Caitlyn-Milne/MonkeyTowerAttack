#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using static UnityEngine.Splines.SplineComponent;

[RequireComponent(typeof(SpriteRenderer))]
public class Minion : MonoBehaviour
{
    private static float _pathLength;

    private static SplineContainer _container;
    public static SplineContainer GetContainer() //there is an assumption that theres only 1 spline container here. 
    {
        return _container ??= FindObjectOfType<SplineContainer>();
    }
    public static float GetPathLength()
    {
        if (_pathLength is default(float))
            _pathLength = GetContainer().CalculateLength();
        return _pathLength;
    }


    public SpriteRenderer _spriteRenderer;

    float _position0to1 = 0f;
    private float _speed = 0f;

    public MinionSettings? Settings { get; private set; }

    public void Init(MinionSettings settings)
    {
        _position0to1 = 0;

        gameObject.SetActive(true);

        SetSettings(settings);
    }

    public void SetSettings(MinionSettings settings)
    {
        Settings = settings;
        _spriteRenderer.sprite = settings.Sprite;
        _speed = settings.Speed / GetPathLength();
    }

    public void NextState()
    {
        if (Settings?.NextState is null)
            Cleanup();
        else
            SetSettings(Settings.NextState); 
    }

    private void Cleanup()
    {
        transform.position = new Vector2(-200, -200);
        MinionSpawner.Instance.ReleaseMinion(this);
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        _position0to1 += Time.deltaTime * _speed;
        _position0to1 %= 1;
        Vector3 positon = GetContainer().EvaluatePosition(_position0to1);
        transform.position = positon;
    }
}
