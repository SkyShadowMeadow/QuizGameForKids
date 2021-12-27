using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image _representation;
    [SerializeField] private ParticleSystem _starsVFX;

    private Image[] _images;
    private string _identifier;
    private AnswerChecker _answerChecker;

    public event UnityAction<Cell> GetRightAnswer;

    private void Awake()
    {
        _images = GetComponentsInChildren<Image>();
        _answerChecker = GetComponent<AnswerChecker>();
    }

    public void SetCellConfiguration(string identifier, Sprite representation)
    {
        _identifier = identifier;
        _representation.sprite = representation;
        _answerChecker.SetCurrentAnswer(_identifier);
    }
    public void SetRightAnswer(string answer) => _answerChecker.SetRightAnswer(answer);

    public void BounceAppearance()
    {
        _images = GetComponentsInChildren<Image>();
        foreach (Image image in _images)
        {
            image.fillAmount = 0;
        }
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(Vector3.zero, 0.001f));
        foreach (Image image in _images)
        {
            sequence.Insert(1, image.DOFillAmount(1, 0.01f));
        }
        sequence.Append(transform.DOScale(1f, 0.2f));
        sequence.Append(transform.DOPunchScale(Vector3.one * 0.2f, 0.8f, 6, 0.3f).SetEase(Ease.OutCirc));
    }

    public void ProcessRightAnswer() => GetRightAnswer?.Invoke(this);

    public void Shake() => _representation.transform.DOShakePosition(1f, 20f, 10, 30f, false, true);
    
    public void BounceRepresentation() => _representation.transform.DOPunchScale(Vector3.one * 0.2f, 0.8f, 6, 0.3f).SetEase(Ease.OutCirc);

    public void PlayParticles() => _starsVFX.Play();


}
