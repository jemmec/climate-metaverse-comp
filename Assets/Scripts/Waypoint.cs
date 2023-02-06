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
    public Question Question => _question;

    [SerializeField]
    private UIQuestion _questionUI;

    public UIQuestion QuestionUI => _questionUI;

    [SerializeField]
    private GameObject _goodChoicePrefab;
    public GameObject GoodChoicePrefab => _goodChoicePrefab;

    [SerializeField]
    private GameObject _badChoicePrefab;
    public GameObject BadChoicePrefab => _badChoicePrefab;

    private BoxCollider _triggerBox;
    public BoxCollider Trigger => _triggerBox;


    void Awake()
    {
        if (!Question)
            throw new System.Exception("Waypoint has no question! Ensure all waypoints have a question assigned.");

        _triggerBox = GetComponent<BoxCollider>();
        _questionUI.ApplyQuestion(Question);

        _questionUI.Show(false);

    }


    public void ShowQuestion(bool show)
    {
        _questionUI.Show(show);
    }


    /// <summary>
    /// Installs the prefab into this waypoint
    /// </summary>
    /// <param name="good"></param>
    public void InstallPrefab(bool good)
    {
        //TODO
    }

    /// <summary>
    /// Shows a "Ghost" view of the prefab when user selects an option
    /// </summary>
    /// <param name="good"></param>
    public void DemoPrefab(bool good)
    {
        //TODO
    }

}
