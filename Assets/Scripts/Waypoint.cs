using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Defines a physical waypoint for UN questions to exist in the house
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class Waypoint : MonoBehaviour
{

    [SerializeField, Tooltip("Reference to the question at this waypoint")]
    private Question _question;

    private BoxCollider _triggerBox;

    void Awake()
    {
        _triggerBox = GetComponent<BoxCollider>();
    }




}
