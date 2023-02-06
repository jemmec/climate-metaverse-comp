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

    [SerializeField]
    private RawImage _answer1Image, _answer2Image;

    public Button Answer1Button => _answer1Button;
    public Button Answer2Button => _answer2Button;

    [SerializeField, Tooltip("Will position the good/bad answer randomly")]
    private bool _randomAnswerPosition;

    [SerializeField, Tooltip("Shows or hides the answer text")]
    private bool _showAnswerText;

    public void ApplyQuestion(Question question)
    {
        _nameText.text = question.QuestionName;
        _bodyText.text = question.QuestionContent;
        if (_randomAnswerPosition)
        {
            bool flip = Random.Range(0, 100) > 50;
            _answer1Text.text = (flip ? question.GoodOption : question.BadOption);
            _answer1Image.texture = (flip ? question.GoodImage : question.BadImage);
            _answer2Text.text = (flip ? question.BadOption : question.GoodOption);
            _answer2Image.texture = (flip ? question.BadImage : question.GoodImage);
        }
        else
        {
            _answer1Text.text = question.GoodOption;
            _answer1Image.texture = question.GoodImage;
            _answer2Text.text = question.BadOption;
            _answer2Image.texture = question.BadImage;
        }
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }
}
