using UnityEngine;
using UnityEngine.UI;

public class SliderHealthView : HealthView
{
    [SerializeField] private Slider _slider;

    protected override void Show(float value)
    {
        _slider.value = value / Health.MaxCount;
    }
}
