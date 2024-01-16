using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisController : MonoBehaviour
{
    private GlobalSettings _gs;
    private GlobalReferences _gr;

    private GameObject[] _junkPrefab;
    private GameObject _junk;
    private GameObject _player;

    private Rotate _rotateComponent;

    private Material _debrisMaterial;
    private Material[] _allDebrisMaterials;

    public event System.EventHandler OnDestroyed;

    private Vector3 _originalSpawnPosition;
    private Vector3 _junkSpawnPosition;

    private int _spawnAmount = 4;
    private float _health;
    private float _regenerateHealthPerSecond;
    private float _depleteHealthPerSecond;

    private float _radius = 5f;
    private float minSpinSpeed = 0.1f;
    private float maxSpinSpeed = 0.6f;
    private float _distance;
    private float _renderDistance = 50f;
    private float _speed = 0.5f;

    public bool DamageDebris = false;

    public float Distance
    {
        get { return _distance; }
    }

    private void Awake()
    {
        _originalSpawnPosition = transform.GetChild(0).position;
    }

    private void Start()
    {
        _gs = GlobalSettings.Singleton;
        _gr = GlobalReferences.Singleton;

        _health = _gs.DebrisMaxHealth;
        _regenerateHealthPerSecond = (_gs.DebrisMinHealth + _gs.DebrisMaxHealth) / _gs.SecondsToRegenerateHealth;
        _depleteHealthPerSecond = (_gs.DebrisMinHealth - _gs.DebrisMaxHealth) / _gs.SecondsToDepleteHealth;


        _junkPrefab = Resources.LoadAll<GameObject>("Prefabs/Junk"); // May need to split this into it's own file to load on game start
        if (_junkPrefab == null || _junkPrefab.Length == 0) { Debug.LogError("No Junk Prefabs Found! [DebrisController]"); }
        _player = _gr.Player;

        //Set second material
        _debrisMaterial = gameObject.GetComponentInChildren<Renderer>().materials[1];

        //set power and visibility
        _debrisMaterial.SetFloat("_Power", (_health / _gs.DebrisMaxHealth) * 10);
        _debrisMaterial.SetFloat("_Visibility", 1.0f - (_health / _gs.DebrisMaxHealth));
    }

    private void Update()
    {
        //calculate distance to player
        _distance = Vector3.Distance(transform.position, _player.transform.position);

        //when render distance is enabled
        if (_gs.EnableRenderDistance)
        {
            //inactivate object if too far away, activate them if close
            if (_distance > _renderDistance) { gameObject.transform.GetChild(0).gameObject.SetActive(false); }
            else { gameObject.transform.GetChild(0).gameObject.SetActive(true); }
        }

        if (DamageDebris)
        {
            _health = Mathf.Clamp(_health + _depleteHealthPerSecond * Time.deltaTime, _gs.DebrisMinHealth, _gs.DebrisMaxHealth);

            //set power and visibility
            _debrisMaterial.SetFloat("_Power", (_health / _gs.DebrisMaxHealth) * 10);
            _debrisMaterial.SetFloat("_Visibility", 1.0f - (_health / _gs.DebrisMaxHealth));
            if (_health == 0)
            {
                DestroyDebris();
            }
        }
        else 
        {
            if (_health < _gs.DebrisMaxHealth)
            {
                _health = Mathf.Clamp(_health + _regenerateHealthPerSecond * Time.deltaTime, _gs.DebrisMinHealth, _gs.DebrisMaxHealth);

                //set power and visibility
                _debrisMaterial.SetFloat("_Power", (_health / _gs.DebrisMaxHealth) * 10);
                _debrisMaterial.SetFloat("_Visibility", 1.0f - (_health / _gs.DebrisMaxHealth));
            }
        }
    }

    void FixedUpdate()
    {
        transform.GetChild(0).position = Vector3.MoveTowards(transform.GetChild(0).position, transform.position, _speed * Time.deltaTime);
    }

    private void SpawnJunk()
    {
        if (_junkPrefab.Length == 0)
        {
            Debug.LogError("There are no prefabs in the 'Object Spawner' component, on the 'Junk' game object.");
        }
        else
        {
            for (int i = 0; i < _spawnAmount; i++)
            {
                _junkSpawnPosition = transform.position + Random.onUnitSphere * _radius;

                _junk = Instantiate(_junkPrefab[Random.Range(0, _junkPrefab.Length)], _junkSpawnPosition, Quaternion.identity);
                _junk.transform.rotation = Random.rotation;
                _junk.AddComponent<JunkController>();
                _junk.tag = "Junk";
                _rotateComponent = _junk.AddComponent<Rotate>();
                _rotateComponent.xRotationSpeed = Random.Range(minSpinSpeed, maxSpinSpeed);
                _rotateComponent.yRotationSpeed = Random.Range(minSpinSpeed, maxSpinSpeed);
                _rotateComponent.zRotationSpeed = Random.Range(minSpinSpeed, maxSpinSpeed);
            }
        }

    }


    public void DestroyDebris()
    {
        OnDestroyed?.Invoke(this, System.EventArgs.Empty);
        SpawnJunk();
        Destroy(gameObject);
    }
}
