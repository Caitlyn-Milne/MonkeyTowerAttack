#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTower : Tower
{
    public AbstractAttackPattern AttackPattern;
    public AbstractEffect? Effect;

    private void Start()
    {
        AttackPattern.ApplyAttack = minion =>
        {
            if (minion.Settings is null) return;
            if (minion.Settings.SpecialTraits.HasFlag(MinionSettings.SpecialTrait.Camouflaged))
            {
                minion.NextState();
            }
        };
    }

    public void FixedUpdate()
    {
        if (AttackPattern.CanAttack() && (!Effect?.IsPlaying ?? true))
        {
            AttackPattern.Attack();
            Effect?.Attack();
        }
    }
}
