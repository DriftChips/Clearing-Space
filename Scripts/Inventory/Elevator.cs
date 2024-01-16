using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour
{
    [Header("Refinery Controller")]
    [SerializeField] private ElevatorController _elevatorController;
    [Space]
    [Space]
    [Header("Upgrade Button References")]
    [SerializeField] private GameObject FasterMotorsUpgradeButton;
    [SerializeField] private GameObject LargerCannistersUpgradeButton;
    [SerializeField] private GameObject MarketingStrategyUpgradeButton;
    [Space]
    [Space]
    [Header("Processing Data")]
    [SerializeField] private float _secondsToProcess = 60;
    private float _secondsToProcessBaseValue;
    [SerializeField] private float _materialInputCost = 10;
    private float _materialInputCostBaseValue = 10;
    [SerializeField] private float _materialOutputAmount = 1;
    private float _materialOutputAmountBaseValue = 1;
    [Space]
    [Space]
    [Header("Faster Motors")]
    [SerializeField] private float _fasterMotorsUpgradeCost = 10;
    [SerializeField] private float _fasterMotorsUpgradeMultiplier = 0.01f;
    [Space]
    [Space]
    [Header("Larger Cannisters")]
    [SerializeField] private float _largerCannistersUpgradeCost = 10;
    [SerializeField] private float _largerCannistersUpgradeMultiplier = 1.1f;
    [Space]
    [Space]
    [Header("Marketing Strategy")]
    [SerializeField] private float _marketingStrategyUpgradeCost = 10;
    [SerializeField] private float _marketingStrategyUpgradeMultiplier = 1f;

    private bool _isProcessing = false;
    private bool _elevatorIsOff = true;
    private bool _processingIsOff = true;

    private int _fasterMotors_Tier = 0;
    private int _largerCannisters_Tier = 0;
    private int _marketingStrategy_Tier = 0;

    enum ElevatorIndex
    {
        One,
        Two,
        Three
    }

    private ElevatorIndex _index;

    string minutes = "00";
    string seconds = "00";


    void Start()
    {
        _index = (ElevatorIndex)_elevatorController.NumberOfElevators;

        //update number of elevators in controller and UI
        _elevatorController.NumberOfElevators += 1;
        SetUIElevatorStatus();
        SetUIElevatorTime();

        FasterMotorsUpgradeButton.GetComponent<Button>().onClick.AddListener(FasterMotorsUpgrade);
        LargerCannistersUpgradeButton.GetComponent<Button>().onClick.AddListener(LargerCannistersUpgrade);
        MarketingStrategyUpgradeButton.GetComponent<Button>().onClick.AddListener(MarketingStrategyUpgrade);

        _secondsToProcessBaseValue = _secondsToProcess;
        _materialInputCostBaseValue = _materialInputCost;
        _materialOutputAmountBaseValue = _materialOutputAmount;

        //init values, do this somewhere else.
        switch (_index)
        {
            case ElevatorIndex.One:
                UIManager.Singleton.Set_ElevatorOne_Upgrade_FasterMotors_ButtonCost = _fasterMotorsUpgradeCost;
                UIManager.Singleton.Set_ElevatorOne_Upgrade_FasterMotors_CurrentValue = _secondsToProcess;
                UIManager.Singleton.Set_ElevatorOne_Upgrade_FasterMotors_NextValue = _secondsToProcess - (_secondsToProcessBaseValue * _fasterMotorsUpgradeMultiplier);
                UIManager.Singleton.Set_ElevatorOne_Upgrade_FasterMotors_Tier = "0/100";

                UIManager.Singleton.Set_ElevatorOne_Upgrade_LargerCannisters_ButtonCost = _largerCannistersUpgradeCost;
                UIManager.Singleton.Set_ElevatorOne_Upgrade_LargerCannisters_CurrentValue = _materialInputCost;
                UIManager.Singleton.Set_ElevatorOne_Upgrade_LargerCannisters_NextValue = _materialInputCost * _largerCannistersUpgradeMultiplier;
                UIManager.Singleton.Set_ElevatorOne_Upgrade_LargerCannisters_Tier = "0/100";

                UIManager.Singleton.Set_ElevatorOne_Upgrade_MarketingStrategy_ButtonCost = _marketingStrategyUpgradeCost;
                UIManager.Singleton.Set_ElevatorOne_Upgrade_MarketingStrategy_CurrentValue = _materialOutputAmount;
                UIManager.Singleton.Set_ElevatorOne_Upgrade_MarketingStrategy_NextValue = _materialOutputAmount + 1;
                UIManager.Singleton.Set_ElevatorOne_Upgrade_MarketingStrategy_Tier = "0/100";
                break;
            case ElevatorIndex.Two:
                UIManager.Singleton.Set_ElevatorTwo_Upgrade_FasterMotors_ButtonCost = _fasterMotorsUpgradeCost;
                UIManager.Singleton.Set_ElevatorTwo_Upgrade_FasterMotors_CurrentValue = _secondsToProcess;
                UIManager.Singleton.Set_ElevatorTwo_Upgrade_FasterMotors_NextValue = _secondsToProcess - (_secondsToProcessBaseValue * _fasterMotorsUpgradeMultiplier);
                UIManager.Singleton.Set_ElevatorTwo_Upgrade_FasterMotors_Tier = "0/100";

                UIManager.Singleton.Set_ElevatorTwo_Upgrade_LargerCannisters_ButtonCost = _largerCannistersUpgradeCost;
                UIManager.Singleton.Set_ElevatorTwo_Upgrade_LargerCannisters_CurrentValue = _materialInputCost;
                UIManager.Singleton.Set_ElevatorTwo_Upgrade_LargerCannisters_NextValue = _materialInputCost * _largerCannistersUpgradeMultiplier;
                UIManager.Singleton.Set_ElevatorTwo_Upgrade_LargerCannisters_Tier = "0/100";

                UIManager.Singleton.Set_ElevatorTwo_Upgrade_MarketingStrategy_ButtonCost = _marketingStrategyUpgradeCost;
                UIManager.Singleton.Set_ElevatorTwo_Upgrade_MarketingStrategy_CurrentValue = _materialOutputAmount;
                UIManager.Singleton.Set_ElevatorTwo_Upgrade_MarketingStrategy_NextValue = _materialOutputAmount + 1;
                UIManager.Singleton.Set_ElevatorTwo_Upgrade_MarketingStrategy_Tier = "0/100";
                break;
            case ElevatorIndex.Three:
                UIManager.Singleton.Set_ElevatorThree_Upgrade_FasterMotors_ButtonCost = _fasterMotorsUpgradeCost;
                UIManager.Singleton.Set_ElevatorThree_Upgrade_FasterMotors_CurrentValue = _secondsToProcess;
                UIManager.Singleton.Set_ElevatorThree_Upgrade_FasterMotors_NextValue = _secondsToProcess - (_secondsToProcessBaseValue * _fasterMotorsUpgradeMultiplier);
                UIManager.Singleton.Set_ElevatorThree_Upgrade_FasterMotors_Tier = "0/100";

                UIManager.Singleton.Set_ElevatorThree_Upgrade_LargerCannisters_ButtonCost = _largerCannistersUpgradeCost;
                UIManager.Singleton.Set_ElevatorThree_Upgrade_LargerCannisters_CurrentValue = _materialInputCost;
                UIManager.Singleton.Set_ElevatorThree_Upgrade_LargerCannisters_NextValue = _materialInputCost * _largerCannistersUpgradeMultiplier;
                UIManager.Singleton.Set_ElevatorThree_Upgrade_LargerCannisters_Tier = "0/100";

                UIManager.Singleton.Set_ElevatorThree_Upgrade_MarketingStrategy_ButtonCost = _marketingStrategyUpgradeCost;
                UIManager.Singleton.Set_ElevatorThree_Upgrade_MarketingStrategy_CurrentValue = _materialOutputAmount;
                UIManager.Singleton.Set_ElevatorThree_Upgrade_MarketingStrategy_NextValue = _materialOutputAmount + 1;
                UIManager.Singleton.Set_ElevatorThree_Upgrade_MarketingStrategy_Tier = "0/100";
                break;
        }
    }

    void Update()
    {
        if (UIManager.Singleton.IsElevatorOn)
        {
            _elevatorIsOff = false; //control so UI only updates once
            if (!_isProcessing && UIManager.Singleton.ResourcesRareMaterialsValue >= _materialInputCost)
            {
                _processingIsOff = false; //control so UI only updates once

                //start processing
                _isProcessing = true;
                SetUIElevatorStatus();
                StartCoroutine(ProcessRareMaterials(_secondsToProcess, _materialInputCost, _materialOutputAmount));
            }
            else 
            {
                if (!_processingIsOff && !_isProcessing)
                {
                    SetUIElevatorStatus();
                    _processingIsOff = true;
                }
            }
        }
        else 
        {
            if (!_elevatorIsOff && !_isProcessing)
            { 
                SetUIElevatorStatus();
                _elevatorIsOff = true;
            }
        }
    }

    public void FasterMotorsUpgrade()
    {
        if (UIManager.Singleton.GetResourcesCurrencyValue >= _fasterMotorsUpgradeCost)
        {
            UIManager.Singleton.SetResourcesCurrencyValue -= _fasterMotorsUpgradeCost;

            _fasterMotors_Tier++;
            _secondsToProcess -= _secondsToProcessBaseValue * _fasterMotorsUpgradeMultiplier;

            switch (_index)
            {
                case ElevatorIndex.One:
                    UIManager.Singleton.Set_ElevatorOne_Upgrade_FasterMotors_ButtonCost = _fasterMotorsUpgradeCost * _fasterMotors_Tier;
                    UIManager.Singleton.Set_ElevatorOne_Upgrade_FasterMotors_CurrentValue = _secondsToProcess;
                    UIManager.Singleton.Set_ElevatorOne_Upgrade_FasterMotors_NextValue = _secondsToProcess - (_secondsToProcessBaseValue * _fasterMotorsUpgradeMultiplier);
                    UIManager.Singleton.Set_ElevatorOne_Upgrade_FasterMotors_Tier = _fasterMotors_Tier + "/100";
                    break;
                case ElevatorIndex.Two:
                    UIManager.Singleton.Set_ElevatorTwo_Upgrade_FasterMotors_ButtonCost = _fasterMotorsUpgradeCost * _fasterMotors_Tier; ;
                    UIManager.Singleton.Set_ElevatorTwo_Upgrade_FasterMotors_CurrentValue = _secondsToProcess;
                    UIManager.Singleton.Set_ElevatorTwo_Upgrade_FasterMotors_NextValue = _secondsToProcess - (_secondsToProcessBaseValue * _fasterMotorsUpgradeMultiplier);
                    UIManager.Singleton.Set_ElevatorTwo_Upgrade_FasterMotors_Tier = _fasterMotors_Tier + "/100";
                    break;
                case ElevatorIndex.Three:
                    UIManager.Singleton.Set_ElevatorThree_Upgrade_FasterMotors_ButtonCost = _fasterMotorsUpgradeCost * _fasterMotors_Tier; ;
                    UIManager.Singleton.Set_ElevatorThree_Upgrade_FasterMotors_CurrentValue = _secondsToProcess;
                    UIManager.Singleton.Set_ElevatorThree_Upgrade_FasterMotors_NextValue = _secondsToProcess - (_secondsToProcessBaseValue * _fasterMotorsUpgradeMultiplier);
                    UIManager.Singleton.Set_ElevatorThree_Upgrade_FasterMotors_Tier = _fasterMotors_Tier + "/100";
                    break;
            }
        }
    }

    public void LargerCannistersUpgrade()
    {
        // limit station inventory??
        //increase storage of refinery
        if (UIManager.Singleton.GetResourcesCurrencyValue >= _largerCannistersUpgradeCost)
        {
            UIManager.Singleton.SetResourcesCurrencyValue -= _largerCannistersUpgradeCost;

            _largerCannisters_Tier++;
            _materialInputCost *= _largerCannistersUpgradeMultiplier;
            _materialOutputAmount *= _largerCannistersUpgradeMultiplier;

            switch (_index)
            {
                case ElevatorIndex.One:
                    UIManager.Singleton.Set_ElevatorOne_Upgrade_LargerCannisters_ButtonCost = _largerCannistersUpgradeCost * _largerCannisters_Tier;
                    UIManager.Singleton.Set_ElevatorOne_Upgrade_LargerCannisters_CurrentValue = _materialInputCost;
                    UIManager.Singleton.Set_ElevatorOne_Upgrade_LargerCannisters_NextValue = _materialInputCost * _largerCannistersUpgradeMultiplier;
                    UIManager.Singleton.Set_ElevatorOne_Upgrade_LargerCannisters_Tier = _largerCannisters_Tier + "/100";
                    break;
                case ElevatorIndex.Two:
                    UIManager.Singleton.Set_ElevatorTwo_Upgrade_LargerCannisters_ButtonCost = _largerCannistersUpgradeCost * _largerCannisters_Tier;
                    UIManager.Singleton.Set_ElevatorTwo_Upgrade_LargerCannisters_CurrentValue = _materialInputCost;
                    UIManager.Singleton.Set_ElevatorTwo_Upgrade_LargerCannisters_NextValue = _materialInputCost * _largerCannistersUpgradeMultiplier;
                    UIManager.Singleton.Set_ElevatorTwo_Upgrade_LargerCannisters_Tier = _largerCannisters_Tier + "/100";
                    break;
                case ElevatorIndex.Three:
                    UIManager.Singleton.Set_ElevatorThree_Upgrade_LargerCannisters_ButtonCost = _largerCannistersUpgradeCost * _largerCannisters_Tier;
                    UIManager.Singleton.Set_ElevatorThree_Upgrade_LargerCannisters_CurrentValue = _materialInputCost;
                    UIManager.Singleton.Set_ElevatorThree_Upgrade_LargerCannisters_NextValue = _materialInputCost * _largerCannistersUpgradeMultiplier;
                    UIManager.Singleton.Set_ElevatorThree_Upgrade_LargerCannisters_Tier = _largerCannisters_Tier + "/100";
                    break;
            }
        }
    }

    public void MarketingStrategyUpgrade()
    {
        if (UIManager.Singleton.GetResourcesCurrencyValue >= _marketingStrategyUpgradeCost)
        {
            UIManager.Singleton.SetResourcesCurrencyValue -= _marketingStrategyUpgradeCost;

            _marketingStrategy_Tier++;
            _materialOutputAmount += 1;

            switch (_index)
            {
                case ElevatorIndex.One:
                    UIManager.Singleton.Set_ElevatorOne_Upgrade_MarketingStrategy_ButtonCost = _marketingStrategyUpgradeCost * _marketingStrategy_Tier;
                    UIManager.Singleton.Set_ElevatorOne_Upgrade_MarketingStrategy_CurrentValue = _materialOutputAmount;
                    UIManager.Singleton.Set_ElevatorOne_Upgrade_MarketingStrategy_NextValue = _materialOutputAmount + 1;
                    UIManager.Singleton.Set_ElevatorOne_Upgrade_MarketingStrategy_Tier = _marketingStrategy_Tier + "/100";
                    break;
                case ElevatorIndex.Two:
                    UIManager.Singleton.Set_ElevatorTwo_Upgrade_MarketingStrategy_ButtonCost = _marketingStrategyUpgradeCost * _marketingStrategy_Tier;
                    UIManager.Singleton.Set_ElevatorTwo_Upgrade_MarketingStrategy_CurrentValue = _materialOutputAmount;
                    UIManager.Singleton.Set_ElevatorTwo_Upgrade_MarketingStrategy_NextValue = _materialOutputAmount + 1;
                    UIManager.Singleton.Set_ElevatorTwo_Upgrade_MarketingStrategy_Tier = _marketingStrategy_Tier + "/100";
                    break;
                case ElevatorIndex.Three:
                    UIManager.Singleton.Set_ElevatorThree_Upgrade_MarketingStrategy_ButtonCost = _marketingStrategyUpgradeCost * _marketingStrategy_Tier;
                    UIManager.Singleton.Set_ElevatorThree_Upgrade_MarketingStrategy_CurrentValue = _materialOutputAmount;
                    UIManager.Singleton.Set_ElevatorThree_Upgrade_MarketingStrategy_NextValue = _materialOutputAmount + 1;
                    UIManager.Singleton.Set_ElevatorThree_Upgrade_MarketingStrategy_Tier = _marketingStrategy_Tier + "/100";
                    break;
            }
        }

    }

    private IEnumerator ProcessRareMaterials(float secondsToProcess, float materialInputCost, float materialOutputAmount)
    {
        if (UIManager.Singleton.ResourcesRareMaterialsValue >= materialInputCost)
        {
            float remainingTime = secondsToProcess;

            //remove rare materials
            UIManager.Singleton.ResourcesRareMaterialsValue -= materialInputCost;

            while (remainingTime > 0f)
            {
                SetUIElevatorTime();
                minutes = Mathf.Floor(remainingTime / 60).ToString("00");
                seconds = Mathf.Floor(remainingTime % 60).ToString("00");

                remainingTime -= Time.deltaTime;
                yield return null;
            }

            //add new materials
            UIManager.Singleton.SetResourcesCurrencyValue += materialOutputAmount;
            _elevatorController.RareMaterialsCreated += materialOutputAmount;

            //stop processing
            _isProcessing = false;
        }
        else { _isProcessing = false; }
    }

    private void SetUIElevatorTime()
    {
        //can only handle 3 refineries
        switch (_index)
        {
            case ElevatorIndex.One:
                UIManager.Singleton.SetElevatorOneTimer = minutes + ":" + seconds;
                break;
            case ElevatorIndex.Two:
                UIManager.Singleton.SetElevatorTwoTimer = minutes + ":" + seconds;
                break;
            case ElevatorIndex.Three:
                UIManager.Singleton.SetElevatorThreeTimer = minutes + ":" + seconds;
                break;
        }
    }

    private void SetUIElevatorStatus()
    {
        //can only handle 3 refineries
        switch (_index)
        {
            case ElevatorIndex.One:
                {
                    if (_isProcessing)
                    {
                        UIManager.Singleton.SetElevatorOneStatus = "| Refining |";
                        UIManager.Singleton.SetElevatorOneStatusColor = new Color(0.0f, 0.5f, 1.0f);
                    }
                    else
                    {
                        UIManager.Singleton.SetElevatorOneStatus = "|......Idle......|";
                        UIManager.Singleton.SetElevatorOneStatusColor = new Color(1.0f, 0.5f, 0.0f);
                    }
                    break;
                }
            case ElevatorIndex.Two:
                {
                    if (_isProcessing)
                    {
                        UIManager.Singleton.SetElevatorTwoStatus = "| Refining |";
                        UIManager.Singleton.SetElevatorTwoStatusColor = new Color(0.0f, 0.5f, 1.0f);
                    }
                    else
                    {
                        UIManager.Singleton.SetElevatorTwoStatus = "|......Idle......|";
                        UIManager.Singleton.SetElevatorTwoStatusColor = new Color(1.0f, 0.5f, 0.0f);
                    }
                    break;
                }
            case ElevatorIndex.Three:
                {
                    if (_isProcessing)
                    {
                        UIManager.Singleton.SetElevatorThreeStatus = "| Refining |";
                        UIManager.Singleton.SetElevatorThreeStatusColor = new Color(0.0f, 0.5f, 1.0f);
                    }
                    else
                    {
                        UIManager.Singleton.SetElevatorThreeStatus = "|......Idle......|";
                        UIManager.Singleton.SetElevatorThreeStatusColor = new Color(1.0f, 0.5f, 0.0f);
                    }
                    break;
                }
        }
    }
}
