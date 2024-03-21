using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScEnergyBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public TextMeshProUGUI energyAmount;

    public static ScEnergyBar Instance;

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
        energyAmount.text = ScShooting.Instance.maxNumberBullet.ToString();
    }

    public void SetMaxEnergy()
    {
        _slider.value = _slider.maxValue;
    }

    public void SetEnergy(int energy)
    {
        _slider.value = energy;
    }
}
