using UnityEngine;
using UnityEngine.UI;

public class ButtonsHandler : MonoBehaviour
{
    [SerializeField] private Button _buttonDamage;
    [SerializeField] private Button _buttonHeal;
    [SerializeField] private Health _health;

    private float _min = 5f;
    private float _max = 40f;

    private void OnEnable()
    {
        _buttonDamage.onClick.AddListener(Damage);
        _buttonHeal.onClick.AddListener(Heal);
    }

    private void OnDisable()
    {
        _buttonDamage.onClick.RemoveListener(Damage);
        _buttonHeal.onClick.RemoveListener(Heal);
    }

    private void Damage()
    {
        _health.TakeDamage(Mathf.Round(Random.Range(_min, _max)));
    }

    private void Heal()
    {
        _health.Heal(Mathf.Round(Random.Range(_min, _max)));
    }
}