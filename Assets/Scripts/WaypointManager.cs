using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaypointManager : MonoBehaviour
{

    //Flag for when the user is interacting with a waypoint
    private bool _isInteractingWithWaypoint = false;

    //question coroutine
    private Coroutine _questionCoroutine = null;

    //List of the waypoints in the current scene (discovered at runtime)
    //Key = the Waypoint object
    //Value = nullable boolean, null if unanswered, will be true or false when answered
    //          true = good answer, false = bad answer
    private Dictionary<Waypoint, bool?> _waypoints = new Dictionary<Waypoint, bool?>();

    private List<Waypoint> Waypoints => _waypoints.Keys.ToList();

    [SerializeField]
    private QuestionAnsweredEvent _onQuestionAnswered = new QuestionAnsweredEvent();

    public QuestionAnsweredEvent OnQuestionAnswered => _onQuestionAnswered;

    private PlayerActions _actions;

    private void Start()
    {
        _actions = new PlayerActions();
        _actions.PLAYER.Enable();
        //Get all of the waypoints, set answer to null
        var wpts = FindObjectsOfType<Waypoint>();
        if (wpts != null && wpts.Length > 0)
        {
            foreach (Waypoint waypoint in wpts)
            {
                _waypoints.Add(waypoint, null);
            }
        }
    }

    private void Update()
    {
        //Poll for player collider intersects
        if (!_isInteractingWithWaypoint)
            PollIntersects();

    }

    private void PollIntersects()
    {
        BoxCollider box;
        //Just a saftey try-get method, 
        //no overhead since we're caching FindGameObjectOfType results
        if (PlayerPosition.TryGetPlayerBoxCollider(out box))
        {
            //Test intersects against all waypoints
            foreach (Waypoint waypoint in Waypoints)
            {
                if (box.bounds.Intersects(waypoint.Trigger.bounds))
                {
                    HandleIntersects(waypoint);
                    break;
                }
            }
        }
    }

    private void HandleIntersects(Waypoint waypoint)
    {
        _isInteractingWithWaypoint = true;

        //Early out because this question has already been answered
        if (_waypoints[waypoint].HasValue) return;

        //Freeze player movement ?

        //Teleport player to the viewing location ?

        //Show the question
        waypoint.ShowQuestion(true);
        //Could implement a statemachine here but for sake of
        //time I will do it the hacky Coroutine way, and
        //each waypoint only has one question 
        _questionCoroutine = StartCoroutine(AskQuestionRoutine(
            waypoint.Question,
            (goodAnswer) =>
            {
                Debug.Log("User answered the question, good answer ? " + goodAnswer);
                //Update Dictionary
                _waypoints[waypoint] = goodAnswer;
                //Install prefab in the room
                waypoint.InstallPrefab(goodAnswer);
                //fire question answered event
                OnQuestionAnswered.Invoke(waypoint.Question, goodAnswer);
                //Hide the question
                waypoint.ShowQuestion(false);
                //Set is interactionWithWaypoint false
                _isInteractingWithWaypoint = false;
            }
        ));
    }

    private IEnumerator AskQuestionRoutine(Question question, UnityAction<bool> callback)
    {
        //The resulting answer good / bad
        bool goodAnswer = false;
        //Kinda hacky, but we can just wait infinitely until user has answered question
        yield return new WaitUntil(() =>
            AnswerQuestionWithKeyboardInput(out goodAnswer) ||
            AnswerQuestion(out goodAnswer)
        );
        //fire callback with the result
        callback(goodAnswer);
    }

    /// <summary>
    /// This is just for testing, can answer questions with keyboard input
    /// </summary>
    /// <param name="goodAnswer"></param>
    /// <returns></returns>
    private bool AnswerQuestionWithKeyboardInput(out bool goodAnswer)
    {
        goodAnswer = false;
        //Good answer
        if (_actions.PLAYER.GoodAnswer.IsPressed())
        {
            goodAnswer = true;
            return true;
        }
        //Bad Answer
        else if (_actions.PLAYER.BadAnswer.IsPressed())
            return true;
        return false;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="goodAnswer"></param>
    /// <returns></returns>
    private bool AnswerQuestion(out bool goodAnswer)
    {
        //TODO: Implement XR interaction to answer question here
        goodAnswer = false;
        return false;
    }




}


public class QuestionAnsweredEvent : UnityEvent<Question, bool> { }