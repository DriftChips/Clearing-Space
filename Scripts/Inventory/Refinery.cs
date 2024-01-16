using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refinery : MonoBehaviour
{
    [Header("Refinery Controller")]
    [SerializeField] private RefineryController _refineryController;
    [Space]
    [Space]
    [Header("Upgrade Button References")]
    [SerializeField] private GameObject HotFurnacesUpgradeButton;
    [SerializeField] private GameObject LargeTanksUpgradeButton;
    [SerializeField] private GameObject EfficientBurningUpgradeButton;
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
    [Header("Hot Furnaces")]
    [SerializeField] private float _hotFurnacesUpgradeCost = 10;
    [SerializeField] private float _hotFurnacesUpgradeMultiplier = 0.01f;
    [Space]
    [Space]
    [Header("Large Tanks")]
    [SerializeField] private float _largeTanksUpgradeCost = 10;
    [SerializeField] private float _largeTanksUpgradeMultiplier = 1.1f;
    [Space]
    [Space]
    [Header("Efficient Burning")]
    [SerializeField] private float _efficientBurningUpgradeCost = 10;
    [SerializeField] private float _efficientBurningUpgradeMultiplier = 1f;

    private bool _isProcessing = false;
    private bool _refineryIsOff = true;
    private bool _processingIsOff = true;

    private int _hotterFurnaces_Tier = 0;
    private int _largeTanks_Tier = 0;
    private int _efficientBurning_Tier = 0;

    enum RefineryIndex
    {
        One,
        Two,
        Three
    }

    private RefineryIndex _index;

    string minutes = "00";
    string seconds = "00";

    private void Start()
    {
        _index = (RefineryIndex)_refineryController.NumberOfRefineries;

        //update number of refineries in controller and UI
        _refineryController.NumberOfRefineries += 1;
        SetUIRefineryStatus();
        SetUIRefineryTime();

        HotFurnacesUpgradeButton.GetComponent<Button>().onClick.AddListener(HotFurnacesUpgrade);
        LargeTanksUpgradeButton.GetComponent<Button>().onClick.AddListener(LargeTanksUpgrade);
        EfficientBurningUpgradeButton.GetComponent<Button>().onClick.AddListener(EfficientBurningUpgrade);

        _secondsToProcessBaseValue = _secondsToProcess;
        _materialInputCostBaseValue = _materialInputCost;
        _materialOutputAmountBaseValue = _materialOutputAmount;

        //init values, do this somewhere else.
        switch (_index)
        {
            case RefineryIndex.One:
                UIManager.Singleton.Set_RefineryOne_Upgrade_HotterFurnaces_ButtonCost = _hotFurnacesUpgradeCost;
                UIManager.Singleton.Set_RefineryOne_Upgrade_HotterFurnaces_CurrentValue = _secondsToProcess;
                UIManager.Singleton.Set_RefineryOne_Upgrade_HotterFurnaces_NextValue = _secondsToProcess - (_secondsToProcessBaseValue * _hotFurnacesUpgradeMultiplier);
                UIManager.Singleton.Set_RefineryOne_Upgrade_HotterFurnaces_Tier = "0/100";

                UIManager.Singleton.Set_RefineryOne_Upgrade_LargeTanks_ButtonCost = _largeTanksUpgradeCost;
                UIManager.Singleton.Set_RefineryOne_Upgrade_LargeTanks_CurrentValue = _materialInputCost;
                UIManager.Singleton.Set_RefineryOne_Upgrade_LargeTanks_NextValue = _materialInputCost * _largeTanksUpgradeMultiplier;
                UIManager.Singleton.Set_RefineryOne_Upgrade_LargeTanks_Tier = "0/100";

                UIManager.Singleton.Set_RefineryOne_Upgrade_EfficientBurning_ButtonCost = _efficientBurningUpgradeCost;
                UIManager.Singleton.Set_RefineryOne_Upgrade_EfficientBurning_CurrentValue = _materialOutputAmount;
                UIManager.Singleton.Set_RefineryOne_Upgrade_EfficientBurning_NextValue = _materialOutputAmount + 1;
                UIManager.Singleton.Set_RefineryOne_Upgrade_EfficientBurning_Tier = "0/100";
                break;
            case RefineryIndex.Two:
                UIManager.Singleton.Set_RefineryTwo_Upgrade_HotterFurnaces_ButtonCost = _hotFurnacesUpgradeCost;
                UIManager.Singleton.Set_RefineryTwo_Upgrade_HotterFurnaces_CurrentValue = _secondsToProcess;
                UIManager.Singleton.Set_RefineryTwo_Upgrade_HotterFurnaces_NextValue = _secondsToProcess - (_secondsToProcessBaseValue * _hotFurnacesUpgradeMultiplier);
                UIManager.Singleton.Set_RefineryTwo_Upgrade_HotterFurnaces_Tier = "0/100";

                UIManager.Singleton.Set_RefineryTwo_Upgrade_LargeTanks_ButtonCost = _largeTanksUpgradeCost;
                UIManager.Singleton.Set_RefineryTwo_Upgrade_LargeTanks_CurrentValue = _materialInputCost;
                UIManager.Singleton.Set_RefineryTwo_Upgrade_LargeTanks_NextValue = _materialInputCost * _largeTanksUpgradeMultiplier;
                UIManager.Singleton.Set_RefineryTwo_Upgrade_LargeTanks_Tier = "0/100";

                UIManager.Singleton.Set_RefineryTwo_Upgrade_EfficientBurning_ButtonCost = _efficientBurningUpgradeCost;
                UIManager.Singleton.Set_RefineryTwo_Upgrade_EfficientBurning_CurrentValue = _materialOutputAmount;
                UIManager.Singleton.Set_RefineryTwo_Upgrade_EfficientBurning_NextValue = _materialOutputAmount + 1;
                UIManager.Singleton.Set_RefineryTwo_Upgrade_EfficientBurning_Tier = "0/100";
                break;
            case RefineryIndex.Three:
                UIManager.Singleton.Set_RefineryThree_Upgrade_HotterFurnaces_ButtonCost = _hotFurnacesUpgradeCost;
                UIManager.Singleton.Set_RefineryThree_Upgrade_HotterFurnaces_CurrentValue = _secondsToProcess;
                UIManager.Singleton.Set_RefineryThree_Upgrade_HotterFurnaces_NextValue = _secondsToProcess - (_secondsToProcessBaseValue * _hotFurnacesUpgradeMultiplier);
                UIManager.Singleton.Set_RefineryThree_Upgrade_HotterFurnaces_Tier = "0/100";

                UIManager.Singleton.Set_RefineryThree_Upgrade_LargeTanks_ButtonCost = _largeTanksUpgradeCost;
                UIManager.Singleton.Set_RefineryThree_Upgrade_LargeTanks_CurrentValue = _materialInputCost;
                UIManager.Singleton.Set_RefineryThree_Upgrade_LargeTanks_NextValue = _materialInputCost * _largeTanksUpgradeMultiplier;
                UIManager.Singleton.Set_RefineryThree_Upgrade_LargeTanks_Tier = "0/100";

                UIManager.Singleton.Set_RefineryThree_Upgrade_EfficientBurning_ButtonCost = _efficientBurningUpgradeCost;
                UIManager.Singleton.Set_RefineryThree_Upgrade_EfficientBurning_CurrentValue = _materialOutputAmount;
                UIManager.Singleton.Set_RefineryThree_Upgrade_EfficientBurning_NextValue = _materialOutputAmount + 1;
                UIManager.Singleton.Set_RefineryThree_Upgrade_EfficientBurning_Tier = "0/100";
                break;
        }
    }

    private void Update()
    {
        //Is the refinery on
        if (UIManager.Singleton.IsRefineryOn)
        {
            //is the refinery currently processing
            //do we have the required resources
            _refineryIsOff = false; //control so UI only updates once
            if (!_isProcessing && UIManager.Singleton.GetResourcesJunkValue >= _materialInputCost)
            {
                _processingIsOff = false; //control so UI only updates once
                
                //start processing
                _isProcessing = true;
                SetUIRefineryStatus();
                StartCoroutine(ProcessJunk(_secondsToProcess, _materialInputCost, _materialOutputAmount));
            }
            else
            {
                if (!_processingIsOff && !_isProcessing)
                {
                    SetUIRefineryStatus();
                    _processingIsOff = true;
                }
            }
        }
        else
        {
            if (!_refineryIsOff && !_isProcessing)
            {
                SetUIRefineryStatus();
                _refineryIsOff = true;
            }
        }
    }

    public void HotFurnacesUpgrade()
    {
        if (UIManager.Singleton.GetResourcesCurrencyValue >= _hotFurnacesUpgradeCost)
        {
            UIManager.Singleton.SetResourcesCurrencyValue -= _hotFurnacesUpgradeCost;

            _hotterFurnaces_Tier++;
            _secondsToProcess -= _secondsToProcessBaseValue * _hotFurnacesUpgradeMultiplier;

            switch (_index)
            {
                case RefineryIndex.One:
                    UIManager.Singleton.Set_RefineryOne_Upgrade_HotterFurnaces_ButtonCost = _hotFurnacesUpgradeCost * _hotterFurnaces_Tier;
                    UIManager.Singleton.Set_RefineryOne_Upgrade_HotterFurnaces_CurrentValue = _secondsToProcess;
                    UIManager.Singleton.Set_RefineryOne_Upgrade_HotterFurnaces_NextValue = _secondsToProcess - (_secondsToProcessBaseValue * _hotFurnacesUpgradeMultiplier);
                    UIManager.Singleton.Set_RefineryOne_Upgrade_HotterFurnaces_Tier = _hotterFurnaces_Tier + "/100";
                    break;
                case RefineryIndex.Two:
                    UIManager.Singleton.Set_RefineryTwo_Upgrade_HotterFurnaces_ButtonCost = _hotFurnacesUpgradeCost * _hotterFurnaces_Tier;
                    UIManager.Singleton.Set_RefineryTwo_Upgrade_HotterFurnaces_CurrentValue = _secondsToProcess;
                    UIManager.Singleton.Set_RefineryTwo_Upgrade_HotterFurnaces_NextValue = _secondsToProcess - (_secondsToProcessBaseValue * _hotFurnacesUpgradeMultiplier);
                    UIManager.Singleton.Set_RefineryTwo_Upgrade_HotterFurnaces_Tier = _hotterFurnaces_Tier + "/100";
                    break;
                case RefineryIndex.Three:
                    UIManager.Singleton.Set_RefineryThree_Upgrade_HotterFurnaces_ButtonCost = _hotFurnacesUpgradeCost * _hotterFurnaces_Tier;
                    UIManager.Singleton.Set_RefineryThree_Upgrade_HotterFurnaces_CurrentValue = _secondsToProcess;
                    UIManager.Singleton.Set_RefineryThree_Upgrade_HotterFurnaces_NextValue = _secondsToProcess - (_secondsToProcessBaseValue * _hotFurnacesUpgradeMultiplier);
                    UIManager.Singleton.Set_RefineryThree_Upgrade_HotterFurnaces_Tier = _hotterFurnaces_Tier + "/100";
                    break;
            }
        }
    }

    public void LargeTanksUpgrade()
    {
        // limit station inventory??
        //increase storage of refinery
        if (UIManager.Singleton.GetResourcesCurrencyValue >= _largeTanksUpgradeCost)
        {
            UIManager.Singleton.SetResourcesCurrencyValue -= _largeTanksUpgradeCost;
            
            _largeTanks_Tier++;
            _materialInputCost *= _largeTanksUpgradeMultiplier;
            _materialOutputAmount *= _largeTanksUpgradeMultiplier;

            switch (_index)
            {
                case RefineryIndex.One:
                    UIManager.Singleton.Set_RefineryOne_Upgrade_LargeTanks_ButtonCost = _largeTanksUpgradeCost * _largeTanks_Tier;
                    UIManager.Singleton.Set_RefineryOne_Upgrade_LargeTanks_CurrentValue = _materialInputCost;
                    UIManager.Singleton.Set_RefineryOne_Upgrade_LargeTanks_NextValue = _materialInputCost * _largeTanksUpgradeMultiplier;
                    UIManager.Singleton.Set_RefineryOne_Upgrade_LargeTanks_Tier = _largeTanks_Tier + "/100";
                    break;
                case RefineryIndex.Two:
                    UIManager.Singleton.Set_RefineryTwo_Upgrade_LargeTanks_ButtonCost = _largeTanksUpgradeCost * _largeTanks_Tier;
                    UIManager.Singleton.Set_RefineryTwo_Upgrade_LargeTanks_CurrentValue = _materialInputCost;
                    UIManager.Singleton.Set_RefineryTwo_Upgrade_LargeTanks_NextValue = _materialInputCost * _largeTanksUpgradeMultiplier;
                    UIManager.Singleton.Set_RefineryTwo_Upgrade_LargeTanks_Tier = _largeTanks_Tier + "/100";
                    break;
                case RefineryIndex.Three:
                    UIManager.Singleton.Set_RefineryThree_Upgrade_LargeTanks_ButtonCost = _largeTanksUpgradeCost * _largeTanks_Tier;
                    UIManager.Singleton.Set_RefineryThree_Upgrade_LargeTanks_CurrentValue = _materialInputCost;
                    UIManager.Singleton.Set_RefineryThree_Upgrade_LargeTanks_NextValue = _materialInputCost * _largeTanksUpgradeMultiplier;
                    UIManager.Singleton.Set_RefineryThree_Upgrade_LargeTanks_Tier = _largeTanks_Tier + "/100";
                    break;
            }
        }
    }

    public void EfficientBurningUpgrade()
    {
        if (UIManager.Singleton.GetResourcesCurrencyValue >= _efficientBurningUpgradeCost)
        {
            UIManager.Singleton.SetResourcesCurrencyValue -= _efficientBurningUpgradeCost;

            _efficientBurning_Tier++;
            _materialOutputAmount += 1;

            switch (_index)
            {
                case RefineryIndex.One:
                    UIManager.Singleton.Set_RefineryOne_Upgrade_EfficientBurning_ButtonCost = _efficientBurningUpgradeCost * _efficientBurning_Tier;
                    UIManager.Singleton.Set_RefineryOne_Upgrade_EfficientBurning_CurrentValue = _materialOutputAmount;
                    UIManager.Singleton.Set_RefineryOne_Upgrade_EfficientBurning_NextValue = _materialOutputAmount + 1;
                    UIManager.Singleton.Set_RefineryOne_Upgrade_EfficientBurning_Tier = _efficientBurning_Tier + "/100";
                    break;
                case RefineryIndex.Two:
                    UIManager.Singleton.Set_RefineryTwo_Upgrade_EfficientBurning_ButtonCost = _efficientBurningUpgradeCost * _efficientBurning_Tier;
                    UIManager.Singleton.Set_RefineryTwo_Upgrade_EfficientBurning_CurrentValue = _materialOutputAmount;
                    UIManager.Singleton.Set_RefineryTwo_Upgrade_EfficientBurning_NextValue = _materialOutputAmount + 1;
                    UIManager.Singleton.Set_RefineryTwo_Upgrade_EfficientBurning_Tier = _efficientBurning_Tier + "/100";
                    break;
                case RefineryIndex.Three:
                    UIManager.Singleton.Set_RefineryThree_Upgrade_EfficientBurning_ButtonCost = _efficientBurningUpgradeCost * _efficientBurning_Tier;
                    UIManager.Singleton.Set_RefineryThree_Upgrade_EfficientBurning_CurrentValue = _materialOutputAmount;
                    UIManager.Singleton.Set_RefineryThree_Upgrade_EfficientBurning_NextValue = _materialOutputAmount + 1;
                    UIManager.Singleton.Set_RefineryThree_Upgrade_EfficientBurning_Tier = _efficientBurning_Tier + "/100";
                    break;
            }
        }

    }

    private IEnumerator ProcessJunk(float secondsToProcess, float materialInputCost, float materialOutputAmount)
    {
        //second check to see if we have the required resources (incase something changed last frame)
        if (UIManager.Singleton.GetResourcesJunkValue >= materialInputCost)
        {
            float remainingTime = secondsToProcess;

            //remove junk
            UIManager.Singleton.SetResourcesJunkValue -= materialInputCost;

            while (remainingTime > 0f)
            {
                SetUIRefineryTime();
                minutes = Mathf.Floor(remainingTime / 60).ToString("00");
                seconds = Mathf.Floor(remainingTime % 60).ToString("00");

                remainingTime -= Time.deltaTime;
                yield return null;
            }

            //add new materials
            UIManager.Singleton.ResourcesRareMaterialsValue += materialOutputAmount;
            _refineryController.TotalJunkRefined += materialOutputAmount;

            //stop processing
            _isProcessing = false;
        }
        else { _isProcessing = false; }
    }

    private void SetUIRefineryTime()
    {
        //can only handle 3 refineries
        switch (_index)
        {
            case RefineryIndex.One:
                UIManager.Singleton.SetRefineryOneTimer = minutes + ":" + seconds;
                break;
            case RefineryIndex.Two:
                UIManager.Singleton.SetRefineryTwoTimer = minutes + ":" + seconds;
                break;
            case RefineryIndex.Three:
                UIManager.Singleton.SetRefineryThreeTimer = minutes + ":" + seconds;
                break;
        }
    }

    private void SetUIRefineryStatus()
    {
        //can only handle 3 refineries
        switch (_index)
        {
            case RefineryIndex.One:
                {
                    if (_isProcessing)
                    {
                        UIManager.Singleton.SetRefineryOneStatus = "| Refining |";
                        UIManager.Singleton.SetRefineryOneStatusColor = new Color(0.0f, 0.5f, 1.0f);
                    }
                    else 
                    {
                        UIManager.Singleton.SetRefineryOneStatus = "|......Idle......|";
                        UIManager.Singleton.SetRefineryOneStatusColor = new Color(1.0f, 0.5f, 0.0f);
                    }
                    break;
                }
            case RefineryIndex.Two:
                {
                    if (_isProcessing)
                    {
                        UIManager.Singleton.SetRefineryTwoStatus = "| Refining |";
                        UIManager.Singleton.SetRefineryTwoStatusColor = new Color(0.0f, 0.5f, 1.0f);
                    }
                    else
                    {
                        UIManager.Singleton.SetRefineryTwoStatus = "|......Idle......|";
                        UIManager.Singleton.SetRefineryTwoStatusColor = new Color(1.0f, 0.5f, 0.0f);
                    }
                    break;
                }
            case RefineryIndex.Three:
                {
                    if (_isProcessing)
                    {
                        UIManager.Singleton.SetRefineryThreeStatus = "| Refining |";
                        UIManager.Singleton.SetRefineryThreeStatusColor = new Color(0.0f, 0.5f, 1.0f);
                    }
                    else
                    {
                        UIManager.Singleton.SetRefineryThreeStatus = "|......Idle......|";
                        UIManager.Singleton.SetRefineryThreeStatusColor = new Color(1.0f, 0.5f, 0.0f);
                    }
                    break;
                }
        }
    }
}
