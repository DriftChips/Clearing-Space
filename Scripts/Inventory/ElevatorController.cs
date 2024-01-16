using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    private int _numberofElevators = 0;
    private float _rareMaterialsCreated = 0;
    private float _averageRareMaterialValue = 0;

    //these accessors might be the same as setting them to public
    public float RareMaterialsCreated
    {
        get => _rareMaterialsCreated;
        set
        {
            _rareMaterialsCreated = value;
            UIManager.Singleton.SetTotalRareMaterialsSold = value;
        }
    }

    public float AverageRareMaterialValue
    {
        get => _averageRareMaterialValue;
        set
        {
            _averageRareMaterialValue = value;
            UIManager.Singleton.SetAverageRareMaterialValue = value;
        }
    }

    public int NumberOfElevators
    {
        get => _numberofElevators;
        set
        {
            _numberofElevators = value;
            UIManager.Singleton.SetnumberOfElevators = value;
        }
    }
    void Start()
    {
        StartCoroutine(CalculateAverage(5f));
    }

    private IEnumerator CalculateAverage(float numberOfSeconds)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(numberOfSeconds);

        for (; ; )
        {
            AverageRareMaterialValue = _averageRareMaterialValue * GlobalSettings.Singleton.RareMaterialValue;

            yield return waitForSeconds;
        }
    }
}
