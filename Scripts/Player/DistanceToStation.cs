using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceToStation : MonoBehaviour
{
    private GlobalReferences _globalReferences;
    private GlobalSettings _globalSettings;

    private float _distance;
    public float zSpeed = 1.0f;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Button _stationButton;

    private void Start()
    {
        _globalReferences = GlobalReferences.Singleton;
        _globalSettings = GlobalSettings.Singleton;
    }

    private void Update()
    {
        _distance = Vector3.Distance(transform.position, _globalReferences.SpaceStation.transform.position);

        if (_distance <= _globalSettings.StationTriggerDistance)
        {
            float targetZ = Mathf.Lerp(mainCamera.transform.localPosition.z, -100, zSpeed * Time.deltaTime);
            mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, targetZ);
            _stationButton.interactable = true;
            TransferPlayerCargo(_globalReferences.PlayerCargo.GetCargoAmount);
        }
        else
        {
            _stationButton.interactable = false;
            float targetZ = Mathf.Lerp(mainCamera.transform.localPosition.z, -45, zSpeed * Time.deltaTime);
            mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, targetZ);
        }
    }

    private void TransferPlayerCargo(int amount)
    {
        //If removing cargo was successfull
        if (_globalReferences.PlayerCargo.RemoveCargo(amount))
        {
            //Transfer Cargo
            UIManager.Singleton.SetResourcesJunkValue += amount;
        }
    }
}
