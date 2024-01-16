using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//update cargo ui text
//update reference to inventory

//Updates Required: Item Class to define multiple items in inventory
public class Cargo : MonoBehaviour
{
    public AudioSource _audioSource;                //audio source
    
    private GlobalSettings _globalSettings;                     //Global settings
    private UIManager _uiManager;
    private int _cargoAmount = 100;

    private void Start()
    {
        //Set Shorter References
        _globalSettings = GlobalSettings.Singleton;
        _uiManager = UIManager.Singleton;

        //Set Inital UI Text
        _uiManager.PlayerCargoText = _cargoAmount;
        _uiManager.PlayerMaxCargoText = _globalSettings.PlayerMaxCargo;

        //Move into it's own manager
        //Get audio Component
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null) { Debug.LogError("No Audio Source Detected [Cargo]"); }
    }

    public int GetCargoAmount
    {
        get { return _cargoAmount; }
    }

    //Add more than one junk, If adding 10 junk and only 9 can be added all 10 will fail to be added.
    public bool AddCargo(int j)
    {
        //If zero or less, action has failed. adding 0 junk or negative junk will do nothing.
        if (j <= 0) { return false; }

        //If current junk and added junk is less than the max.
        if (_cargoAmount + j <= _globalSettings.PlayerMaxCargo)
        {
            //Add Junk
            _cargoAmount += j;

            //Set UI Cargo Value
            _uiManager.PlayerCargoText = _cargoAmount;

            //Action was successfull
            return true;                                        
        }
        //Action has failed
        return false;                                          
    }


    //Remove more than one junk | has issues! need confirmation that junk has been removed. If removing 10 junk and only 9 can be removed all 10 will fail to be removed.
    public bool RemoveCargo(int j)
    {
        //If zero or less, action has failed. removing 0 junk or negative junk will do nothing.
        if (j <= 0) { return false; }

        //Do we have the junk we are trying to remove
        if (_cargoAmount >= j)                   
        {
            //Remove all junk.
            _cargoAmount -= j;

            //Set UI Cargo Value
            _uiManager.PlayerCargoText = _cargoAmount;

            //Action was successfull
            return true;
        }
        //Action has failed
        return false;                               
    }
}
