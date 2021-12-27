using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private Image _background;
    private float _maxAlfa = 0.85f;
    private float _timeToFade = 1.5f;

    public void Appear()
    {
        _background.color = new Color(_background.color.r, _background.color.g, _background.color.b, 0);
        _background.DOFade(_maxAlfa, _timeToFade);
    }
}
