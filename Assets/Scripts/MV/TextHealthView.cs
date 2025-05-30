using TMPro;
using UnityEngine;

public class TextHealthView : HealthView
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void Show(float value)
    {
        _text.text = value.ToString() + $" / {Health.MaxCount}";
    }
}
