using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderHealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _delay = 0.02f;
    [SerializeField] private float _step = 2f;

    private Slider _slider;
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _wait = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        _health.Changed += Show;
    }

    private void OnDisable()
    {
        _health.Changed -= Show;
    }

    private void Show(float value)
    {
        float sliderValue = value / _health.MaxCount;

        _coroutine = StartCoroutine(ChangeVolumeOfSiren(sliderValue));
    }

    private IEnumerator ChangeVolumeOfSiren(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            Debug.Log(targetValue);
            yield return _wait;
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _step * Time.deltaTime);
        }
    }
}
