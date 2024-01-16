using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : SingletonTemplate<UIManager>
{
    public Sprite ButtonOn;
    public Sprite ButtonOff;

    #region "UI Resources Variables"

    private TextMeshProUGUI _resourcesJunkText;
    private float _resourcesJunkValue;

    private TextMeshProUGUI _resourcesCurrencyText;
    private float _resourcesCurrencyValue = 10000;

    private TextMeshProUGUI _resourcesRareMaterialsText;
    private float _resourcesRareMaterialsValue;

    private TextMeshProUGUI _resourcesChipsText; 
    private float _resourcesChipsValue;

    #endregion

    #region "Player Cargo Variables"

    private TextMeshProUGUI _playerCargoText;
    private int _playerCargoValue;

    private TextMeshProUGUI _playerMaxCargoText;
    //private int _playerMaxCargoValue; //Currently in GlobalSettings

    #endregion

    #region "UI Refinery Variables"
    //private GameObject _refinerySubCanvas;

    // move this to refinery controler
    private Button _refineryButtonOnOff;
    private Image _refineryButtonImage;
    private bool _isRefineryOn = true;
    //

    private TextMeshProUGUI _refineryTotalJunkRefinedText;

    private TextMeshProUGUI _refineryAverageJunkValueText;

    private TextMeshProUGUI _refineryNumberOfRefineriesText;

    private TextMeshProUGUI _refineryOneStatusText;
    private TextMeshProUGUI _refineryOneTimerText;

    private TextMeshProUGUI _refineryTwoStatusText;
    private TextMeshProUGUI _refineryTwoTimerText;

    private TextMeshProUGUI _refineryThreeStatusText;
    private TextMeshProUGUI _refineryThreeTimerText;

    #endregion

    #region "UI Refinery Upgrade Variables"

    private TextMeshProUGUI _refineryOne_Upgrade_HotterFurnaces_ButtonCostText;
    private TextMeshProUGUI _refineryOne_Upgrade_HotterFurnaces_CurrentValueText;
    private TextMeshProUGUI _refineryOne_Upgrade_HotterFurnaces_NextValueText;
    private TextMeshProUGUI _refineryOne_Upgrade_HotterFurnaces_TierText;

    private TextMeshProUGUI _refineryOne_Upgrade_LargeTanks_ButtonCostText;
    private TextMeshProUGUI _refineryOne_Upgrade_LargeTanks_CurrentValueText;
    private TextMeshProUGUI _refineryOne_Upgrade_LargeTanks_NextValueText;
    private TextMeshProUGUI _refineryOne_Upgrade_LargeTanks_TierText;

    private TextMeshProUGUI _refineryOne_Upgrade_EfficientBurning_ButtonCostText;
    private TextMeshProUGUI _refineryOne_Upgrade_EfficientBurning_CurrentValueText;
    private TextMeshProUGUI _refineryOne_Upgrade_EfficientBurning_NextValueText;
    private TextMeshProUGUI _refineryOne_Upgrade_EfficientBurning_TierText;

    private TextMeshProUGUI _refineryTwo_Upgrade_HotterFurnaces_ButtonCostText;
    private TextMeshProUGUI _refineryTwo_Upgrade_HotterFurnaces_CurrentValueText;
    private TextMeshProUGUI _refineryTwo_Upgrade_HotterFurnaces_NextValueText;
    private TextMeshProUGUI _refineryTwo_Upgrade_HotterFurnaces_TierText;

    private TextMeshProUGUI _refineryTwo_Upgrade_LargeTanks_ButtonCostText;
    private TextMeshProUGUI _refineryTwo_Upgrade_LargeTanks_CurrentValueText;
    private TextMeshProUGUI _refineryTwo_Upgrade_LargeTanks_NextValueText;
    private TextMeshProUGUI _refineryTwo_Upgrade_LargeTanks_TierText;

    private TextMeshProUGUI _refineryTwo_Upgrade_EfficientBurning_ButtonCostText;
    private TextMeshProUGUI _refineryTwo_Upgrade_EfficientBurning_CurrentValueText;
    private TextMeshProUGUI _refineryTwo_Upgrade_EfficientBurning_NextValueText;
    private TextMeshProUGUI _refineryTwo_Upgrade_EfficientBurning_TierText;

    private TextMeshProUGUI _refineryThree_Upgrade_HotterFurnaces_ButtonCostText;
    private TextMeshProUGUI _refineryThree_Upgrade_HotterFurnaces_CurrentValueText;
    private TextMeshProUGUI _refineryThree_Upgrade_HotterFurnaces_NextValueText;
    private TextMeshProUGUI _refineryThree_Upgrade_HotterFurnaces_TierText;

    private TextMeshProUGUI _refineryThree_Upgrade_LargeTanks_ButtonCostText;
    private TextMeshProUGUI _refineryThree_Upgrade_LargeTanks_CurrentValueText;
    private TextMeshProUGUI _refineryThree_Upgrade_LargeTanks_NextValueText;
    private TextMeshProUGUI _refineryThree_Upgrade_LargeTanks_TierText;

    private TextMeshProUGUI _refineryThree_Upgrade_EfficientBurning_ButtonCostText;
    private TextMeshProUGUI _refineryThree_Upgrade_EfficientBurning_CurrentValueText;
    private TextMeshProUGUI _refineryThree_Upgrade_EfficientBurning_NextValueText;
    private TextMeshProUGUI _refineryThree_Upgrade_EfficientBurning_TierText;
    #endregion

    #region "UI Elevator Variables"
    //private GameObject _elevatorSubCanvas;

    // move this to elevator controler
    private Button _elevatorButtonOnOff;
    private Image _elevatorButtonImage;
    private bool _isElevatorOn = true;
    //

    private TextMeshProUGUI _elevatorTotalRareMaterialsSoldText;

    private TextMeshProUGUI _elevatorAverageRareMaterialValueText;

    private TextMeshProUGUI _elevatorNumberOfElevatorsText;

    private TextMeshProUGUI _elevatorOneStatusText;
    private TextMeshProUGUI _elevatorOneTimerText;

    private TextMeshProUGUI _elevatorTwoStatusText;
    private TextMeshProUGUI _elevatorTwoTimerText;

    private TextMeshProUGUI _elevatorThreeStatusText;
    private TextMeshProUGUI _elevatorThreeTimerText;

    #endregion

    #region "UI Elevator Upgrade Variables"

    private TextMeshProUGUI _elevatorOne_Upgrade_FasterMotors_ButtonCostText;
    private TextMeshProUGUI _elevatorOne_Upgrade_FasterMotors_CurrentValueText;
    private TextMeshProUGUI _elevatorOne_Upgrade_FasterMotors_NextValueText;
    private TextMeshProUGUI _elevatorOne_Upgrade_FasterMotors_TierText;

    private TextMeshProUGUI _elevatorOne_Upgrade_LargerCannisters_ButtonCostText;
    private TextMeshProUGUI _elevatorOne_Upgrade_LargerCannisters_CurrentValueText;
    private TextMeshProUGUI _elevatorOne_Upgrade_LargerCannisters_NextValueText;
    private TextMeshProUGUI _elevatorOne_Upgrade_LargerCannisters_TierText;

    private TextMeshProUGUI _elevatorOne_Upgrade_MarketingStrategy_ButtonCostText;
    private TextMeshProUGUI _elevatorOne_Upgrade_MarketingStrategy_CurrentValueText;
    private TextMeshProUGUI _elevatorOne_Upgrade_MarketingStrategy_NextValueText;
    private TextMeshProUGUI _elevatorOne_Upgrade_MarketingStrategy_TierText;

    private TextMeshProUGUI _elevatorTwo_Upgrade_FasterMotors_ButtonCostText;
    private TextMeshProUGUI _elevatorTwo_Upgrade_FasterMotors_CurrentValueText;
    private TextMeshProUGUI _elevatorTwo_Upgrade_FasterMotors_NextValueText;
    private TextMeshProUGUI _elevatorTwo_Upgrade_FasterMotors_TierText;

    private TextMeshProUGUI _elevatorTwo_Upgrade_LargerCannisters_ButtonCostText;
    private TextMeshProUGUI _elevatorTwo_Upgrade_LargerCannisters_CurrentValueText;
    private TextMeshProUGUI _elevatorTwo_Upgrade_LargerCannisters_NextValueText;
    private TextMeshProUGUI _elevatorTwo_Upgrade_LargerCannisters_TierText;

    private TextMeshProUGUI _elevatorTwo_Upgrade_MarketingStrategy_ButtonCostText;
    private TextMeshProUGUI _elevatorTwo_Upgrade_MarketingStrategy_CurrentValueText;
    private TextMeshProUGUI _elevatorTwo_Upgrade_MarketingStrategy_NextValueText;
    private TextMeshProUGUI _elevatorTwo_Upgrade_MarketingStrategy_TierText;

    private TextMeshProUGUI _elevatorThree_Upgrade_FasterMotors_ButtonCostText;
    private TextMeshProUGUI _elevatorThree_Upgrade_FasterMotors_CurrentValueText;
    private TextMeshProUGUI _elevatorThree_Upgrade_FasterMotors_NextValueText;
    private TextMeshProUGUI _elevatorThree_Upgrade_FasterMotors_TierText;

    private TextMeshProUGUI _elevatorThree_Upgrade_LargerCannisters_ButtonCostText;
    private TextMeshProUGUI _elevatorThree_Upgrade_LargerCannisters_CurrentValueText;
    private TextMeshProUGUI _elevatorThree_Upgrade_LargerCannisters_NextValueText;
    private TextMeshProUGUI _elevatorThree_Upgrade_LargerCannisters_TierText;

    private TextMeshProUGUI _elevatorThree_Upgrade_MarketingStrategy_ButtonCostText;
    private TextMeshProUGUI _elevatorThree_Upgrade_MarketingStrategy_CurrentValueText;
    private TextMeshProUGUI _elevatorThree_Upgrade_MarketingStrategy_NextValueText;
    private TextMeshProUGUI _elevatorThree_Upgrade_MarketingStrategy_TierText;
    #endregion

    #region "UI Ship Upgrade Variables"

    private TextMeshProUGUI _ship_Upgrade_EfficientBoosters_ButtonCostText;
    private TextMeshProUGUI _ship_Upgrade_EfficientBoosters_CurrentValueText;
    private TextMeshProUGUI _ship_Upgrade_EfficientBoosters_NextValueText;
    private TextMeshProUGUI _ship_Upgrade_EfficientBoosters_TierText;

    private TextMeshProUGUI _ship_Upgrade_HighOctaneFuel_ButtonCostText;
    private TextMeshProUGUI _ship_Upgrade_HighOctaneFuel_CurrentValueText;
    private TextMeshProUGUI _ship_Upgrade_HighOctaneFuel_NextValueText;
    private TextMeshProUGUI _ship_Upgrade_HighOctaneFuel_TierText;

    private TextMeshProUGUI _ship_Upgrade_QualityNeodymium_ButtonCostText;
    private TextMeshProUGUI _ship_Upgrade_QualityNeodymium_CurrentValueText;
    private TextMeshProUGUI _ship_Upgrade_QualityNeodymium_NextValueText;
    private TextMeshProUGUI _ship_Upgrade_QualityNeodymium_TierText;

    private TextMeshProUGUI _ship_Upgrade_DenseMagnets_ButtonCostText;
    private TextMeshProUGUI _ship_Upgrade_DenseMagnets_CurrentValueText;
    private TextMeshProUGUI _ship_Upgrade_DenseMagnets_NextValueText;
    private TextMeshProUGUI _ship_Upgrade_DenseMagnets_TierText;

    private TextMeshProUGUI _ship_Upgrade_FasterIonization_ButtonCostText;
    private TextMeshProUGUI _ship_Upgrade_FasterIonization_CurrentValueText;
    private TextMeshProUGUI _ship_Upgrade_FasterIonization_NextValueText;
    private TextMeshProUGUI _ship_Upgrade_FasterIonization_TierText;

    private TextMeshProUGUI _ship_Upgrade_LargerCargoBays_ButtonCostText;
    private TextMeshProUGUI _ship_Upgrade_LargerCargoBays_CurrentValueText;
    private TextMeshProUGUI _ship_Upgrade_LargerCargoBays_NextValueText;
    private TextMeshProUGUI _ship_Upgrade_LargerCargoBays_TierText;

    private TextMeshProUGUI _ship_Upgrade_NanoPlating_ButtonCostText;
    private TextMeshProUGUI _ship_Upgrade_NanoPlating_CurrentValueText;
    private TextMeshProUGUI _ship_Upgrade_NanoPlating_NextValueText;
    private TextMeshProUGUI _ship_Upgrade_NanoPlating_TierText;

    #endregion

    #region "UI Resources Accessors"

    public float GetResourcesJunkValue
    {
        get => _resourcesJunkValue;
    }

    public float SetResourcesJunkValue
    {
        get => _resourcesJunkValue;
        set
        {
            _resourcesJunkValue = value;
            _resourcesJunkText.SetText(((int)value).ToString(), true);
        }
    }

    public float GetResourcesCurrencyValue
    {
        get => _resourcesCurrencyValue;
    }

    public float SetResourcesCurrencyValue
    {
        get => _resourcesCurrencyValue;
        set
        {
            _resourcesCurrencyValue = value;
            _resourcesCurrencyText.SetText(((int)value).ToString(), true);
        }
    }

    public float ResourcesRareMaterialsValue
    {
        get => _resourcesRareMaterialsValue;
        set
        {
            _resourcesRareMaterialsValue = value;
            _resourcesRareMaterialsText.SetText(((int)value).ToString(), true);
        }
    }

    public float ResourcesChipsValue
    {
        get => _resourcesChipsValue;
        set
        {
            _resourcesChipsValue = value;
            _resourcesChipsText.SetText(((int)value).ToString(), true);
        }
    }

    #endregion

    #region "Player Cargo Accessors"
    public int PlayerCargoText
    {
        set => _playerCargoText.SetText(value.ToString(), true);
    }

    public int PlayerMaxCargoText
    {
        set => _playerMaxCargoText.SetText(value.ToString(), true);
    }
    #endregion

    #region "UI_Refinery_Accessors"

    public bool IsRefineryOn => _isRefineryOn;

    public float SetTotalJunkRefined
    {
        set => _refineryTotalJunkRefinedText.SetText(((int)value).ToString(), true);
    }

    public float SetAverageJunkValue
    {
        set => _refineryAverageJunkValueText.SetText(((int)value).ToString(), true);
    }

    public int SetnumberOfRefineries
    {
        set => _refineryNumberOfRefineriesText.SetText(value.ToString(), true);
    }

    public string SetRefineryOneStatus
    {
        set => _refineryOneStatusText.SetText(value.ToString(), true);
    }
    public Color SetRefineryOneStatusColor
    {
        set => _refineryOneStatusText.color = value;
    }

    public string SetRefineryOneTimer
    {
        set => _refineryOneTimerText.SetText(value.ToString(), true);
    }

    public string SetRefineryTwoStatus
    {
        set => _refineryTwoStatusText.SetText(value.ToString(), true);
    }
    public Color SetRefineryTwoStatusColor
    {
        set => _refineryTwoStatusText.color = value;
    }

    public string SetRefineryTwoTimer
    {
        set => _refineryTwoTimerText.SetText(value.ToString(), true);
    }

    public string SetRefineryThreeStatus
    {
        set => _refineryThreeStatusText.SetText(value.ToString(), true);
    }
    public Color SetRefineryThreeStatusColor
    {
        set => _refineryThreeStatusText.color = value;
    }

    public string SetRefineryThreeTimer
    {
        set => _refineryThreeTimerText.SetText(value.ToString(), true);
    }

    #endregion

    #region "UI_RefineryOne_Upgrade_Accessors"

    public float Set_RefineryOne_Upgrade_HotterFurnaces_ButtonCost
    {
        set =>_refineryOne_Upgrade_HotterFurnaces_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_RefineryOne_Upgrade_HotterFurnaces_CurrentValue
    {
        set => _refineryOne_Upgrade_HotterFurnaces_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_RefineryOne_Upgrade_HotterFurnaces_NextValue
    {
        set => _refineryOne_Upgrade_HotterFurnaces_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_RefineryOne_Upgrade_HotterFurnaces_Tier
    {
        set => _refineryOne_Upgrade_HotterFurnaces_TierText.SetText(value, true);
    }

    public float Set_RefineryOne_Upgrade_LargeTanks_ButtonCost
    {
        set => _refineryOne_Upgrade_LargeTanks_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_RefineryOne_Upgrade_LargeTanks_CurrentValue
    {
        set => _refineryOne_Upgrade_LargeTanks_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_RefineryOne_Upgrade_LargeTanks_NextValue
    {
        set => _refineryOne_Upgrade_LargeTanks_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_RefineryOne_Upgrade_LargeTanks_Tier
    {
        set => _refineryOne_Upgrade_LargeTanks_TierText.SetText(value, true);
    }

    public float Set_RefineryOne_Upgrade_EfficientBurning_ButtonCost
    {
        set => _refineryOne_Upgrade_EfficientBurning_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_RefineryOne_Upgrade_EfficientBurning_CurrentValue
    {
        set => _refineryOne_Upgrade_EfficientBurning_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_RefineryOne_Upgrade_EfficientBurning_NextValue
    {
        set => _refineryOne_Upgrade_EfficientBurning_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_RefineryOne_Upgrade_EfficientBurning_Tier
    {
        set => _refineryOne_Upgrade_EfficientBurning_TierText.SetText(value, true);
    }

    #endregion

    #region "UI_RefineryTwo_Upgrade_Accessors"

    public float Set_RefineryTwo_Upgrade_HotterFurnaces_ButtonCost
    {
        set => _refineryTwo_Upgrade_HotterFurnaces_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_RefineryTwo_Upgrade_HotterFurnaces_CurrentValue
    {
        set => _refineryTwo_Upgrade_HotterFurnaces_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_RefineryTwo_Upgrade_HotterFurnaces_NextValue
    {
        set => _refineryTwo_Upgrade_HotterFurnaces_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_RefineryTwo_Upgrade_HotterFurnaces_Tier
    {
        set => _refineryTwo_Upgrade_HotterFurnaces_TierText.SetText(value, true);
    }

    public float Set_RefineryTwo_Upgrade_LargeTanks_ButtonCost
    {
        set => _refineryTwo_Upgrade_LargeTanks_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_RefineryTwo_Upgrade_LargeTanks_CurrentValue
    {
        set => _refineryTwo_Upgrade_LargeTanks_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_RefineryTwo_Upgrade_LargeTanks_NextValue
    {
        set => _refineryTwo_Upgrade_LargeTanks_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_RefineryTwo_Upgrade_LargeTanks_Tier
    {
        set => _refineryTwo_Upgrade_LargeTanks_TierText.SetText(value, true);
    }

    public float Set_RefineryTwo_Upgrade_EfficientBurning_ButtonCost
    {
        set => _refineryTwo_Upgrade_EfficientBurning_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_RefineryTwo_Upgrade_EfficientBurning_CurrentValue
    {
        set => _refineryTwo_Upgrade_EfficientBurning_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_RefineryTwo_Upgrade_EfficientBurning_NextValue
    {
        set => _refineryTwo_Upgrade_EfficientBurning_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_RefineryTwo_Upgrade_EfficientBurning_Tier
    {
        set => _refineryTwo_Upgrade_EfficientBurning_TierText.SetText(value, true);
    }

    #endregion

    #region "UI_RefineryThree_Upgrade_Accessors"

    public float Set_RefineryThree_Upgrade_HotterFurnaces_ButtonCost
    {
        set => _refineryThree_Upgrade_HotterFurnaces_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_RefineryThree_Upgrade_HotterFurnaces_CurrentValue
    {
        set => _refineryThree_Upgrade_HotterFurnaces_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_RefineryThree_Upgrade_HotterFurnaces_NextValue
    {
        set => _refineryThree_Upgrade_HotterFurnaces_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_RefineryThree_Upgrade_HotterFurnaces_Tier
    {
        set => _refineryThree_Upgrade_HotterFurnaces_TierText.SetText(value, true);
    }

    public float Set_RefineryThree_Upgrade_LargeTanks_ButtonCost
    {
        set => _refineryThree_Upgrade_LargeTanks_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_RefineryThree_Upgrade_LargeTanks_CurrentValue
    {
        set => _refineryThree_Upgrade_LargeTanks_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_RefineryThree_Upgrade_LargeTanks_NextValue
    {
        set => _refineryThree_Upgrade_LargeTanks_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_RefineryThree_Upgrade_LargeTanks_Tier
    {
        set => _refineryThree_Upgrade_LargeTanks_TierText.SetText(value, true);
    }

    public float Set_RefineryThree_Upgrade_EfficientBurning_ButtonCost
    {
        set => _refineryThree_Upgrade_EfficientBurning_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_RefineryThree_Upgrade_EfficientBurning_CurrentValue
    {
        set => _refineryThree_Upgrade_EfficientBurning_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_RefineryThree_Upgrade_EfficientBurning_NextValue
    {
        set => _refineryThree_Upgrade_EfficientBurning_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_RefineryThree_Upgrade_EfficientBurning_Tier
    {
        set => _refineryThree_Upgrade_EfficientBurning_TierText.SetText(value, true);
    }

    #endregion

    #region "UI_Elevator_Accessors"
    public bool IsElevatorOn => _isElevatorOn;

    public float SetTotalRareMaterialsSold
    {
        set => _elevatorTotalRareMaterialsSoldText.SetText(((int) value).ToString(), true);
    }

    public float SetAverageRareMaterialValue
    {
        set => _elevatorAverageRareMaterialValueText.SetText(((int)value).ToString(), true);
    }

    public int SetnumberOfElevators
    {
        set => _elevatorNumberOfElevatorsText.SetText(value.ToString(), true);
    }

    public string SetElevatorOneStatus
    {
        set => _elevatorOneStatusText.SetText(value.ToString(), true);
    }
    public Color SetElevatorOneStatusColor
    {
        set => _elevatorOneStatusText.color = value;
    }

    public string SetElevatorOneTimer
    {
        set => _elevatorOneTimerText.SetText(value.ToString(), true);
    }

    public string SetElevatorTwoStatus
    {
        set => _elevatorTwoStatusText.SetText(value.ToString(), true);
    }
    public Color SetElevatorTwoStatusColor
    {
        set => _elevatorTwoStatusText.color = value;
    }

    public string SetElevatorTwoTimer
    {
        set => _elevatorTwoTimerText.SetText(value.ToString(), true);
    }

    public string SetElevatorThreeStatus
    {
        set => _elevatorThreeStatusText.SetText(value.ToString(), true);
    }
    public Color SetElevatorThreeStatusColor
    {
        set => _elevatorThreeStatusText.color = value;
    }

    public string SetElevatorThreeTimer
    {
        set => _elevatorThreeTimerText.SetText(value.ToString(), true);
    }

    #endregion

    #region "UI_ElevatorOne_Upgrade_Accessors"

    public float Set_ElevatorOne_Upgrade_FasterMotors_ButtonCost
    {
        set => _elevatorOne_Upgrade_FasterMotors_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_ElevatorOne_Upgrade_FasterMotors_CurrentValue
    {
        set => _elevatorOne_Upgrade_FasterMotors_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_ElevatorOne_Upgrade_FasterMotors_NextValue
    {
        set => _elevatorOne_Upgrade_FasterMotors_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_ElevatorOne_Upgrade_FasterMotors_Tier
    {
        set => _elevatorOne_Upgrade_FasterMotors_TierText.SetText(value, true);
    }

    public float Set_ElevatorOne_Upgrade_LargerCannisters_ButtonCost
    {
        set => _elevatorOne_Upgrade_LargerCannisters_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_ElevatorOne_Upgrade_LargerCannisters_CurrentValue
    {
        set => _elevatorOne_Upgrade_LargerCannisters_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_ElevatorOne_Upgrade_LargerCannisters_NextValue
    {
        set => _elevatorOne_Upgrade_LargerCannisters_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_ElevatorOne_Upgrade_LargerCannisters_Tier
    {
        set => _elevatorOne_Upgrade_LargerCannisters_TierText.SetText(value, true);
    }

    public float Set_ElevatorOne_Upgrade_MarketingStrategy_ButtonCost
    {
        set => _elevatorOne_Upgrade_MarketingStrategy_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_ElevatorOne_Upgrade_MarketingStrategy_CurrentValue
    {
        set => _elevatorOne_Upgrade_MarketingStrategy_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_ElevatorOne_Upgrade_MarketingStrategy_NextValue
    {
        set => _elevatorOne_Upgrade_MarketingStrategy_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_ElevatorOne_Upgrade_MarketingStrategy_Tier
    {
        set => _elevatorOne_Upgrade_MarketingStrategy_TierText.SetText(value, true);
    }

    #endregion

    #region "UI_ElevatorTwo_Upgrade_Accessors"

    public float Set_ElevatorTwo_Upgrade_FasterMotors_ButtonCost
    {
        set => _elevatorTwo_Upgrade_FasterMotors_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_ElevatorTwo_Upgrade_FasterMotors_CurrentValue
    {
        set => _elevatorTwo_Upgrade_FasterMotors_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_ElevatorTwo_Upgrade_FasterMotors_NextValue
    {
        set => _elevatorTwo_Upgrade_FasterMotors_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_ElevatorTwo_Upgrade_FasterMotors_Tier
    {
        set => _elevatorTwo_Upgrade_FasterMotors_TierText.SetText(value, true);
    }

    public float Set_ElevatorTwo_Upgrade_LargerCannisters_ButtonCost
    {
        set => _elevatorTwo_Upgrade_LargerCannisters_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_ElevatorTwo_Upgrade_LargerCannisters_CurrentValue
    {
        set => _elevatorTwo_Upgrade_LargerCannisters_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_ElevatorTwo_Upgrade_LargerCannisters_NextValue
    {
        set => _elevatorTwo_Upgrade_LargerCannisters_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_ElevatorTwo_Upgrade_LargerCannisters_Tier
    {
        set => _elevatorTwo_Upgrade_LargerCannisters_TierText.SetText(value, true);
    }

    public float Set_ElevatorTwo_Upgrade_MarketingStrategy_ButtonCost
    {
        set => _elevatorTwo_Upgrade_MarketingStrategy_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_ElevatorTwo_Upgrade_MarketingStrategy_CurrentValue
    {
        set => _elevatorTwo_Upgrade_MarketingStrategy_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_ElevatorTwo_Upgrade_MarketingStrategy_NextValue
    {
        set => _elevatorTwo_Upgrade_MarketingStrategy_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_ElevatorTwo_Upgrade_MarketingStrategy_Tier
    {
        set => _elevatorTwo_Upgrade_MarketingStrategy_TierText.SetText(value, true);
    }

    #endregion

    #region "UI_ElevatorThree_Upgrade_Accessors"

    public float Set_ElevatorThree_Upgrade_FasterMotors_ButtonCost
    {
        set => _elevatorThree_Upgrade_FasterMotors_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_ElevatorThree_Upgrade_FasterMotors_CurrentValue
    {
        set => _elevatorThree_Upgrade_FasterMotors_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_ElevatorThree_Upgrade_FasterMotors_NextValue
    {
        set => _elevatorThree_Upgrade_FasterMotors_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_ElevatorThree_Upgrade_FasterMotors_Tier
    {
        set => _elevatorThree_Upgrade_FasterMotors_TierText.SetText(value, true);
    }

    public float Set_ElevatorThree_Upgrade_LargerCannisters_ButtonCost
    {
        set => _elevatorThree_Upgrade_LargerCannisters_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_ElevatorThree_Upgrade_LargerCannisters_CurrentValue
    {
        set => _elevatorThree_Upgrade_LargerCannisters_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_ElevatorThree_Upgrade_LargerCannisters_NextValue
    {
        set => _elevatorThree_Upgrade_LargerCannisters_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_ElevatorThree_Upgrade_LargerCannisters_Tier
    {
        set => _elevatorThree_Upgrade_LargerCannisters_TierText.SetText(value, true);
    }

    public float Set_ElevatorThree_Upgrade_MarketingStrategy_ButtonCost
    {
        set => _elevatorThree_Upgrade_MarketingStrategy_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_ElevatorThree_Upgrade_MarketingStrategy_CurrentValue
    {
        set => _elevatorThree_Upgrade_MarketingStrategy_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_ElevatorThree_Upgrade_MarketingStrategy_NextValue
    {
        set => _elevatorThree_Upgrade_MarketingStrategy_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_ElevatorThree_Upgrade_MarketingStrategy_Tier
    {
        set => _elevatorThree_Upgrade_MarketingStrategy_TierText.SetText(value, true);
    }

    #endregion

    #region "UI_Ship_Upgrade_Accessors"

    public float Set_Ship_Upgrade_EfficientBoosters_ButtonCost
    {
        set => _ship_Upgrade_EfficientBoosters_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_Ship_Upgrade_EfficientBoosters_CurrentValue
    {
        set => _ship_Upgrade_EfficientBoosters_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_Ship_Upgrade_EfficientBoosters_NextValue
    {
        set => _ship_Upgrade_EfficientBoosters_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_Ship_Upgrade_EfficientBoosters_Tier
    {
        set => _ship_Upgrade_EfficientBoosters_TierText.SetText(value, true);
    }

    //--

    public float Set_Ship_Upgrade_HighOctaneFuel_ButtonCost
    {
        set => _ship_Upgrade_HighOctaneFuel_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_Ship_Upgrade_HighOctaneFuel_CurrentValue
    {
        set => _ship_Upgrade_HighOctaneFuel_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_Ship_Upgrade_HighOctaneFuel_NextValue
    {
        set => _ship_Upgrade_HighOctaneFuel_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_Ship_Upgrade_HighOctaneFuel_Tier
    {
        set => _ship_Upgrade_HighOctaneFuel_TierText.SetText(value, true);
    }

    //--
    public float Set_Ship_Upgrade_QualityNeodymium_ButtonCost
    {
        set => _ship_Upgrade_QualityNeodymium_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_Ship_Upgrade_QualityNeodymium_CurrentValue
    {
        set => _ship_Upgrade_QualityNeodymium_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_Ship_Upgrade_QualityNeodymium_NextValue
    {
        set => _ship_Upgrade_QualityNeodymium_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_Ship_Upgrade_QualityNeodymium_Tier
    {
        set => _ship_Upgrade_QualityNeodymium_TierText.SetText(value, true);
    }

    //--
    public float Set_Ship_Upgrade_DenseMagnets_ButtonCost
    {
        set => _ship_Upgrade_DenseMagnets_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_Ship_Upgrade_DenseMagnets_CurrentValue
    {
        set => _ship_Upgrade_DenseMagnets_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_Ship_Upgrade_DenseMagnets_NextValue
    {
        set => _ship_Upgrade_DenseMagnets_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_Ship_Upgrade_DenseMagnets_Tier
    {
        set => _ship_Upgrade_DenseMagnets_TierText.SetText(value, true);
    }

    //--
    public float Set_Ship_Upgrade_FasterIonization_ButtonCost
    {
        set => _ship_Upgrade_FasterIonization_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_Ship_Upgrade_FasterIonization_CurrentValue
    {
        set => _ship_Upgrade_FasterIonization_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_Ship_Upgrade_FasterIonization_NextValue
    {
        set => _ship_Upgrade_FasterIonization_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_Ship_Upgrade_FasterIonization_Tier
    {
        set => _ship_Upgrade_FasterIonization_TierText.SetText(value, true);
    }

    //--
    public float Set_Ship_Upgrade_LargerCargoBays_ButtonCost
    {
        set => _ship_Upgrade_LargerCargoBays_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_Ship_Upgrade_LargerCargoBays_CurrentValue
    {
        set => _ship_Upgrade_LargerCargoBays_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_Ship_Upgrade_LargerCargoBays_NextValue
    {
        set => _ship_Upgrade_LargerCargoBays_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_Ship_Upgrade_LargerCargoBays_Tier
    {
        set => _ship_Upgrade_LargerCargoBays_TierText.SetText(value, true);
    }

    //--
    public float Set_Ship_Upgrade_NanoPlating_ButtonCost
    {
        set => _ship_Upgrade_NanoPlating_ButtonCostText.SetText(value.ToString("0"), true);
    }

    public float Set_Ship_Upgrade_NanoPlating_CurrentValue
    {
        set => _ship_Upgrade_NanoPlating_CurrentValueText.SetText(value.ToString("0.0"), true);
    }

    public float Set_Ship_Upgrade_NanoPlating_NextValue
    {
        set => _ship_Upgrade_NanoPlating_NextValueText.SetText(value.ToString("0.0"), true);
    }

    public string Set_Ship_Upgrade_NanoPlating_Tier
    {
        set => _ship_Upgrade_NanoPlating_TierText.SetText(value, true);
    }

    #endregion


    private void Awake()
    {
        //Get UI Elements Using Predefined Tags
        _resourcesJunkText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIResourcesJunkValue"));
        _resourcesCurrencyText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIResourcesCurrencyValue"));
        _resourcesRareMaterialsText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIResourcesRareMaterialsValue"));
        _resourcesChipsText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIResourcesChipsValue"));

        _playerCargoText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIPlayerCargoValue"));
        _playerMaxCargoText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIPlayerMaxCargoValue"));

        //_refinerySubCanvas = FindGameObjectTag("UIRefinerySubCanvas");
        _refineryTotalJunkRefinedText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UITotalJunkRefined"));
        _refineryAverageJunkValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIRefineryAverageMaterialValue"));
        _refineryNumberOfRefineriesText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UINumberOfRefineries"));

        _refineryButtonOnOff = FindComponentOnGameObject<Button>(FindGameObjectTag("UIRefineryButtonOnOff"));
        _refineryButtonOnOff.onClick.AddListener(TurnRefineryOnOff);
        _refineryButtonImage = FindComponentOnGameObject<Image>(FindGameObjectTag("UIRefineryButtonOnOff"));

        _elevatorTotalRareMaterialsSoldText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UITotalRareMaterialsSold"));
        _elevatorAverageRareMaterialValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIElevatorAverageMaterialValue"));
        _elevatorNumberOfElevatorsText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UINumberOfElevators"));

        //_elevatorSubCanvas = FindGameObjectTag("UIElevatorSubCanvas");
        _elevatorButtonOnOff = FindComponentOnGameObject<Button>(FindGameObjectTag("UIElevatorButtonOnOff"));
        _elevatorButtonOnOff.onClick.AddListener(TurnElevatorOnOff);
        _elevatorButtonImage = FindComponentOnGameObject<Image>(FindGameObjectTag("UIElevatorButtonOnOff"));

        _refineryOneStatusText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIRefineryOneStatus"));
        _refineryOneTimerText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIRefineryOneTimer"));

        _refineryTwoStatusText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIRefineryTwoStatus"));
        _refineryTwoTimerText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIRefineryTwoTimer"));

        _refineryThreeStatusText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIRefineryThreeStatus"));
        _refineryThreeTimerText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIRefineryThreeTimer"));

        _elevatorOneStatusText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIElevatorOneStatus"));
        _elevatorOneTimerText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIElevatorOneTimer"));

        _elevatorTwoStatusText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIElevatorTwoStatus"));
        _elevatorTwoTimerText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIElevatorTwoTimer"));

        _elevatorThreeStatusText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIElevatorThreeStatus"));
        _elevatorThreeTimerText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UIElevatorThreeTimer"));

        #region "Refinery_Upgrade_References"

        _refineryOne_Upgrade_HotterFurnaces_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryOne_Upgrade_HotterFurnaces_ButtonCost"));
        _refineryOne_Upgrade_HotterFurnaces_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryOne_Upgrade_HotterFurnaces_CurrentValue"));
        _refineryOne_Upgrade_HotterFurnaces_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryOne_Upgrade_HotterFurnaces_NextValue"));
        _refineryOne_Upgrade_HotterFurnaces_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryOne_Upgrade_HotterFurnaces_Tier"));

        _refineryOne_Upgrade_LargeTanks_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryOne_Upgrade_LargeTanks_ButtonCost"));
        _refineryOne_Upgrade_LargeTanks_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryOne_Upgrade_LargeTanks_CurrentValue"));
        _refineryOne_Upgrade_LargeTanks_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryOne_Upgrade_LargeTanks_NextValue"));
        _refineryOne_Upgrade_LargeTanks_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryOne_Upgrade_LargeTanks_Tier"));

        _refineryOne_Upgrade_EfficientBurning_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryOne_Upgrade_EfficientBurning_ButtonCost"));
        _refineryOne_Upgrade_EfficientBurning_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryOne_Upgrade_EfficientBurning_CurrentValue"));
        _refineryOne_Upgrade_EfficientBurning_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryOne_Upgrade_EfficientBurning_NextValue"));
        _refineryOne_Upgrade_EfficientBurning_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryOne_Upgrade_EfficientBurning_Tier"));

        _refineryTwo_Upgrade_HotterFurnaces_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryTwo_Upgrade_HotterFurnaces_ButtonCost"));
        _refineryTwo_Upgrade_HotterFurnaces_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryTwo_Upgrade_HotterFurnaces_CurrentValue"));
        _refineryTwo_Upgrade_HotterFurnaces_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryTwo_Upgrade_HotterFurnaces_NextValue"));
        _refineryTwo_Upgrade_HotterFurnaces_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryTwo_Upgrade_HotterFurnaces_Tier"));

        _refineryTwo_Upgrade_LargeTanks_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryTwo_Upgrade_LargeTanks_ButtonCost"));
        _refineryTwo_Upgrade_LargeTanks_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryTwo_Upgrade_LargeTanks_CurrentValue"));
        _refineryTwo_Upgrade_LargeTanks_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryTwo_Upgrade_LargeTanks_NextValue"));
        _refineryTwo_Upgrade_LargeTanks_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryTwo_Upgrade_LargeTanks_Tier"));

        _refineryTwo_Upgrade_EfficientBurning_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryTwo_Upgrade_EfficientBurning_ButtonCost"));
        _refineryTwo_Upgrade_EfficientBurning_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryTwo_Upgrade_EfficientBurning_CurrentValue"));
        _refineryTwo_Upgrade_EfficientBurning_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryTwo_Upgrade_EfficientBurning_NextValue"));
        _refineryTwo_Upgrade_EfficientBurning_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryTwo_Upgrade_EfficientBurning_Tier"));

        _refineryThree_Upgrade_HotterFurnaces_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryThree_Upgrade_HotterFurnaces_ButtonCost"));
        _refineryThree_Upgrade_HotterFurnaces_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryThree_Upgrade_HotterFurnaces_CurrentValue"));
        _refineryThree_Upgrade_HotterFurnaces_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryThree_Upgrade_HotterFurnaces_NextValue"));
        _refineryThree_Upgrade_HotterFurnaces_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryThree_Upgrade_HotterFurnaces_Tier"));

        _refineryThree_Upgrade_LargeTanks_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryThree_Upgrade_LargeTanks_ButtonCost"));
        _refineryThree_Upgrade_LargeTanks_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryThree_Upgrade_LargeTanks_CurrentValue"));
        _refineryThree_Upgrade_LargeTanks_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryThree_Upgrade_LargeTanks_NextValue"));
        _refineryThree_Upgrade_LargeTanks_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryThree_Upgrade_LargeTanks_Tier"));

        _refineryThree_Upgrade_EfficientBurning_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryThree_Upgrade_EfficientBurning_ButtonCost"));
        _refineryThree_Upgrade_EfficientBurning_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryThree_Upgrade_EfficientBurning_CurrentValue"));
        _refineryThree_Upgrade_EfficientBurning_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryThree_Upgrade_EfficientBurning_NextValue"));
        _refineryThree_Upgrade_EfficientBurning_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_RefineryThree_Upgrade_EfficientBurning_Tier"));

        #endregion

        #region "Elevator_Upgrade_References"

        _elevatorOne_Upgrade_FasterMotors_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorOne_Upgrade_FasterMotors_ButtonCost"));
        _elevatorOne_Upgrade_FasterMotors_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorOne_Upgrade_FasterMotors_CurrentValue"));
        _elevatorOne_Upgrade_FasterMotors_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorOne_Upgrade_FasterMotors_NextValue"));
        _elevatorOne_Upgrade_FasterMotors_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorOne_Upgrade_FasterMotors_Tier"));

        _elevatorOne_Upgrade_LargerCannisters_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorOne_Upgrade_LargerCannisters_ButtonCost"));
        _elevatorOne_Upgrade_LargerCannisters_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorOne_Upgrade_LargerCannisters_CurrentValue"));
        _elevatorOne_Upgrade_LargerCannisters_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorOne_Upgrade_LargerCannisters_NextValue"));
        _elevatorOne_Upgrade_LargerCannisters_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorOne_Upgrade_LargerCannisters_Tier"));

        _elevatorOne_Upgrade_MarketingStrategy_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorOne_Upgrade_MarketingStrategy_ButtonCost"));
        _elevatorOne_Upgrade_MarketingStrategy_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorOne_Upgrade_MarketingStrategy_CurrentValue"));
        _elevatorOne_Upgrade_MarketingStrategy_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorOne_Upgrade_MarketingStrategy_NextValue"));
        _elevatorOne_Upgrade_MarketingStrategy_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorOne_Upgrade_MarketingStrategy_Tier"));

        _elevatorTwo_Upgrade_FasterMotors_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorTwo_Upgrade_FasterMotors_ButtonCost"));
        _elevatorTwo_Upgrade_FasterMotors_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorTwo_Upgrade_FasterMotors_CurrentValue"));
        _elevatorTwo_Upgrade_FasterMotors_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorTwo_Upgrade_FasterMotors_NextValue"));
        _elevatorTwo_Upgrade_FasterMotors_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorTwo_Upgrade_FasterMotors_Tier"));

        _elevatorTwo_Upgrade_LargerCannisters_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorTwo_Upgrade_LargerCannisters_ButtonCost"));
        _elevatorTwo_Upgrade_LargerCannisters_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorTwo_Upgrade_LargerCannisters_CurrentValue"));
        _elevatorTwo_Upgrade_LargerCannisters_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorTwo_Upgrade_LargerCannisters_NextValue"));
        _elevatorTwo_Upgrade_LargerCannisters_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorTwo_Upgrade_LargerCannisters_Tier"));

        _elevatorTwo_Upgrade_MarketingStrategy_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorTwo_Upgrade_MarketingStrategy_ButtonCost"));
        _elevatorTwo_Upgrade_MarketingStrategy_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorTwo_Upgrade_MarketingStrategy_CurrentValue"));
        _elevatorTwo_Upgrade_MarketingStrategy_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorTwo_Upgrade_MarketingStrategy_NextValue"));
        _elevatorTwo_Upgrade_MarketingStrategy_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorTwo_Upgrade_MarketingStrategy_Tier"));

        _elevatorThree_Upgrade_FasterMotors_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorThree_Upgrade_FasterMotors_ButtonCost"));
        _elevatorThree_Upgrade_FasterMotors_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorThree_Upgrade_FasterMotors_CurrentValue"));
        _elevatorThree_Upgrade_FasterMotors_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorThree_Upgrade_FasterMotors_NextValue"));
        _elevatorThree_Upgrade_FasterMotors_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorThree_Upgrade_FasterMotors_Tier"));

        _elevatorThree_Upgrade_LargerCannisters_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorThree_Upgrade_LargerCannisters_ButtonCost"));
        _elevatorThree_Upgrade_LargerCannisters_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorThree_Upgrade_LargerCannisters_CurrentValue"));
        _elevatorThree_Upgrade_LargerCannisters_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorThree_Upgrade_LargerCannisters_NextValue"));
        _elevatorThree_Upgrade_LargerCannisters_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorThree_Upgrade_LargerCannisters_Tier"));

        _elevatorThree_Upgrade_MarketingStrategy_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorThree_Upgrade_MarketingStrategy_ButtonCost"));
        _elevatorThree_Upgrade_MarketingStrategy_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorThree_Upgrade_MarketingStrategy_CurrentValue"));
        _elevatorThree_Upgrade_MarketingStrategy_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorThree_Upgrade_MarketingStrategy_NextValue"));
        _elevatorThree_Upgrade_MarketingStrategy_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_ElevatorThree_Upgrade_MarketingStrategy_Tier"));

        #endregion

        #region "Ship_Upgrade_References"

        _ship_Upgrade_EfficientBoosters_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_EfficientBoosters_ButtonCost"));
        _ship_Upgrade_EfficientBoosters_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_EfficientBoosters_CurrentValue"));
        _ship_Upgrade_EfficientBoosters_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_EfficientBoosters_NextValue"));
        _ship_Upgrade_EfficientBoosters_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_EfficientBoosters_Tier"));

        _ship_Upgrade_HighOctaneFuel_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_HighOctaneFuel_ButtonCost"));
        _ship_Upgrade_HighOctaneFuel_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_HighOctaneFuel_CurrentValue"));
        _ship_Upgrade_HighOctaneFuel_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_HighOctaneFuel_NextValue"));
        _ship_Upgrade_HighOctaneFuel_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_HighOctaneFuel_Tier"));

        _ship_Upgrade_QualityNeodymium_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_QualityNeodymium_ButtonCost"));
        _ship_Upgrade_QualityNeodymium_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_QualityNeodymium_CurrentValue"));
        _ship_Upgrade_QualityNeodymium_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_QualityNeodymium_NextValue"));
        _ship_Upgrade_QualityNeodymium_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_QualityNeodymium_Tier"));

        _ship_Upgrade_DenseMagnets_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_DenseMagnets_ButtonCost"));
        _ship_Upgrade_DenseMagnets_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_DenseMagnets_CurrentValue"));
        _ship_Upgrade_DenseMagnets_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_DenseMagnets_NextValue"));
        _ship_Upgrade_DenseMagnets_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_DenseMagnets_Tier"));

        _ship_Upgrade_FasterIonization_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_FasterIonization_ButtonCost"));
        _ship_Upgrade_FasterIonization_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_FasterIonization_CurrentValue"));
        _ship_Upgrade_FasterIonization_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_FasterIonization_NextValue"));
        _ship_Upgrade_FasterIonization_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_FasterIonization_Tier"));

        _ship_Upgrade_LargerCargoBays_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_LargerCargoBays_ButtonCost"));
        _ship_Upgrade_LargerCargoBays_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_LargerCargoBays_CurrentValue"));
        _ship_Upgrade_LargerCargoBays_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_LargerCargoBays_NextValue"));
        _ship_Upgrade_LargerCargoBays_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_LargerCargoBays_Tier"));

        _ship_Upgrade_NanoPlating_ButtonCostText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_NanoPlating_ButtonCost"));
        _ship_Upgrade_NanoPlating_CurrentValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_NanoPlating_CurrentValue"));
        _ship_Upgrade_NanoPlating_NextValueText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_NanoPlating_NextValue"));
        _ship_Upgrade_NanoPlating_TierText = FindComponentOnGameObject<TextMeshProUGUI>(FindGameObjectTag("UI_Ship_Upgrade_NanoPlating_Tier"));
        
        #endregion
    }

    private void Start()
    {
        //SubCanvas need to be active on game start so references can be captured
        //_refinerySubCanvas.SetActive(false);
        //_elevatorSubCanvas.SetActive(false);

        //set UIRefinery One Two Three Status & Timer text
        _refineryOneStatusText.text = "|----------|";
        _refineryOneStatusText.color = Color.red;
        _refineryTwoStatusText.text = "|----------|";
        _refineryTwoStatusText.color = Color.red;
        _refineryThreeStatusText.text = "|----------|";
        _refineryThreeStatusText.color = Color.red;

        _elevatorOneStatusText.text = "|----------|";
        _elevatorOneStatusText.color = Color.red;
        _elevatorTwoStatusText.text = "|----------|";
        _elevatorTwoStatusText.color = Color.red;
        _elevatorThreeStatusText.text = "|----------|";
        _elevatorThreeStatusText.color = Color.red;

        _refineryOneTimerText.text = "--:--";
        _refineryTwoTimerText.text = "--:--";
        _refineryThreeTimerText.text = "--:--";

        _elevatorOneTimerText.text = "--:--";
        _elevatorTwoTimerText.text = "--:--";
        _elevatorThreeTimerText.text = "--:--";
    }

    //Turn Into Global Functions.
    GameObject FindGameObjectTag(string tag)
    {
        GameObject _object;

        if (_object = GameObject.FindGameObjectWithTag(tag))
        {
            if (GlobalSettings.Singleton.GlobalReferencesDebug) { Debug.Log(tag + " Tag Found, " + tag + " Reference Set"); }
            return _object;
        }

        Debug.LogWarning("[" + this.name + "]" + " Could Not Find " + tag + " Tag! If this object is 'Not Active' the tag will not be found");
        return null;
    }

    public T FindComponentOnGameObject<T>(GameObject gameObject)
    {
        T _object = gameObject.GetComponent<T>();

        if (_object != null)
        {
            if (GlobalSettings.Singleton.GlobalReferencesDebug) { Debug.Log("Component Found, Reference Set"); }
            return _object;
        }

        Debug.LogWarning("[" + this.name + "]" + " Could Not Find Component " + typeof(T).Name);
        return default(T);
    }

    private void TurnRefineryOnOff()
    {
        _isRefineryOn = !_isRefineryOn;

        if (_isRefineryOn) { _refineryButtonImage.sprite = ButtonOn; }
        else { _refineryButtonImage.sprite = ButtonOff; }
    }

    private void TurnElevatorOnOff()
    {
        _isElevatorOn = !_isElevatorOn;

        if (_isElevatorOn) { _elevatorButtonImage.sprite = ButtonOn; }
        else { _elevatorButtonImage.sprite = ButtonOff; }
    }
}
