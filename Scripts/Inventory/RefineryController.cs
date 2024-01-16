using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefineryController : MonoBehaviour
{
    private int _numberofRefineries = 0;
    private float _totalJunkRefined = 0;
    private float _averageJunkValue = 0;

    //these accessors might be the same as setting them to public
    public float TotalJunkRefined
    {
        get => _totalJunkRefined;
        set
        {
            _totalJunkRefined = value;
            UIManager.Singleton.SetTotalJunkRefined = value;
        }
    }

    public float AverageJunkValue
    {
        get => _averageJunkValue;
        set
        {
            _averageJunkValue = value;
            UIManager.Singleton.SetAverageJunkValue = value;
        }
    }

    public int NumberOfRefineries
    {
        get => _numberofRefineries;
        set
        {
            _numberofRefineries = value;
            UIManager.Singleton.SetnumberOfRefineries = value;
        }
    }

    void Start()
    {
        StartCoroutine(CalculateAverage(5f));
    }

    
    private IEnumerator CalculateAverage(float numberOfSeconds)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(numberOfSeconds);

        for (;;)
        {
            AverageJunkValue = _averageJunkValue * GlobalSettings.Singleton.JunkValue;

            yield return waitForSeconds;
        }
    }
}
