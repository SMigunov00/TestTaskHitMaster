using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    public void HandleChangeHealthOnDisplay(float health)
    {
        if (health > 0)
            _healthBar.value = health;
        else
            gameObject.SetActive(false);
    }
}