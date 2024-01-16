using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShipUpgradeController : MonoBehaviour
{
    [SerializeField] private Button _shipUpgradeButton;
    [SerializeField] private GameObject _shipUpgradeUI;
    [SerializeField] private Button _exitButton;


    private void Start()
    {
        _shipUpgradeUI.gameObject.SetActive(false);
    }

    private void Awake()
    {
        Button shipUpgBtn = _shipUpgradeButton.GetComponent<Button>();
        shipUpgBtn.onClick.AddListener(OpenShipUpgradeUI);
        Button exitBtn = _exitButton.GetComponent<Button>();
        exitBtn.onClick.AddListener(CloseShipUpgradeUI);
    }


    public void OpenShipUpgradeUI()
    {
        _shipUpgradeUI.gameObject.SetActive(true);
        LeanTween.moveLocal(_shipUpgradeUI, new Vector3(0f, 0f, 0f), 0.8f).setEase(LeanTweenType.easeOutQuint);
    }

    private void CloseShipUpgradeUI()
    {
        LeanTween.moveLocal(_shipUpgradeUI, new Vector3(-1380f, 0f, 0f), 0.8f).setEase(LeanTweenType.easeOutQuint).setOnComplete(() =>
        {
            _shipUpgradeUI.gameObject.SetActive(false);
        });
    }
}
