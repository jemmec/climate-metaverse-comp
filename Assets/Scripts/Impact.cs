using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ImpactType
{
    Sky, Water, Life, Buildings, Home
}

[System.Serializable]
/// <summary>
/// A specifc impact 
/// </summary>
public class Impact
{
    [SerializeField]
    private ImpactType _types;

    //TODO: Maybe add SUBTYPES (i.e. Water/Fish, Sky/Birds)

    //NOTE: 0 = no impact, 1 = MAXIMUM impact

    [SerializeField,
    Range(0f, 1f),
    Tooltip("")]
    private float _impactFactor = 0f;

}
