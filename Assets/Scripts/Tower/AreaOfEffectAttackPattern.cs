#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AreaOfEffectAttackPattern : AbstractAttackPattern
{
    public float Radius;
    public float AttackCooldown;
    private float _timeOfLastAttack = 0;
    public LayerMask layerMask;

    public override void Attack()
    {
        if (!CanAttack()) return;
        var minions = GetMinionsInRange().ToArray();
        foreach (var minion in minions)
            ApplyAttack?.Invoke(minion);
        _timeOfLastAttack = Time.time;
    }

    public override bool CanAttack()
    {
        return Time.time > _timeOfLastAttack + AttackCooldown
            && HasMinionsInRange();
    }

    private bool HasMinionsInRange()
    {
        return Physics2D.OverlapCircleAll(transform.position, Radius, layerMask) is not null;
    }

    private IEnumerable<Minion> GetMinionsInRange()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, Radius, layerMask);
        return colliders
            .Select(c => c.GetComponent<Minion>())
            .Where(c => c is not null);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
