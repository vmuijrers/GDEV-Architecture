using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private IDamageable healthComponent;

    private void OnEnable()
    {
        healthComponent = GetComponent<IDamageable>();
        healthComponent.OnHealthChanged += UpdateUI;
    }

    private void OnDisable()
    {
        healthComponent.OnHealthChanged -= UpdateUI; 
    }

    private void UpdateUI(float _newValue)
    {
        healthSlider.value = _newValue / healthComponent.MaxHealth;
    }
}