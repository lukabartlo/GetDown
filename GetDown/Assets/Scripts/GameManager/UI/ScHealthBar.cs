using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public TextMeshProUGUI healthAmount;

    public static ScHealthBar Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        healthAmount.text = ScTakeDamage.Instance.maxHealth.ToString();
    }

    public void SetMaxHealth()
    {
        _slider.value = _slider.maxValue;
    }

    public void SetHealth(int health)
    {
        _slider.value = health;
    }
}
