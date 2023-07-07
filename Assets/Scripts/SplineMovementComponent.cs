using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Splines;

public class SplineMovementComponent : SplineAnimate
{
    //get via a cache
    private static float _pathLength;
    private static SplineContainer _container;
    public static float GetPathLength()
    {
        if (_pathLength is default(float))
            _pathLength = GetContainer().CalculateLength();
        return _pathLength;
    }

    public static SplineContainer GetContainer() //there is an assumption that theres only 1 spline container here. 
    {
        return _container ??= FindObjectOfType<SplineContainer>();
    }

    public void SetSpeed(float speed)
    {
        var splineLength = GetPathLength();
        Duration = splineLength / speed;
    }

    private void OnEnable()
    {
        ObjectForwardAxis = AlignAxis.NegativeYAxis;
        ObjectForwardAxis = AlignAxis.YAxis;
        Container = GetContainer();
    }
}
