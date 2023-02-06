using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIQuestion : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nameText, _bodyText, _answer1Text, _answer2Text;

    [SerializeField]
    private Button _answer1Button, _answer2Button;

    public Button Answer1Button => _answer1Button;
    public Button Answer2Button => _answer2Button;

    [SerializeField, Tooltip("Will position the good/bad answer randomly")]
    private bool _randomAnswerPosition;

    public void ApplyQuestion(Question question)
    {
        _nameText.text = question.QuestionName;
        _bodyText.text = question.QuestionContent;
        if (_randomAnswerPosition)
        {
            bool flip = Random.Range(0, 100) > 50;
            _answer1Text.text = "1) " + (flip ? question.GoodOption : question.BadOption);
            _answer2Text.text = "2) " + (flip ? question.BadOption : question.GoodOption);
        }
        else
        {
            _answer1Text.text = "1) " + question.GoodOption;
            _answer2Text.text = "2) " + question.BadOption;
        }
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }
}
