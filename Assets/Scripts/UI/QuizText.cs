using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QuizText : MonoBehaviour
{
    [SerializeField] private Text _findText;
    [SerializeField] private Text _whatToFind;
    private float _timeToFade = 2f;

    public void SetWhatToFind(string currentObjectNameToFind)
    {
        _whatToFind.text = currentObjectNameToFind;
    }

    public void FadeIn()
    {
        _findText.color = new Color(_findText.color.r, _findText.color.g, _findText.color.b, 0);
        _whatToFind.color = new Color(_findText.color.r, _findText.color.g, _findText.color.b, 0);

        _findText.DOFade(1, _timeToFade);
        _whatToFind.DOFade(1, _timeToFade);
    }
}
