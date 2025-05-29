using UnityEngine;
using UnityEngine.UI;

public class SliderHealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
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
        _slider.value = value / _health.MaxCount;
    }
}
