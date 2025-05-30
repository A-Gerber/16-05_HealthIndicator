using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderHealthView : HealthView
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _delay = 0.02f;
    [SerializeField] private float _step = 2f;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    protected override void Show(float value)
    {
        float sliderValue = value / Health.MaxCount;

        _coroutine = StartCoroutine(ChangeValueOfSlider(sliderValue));
    }

    private IEnumerator ChangeValueOfSlider(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            Debug.Log(targetValue);
            yield return _wait;
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _step * Time.deltaTime);
        }
    }
}