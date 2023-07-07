using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MinionSetting", menuName = "Custom/MinionSpawnSetting")]
public class MinionSpawnSetting : ScriptableObject
{

    public MinionSettings MinionSettings;

    /// <summary>
    /// Frequncy in minions per second
    /// </summary>
    public float Frequency;

    /// <summary>
    /// Total amount
    /// </summary>
    public int Amount;
}
