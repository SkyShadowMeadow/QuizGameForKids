using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class LoadScreen : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private Slider _slider;
    private float _loadTime;
    private float _currentTime = 0;

    public void ActivateLoading(float loadTime)
    {
        gameObject.SetActive(true);
        SetLoadTime(loadTime);
        StartCoroutine(FadeInAndChangeSlider());
    }

    IEnumerator FadeInAndChangeSlider()
    {
        _background.DOFade(1f, _loadTime);
        while(_currentTime < _loadTime)
        {
            _currentTime += Time.deltaTime;
            ChangeValue(_currentTime, _loadTime);
            yield return null;
        }       
        _currentTime = 0;
    }
    public void DisactivateLoading()
    {
        _background.color = new Color(1, 1, 1, 0);
        gameObject.SetActive(false);
    }

    private void ChangeValue(float value, float maxValue) => _slider.value = value / maxValue;
 
    public void SetLoadTime(float loadTime) => _loadTime = loadTime;
}
