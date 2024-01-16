using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//WARNING: Can Only Hold References That Do Not Change. (A Reference That Does Not Get Deleted And Recreated).
public class GlobalReferences : SingletonTemplate<GlobalReferences>
{
    private GameObject _player;
    private PlayerHealth _playerHealth;
    private Cargo _playerCargo;

    private GameObject _spaceStation;
    private GameObject _planetEarth;

    public GameObject Player
    {
        get { return _player; }
    }

    public PlayerHealth PlayerHealth
    {
        get { return _playerHealth; }
    }

    public Cargo PlayerCargo
    {
        get { return _playerCargo; }
    }

    public GameObject SpaceStation
    {
        get { return _spaceStation; }
    }

    public GameObject PlanetEarth
    {
        get { return _planetEarth; }
    }

    void Awake()
    {
        _player = FindGameObjectTag("Player");
        _playerHealth = FindComponentOnGameObject<PlayerHealth>(_player);
        _playerCargo = FindComponentOnGameObject<Cargo>(_player);

        _spaceStation = FindGameObjectTag("SpaceStation");
        _planetEarth = FindGameObjectTag("PlanetEarth");
    }

    GameObject FindGameObjectTag(string tag)
    {
        GameObject _object;

        if(_object = GameObject.FindGameObjectWithTag(tag))
        {
            if (GlobalSettings.Singleton.GlobalReferencesDebug) { Debug.Log(tag + " Tag Found, " + tag + " Reference Set"); }
            return _object;
        }

        Debug.LogError("[" + this.name + "]" + " COULD NOT FIND" + tag + "TAG!!");
        return null;
    }

    public T FindComponentOnGameObject<T>(GameObject gameObject)
    {
        T _object = gameObject.GetComponent<T>();

        if(_object != null)
        {
            if (GlobalSettings.Singleton.GlobalReferencesDebug) { Debug.Log("Component Found, Reference Set"); }
            return _object;
        }

        Debug.LogError("[" + this.name + "]" + " COULD NOT FIND COMPONENT " + typeof(T).Name);
        return default(T);
    }
}
