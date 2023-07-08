using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAttackPattern : MonoBehaviour
{
    public abstract bool CanAttack();
    public abstract void Attack();

    public Action<Minion> ApplyAttack { get;  set; }
}
