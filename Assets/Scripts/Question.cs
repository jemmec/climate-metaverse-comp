using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Question", menuName = "UNChallenge/Question", order = 1)]
/// <summary>
/// Defines a specific question to ask in the UN Challange
/// </summary>
public class Question : ScriptableObject
{
    [SerializeField]
    private string _questionName = "question name";

    public string QuestionName => _questionName;

    [SerializeField, TextArea(5, 100)]
    private string _questionContent = "question body";

    public string QuestionContent => _questionContent;

    [SerializeField, TextArea(4, 100)]
    private string _goodOption = "good option";

    public string GoodOption => _goodOption;

    [SerializeField, TextArea(4, 100)]
    private string _badOption = "bad option";

    public string BadOption => BadOption;


}
