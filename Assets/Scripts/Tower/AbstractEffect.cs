using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEffect : MonoBehaviour
{
    public abstract IEnumerator Attack();
    public bool IsPlaying { get; }
}
