using TMPro;
using UnityEngine;

public class TextHealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _text;

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
        _text.text = value.ToString() + $" / {_health.MaxCount}";
    }
}
