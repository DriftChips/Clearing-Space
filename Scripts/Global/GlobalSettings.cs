using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : SingletonTemplate<GlobalSettings>
{
    [Header("Object Renderer Settings")]
    public bool EnableRenderDistance = true;
    [Space]
    [Space]
    [Header("Debug Messages")]
    public bool GlobalSettingsDebug = false;
    public bool GlobalReferencesDebug = false;
    [Space]
    [Space]
    [Header("Value Settings")]
    public int JunkValue = 10;
    public int RareMaterialValue = 100;
    [Space]
    [Space]
    [Header("Player Settings")]
    public int PlayerMaxCargo;
    [Space]
    [Space]
    [Header("Debris Settings")]
    public float DebrisMaxHealth = 3;
    public float DebrisMinHealth = 0;
    public float SecondsToDepleteHealth = 3;
    public float SecondsToRegenerateHealth = 3;
    [Space]
    [Space]
    [Header("Station Settings")]
    public float StationTriggerDistance = 50f;
}
