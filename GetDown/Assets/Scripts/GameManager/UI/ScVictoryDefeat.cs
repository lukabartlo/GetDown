using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScVictoryDefeat : MonoBehaviour
{
    [SerializeField] private GameObject _defeat;
    [SerializeField] private GameObject _victory;

    public static ScVictoryDefeat Instance;

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
        _defeat.SetActive(false);
        _victory.SetActive(false);
    }

    public void Defeat() 
    {
        _defeat.SetActive(true);
    }

    public void Victory()
    {
        _victory.SetActive(true);
    }
}
