#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MinionSetting", menuName = "Custom/MinionSettings")]
public class MinionSettings : ScriptableObject
{
    [Flags]
    public enum SpecialTrait
    {
        Camouflaged = 1 << 1,
        Armoured = 1 << 2,
    }
    [field:SerializeField] public SpecialTrait SpecialTraits { get; set; }
    [field:SerializeField] public float Speed { get; set; }
    [field:SerializeField] public Sprite? Sprite { get; set; }
    [field: SerializeField] public MinionSettings? NextState { get; set; }
}
