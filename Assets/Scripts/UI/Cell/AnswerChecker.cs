using UnityEngine;
using UnityEngine.Events;

public  class AnswerChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent _onClickRightAnswer;
    [SerializeField] private UnityEvent _onClickWrongAnswer;
    [SerializeField] private GameFlow _gameFlow;

    private Cell _cell;
    private string _rightAnswer;
    private string _currentAnswer;

    private void Start()
    {
        _cell = GetComponent<Cell>();

        if (_onClickRightAnswer == null)
            _onClickRightAnswer = new UnityEvent();

        _onClickRightAnswer.AddListener(NotifyFinishedLevel);
    }

    public void CheckAnswer()
    {
        if (_rightAnswer == _currentAnswer) _onClickRightAnswer?.Invoke();
        else _onClickWrongAnswer?.Invoke();
    }

    public void SetRightAnswer(string answer) => _rightAnswer = answer;
   
    public void SetCurrentAnswer(string answer) => _currentAnswer = answer;
    
    private void NotifyFinishedLevel() => _cell.ProcessRightAnswer();

}
