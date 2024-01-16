using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private GlobalReferences _globalReferences;
   
    private GameObject[] _debrisPrefab;
    private GameObject _debris;

    private GameObject[] _spaceStationPrefab;
    private GameObject _spaceStation;

    private List<Vector3> _clusterPositions;

    private Vector3 _spawnPosition;
    private Vector3 _spaceStationSpawnPosition;
    private bool _spawnSpaceStation = false;

    private Rotate _rotateComponent;

    private int _diskSteps;

    private float _diskMinY = 0.996f;
    private float _diskMaxY;
    private float _diskAngleStartDeg, _diskAngleRangeDeg;               //if max angle drops by 50% then max steps need to fall by 50% too.
    private float _diskHeight = 1f;
    private float _diskDebugSphereSize = 3f;

    static float Phi = Mathf.PI * (3f - Mathf.Sqrt(5f)); //golden ratio in radians
    static float Pi2 = Mathf.PI * 2;

    [Header("Default Settings")]
    [SerializeField][Tooltip("Amount of Spawnable Locations")][InspectorName("Spawn Location Count")] private int _spawnLoc = 0;
    [SerializeField][InspectorName("Spawn Radius")] private float _radius = 240f;
    [SerializeField][InspectorName("Random Seed")] private int Seed = 1;
    [SerializeField][InspectorName("Show Debug")] private bool _debug = true;
    [Space]
    [Space]
    [Header("Junk Settings")]
    [SerializeField] private float minSpinSpeed = 1.0f;
    [SerializeField] private float maxSpinSpeed = 2.0f;
    [Space]
    [Space]
    [Header("Sphere Settings")]
    [SerializeField][Range(10, 150)] private int _sphereSteps;
    [SerializeField][Range(1, 149)] private int _stationPosition = 1;
    [SerializeField][Range(0, 1)] private float _sphereMinY = 0f;
    [SerializeField][Range(0, 1)] private float _sphereMaxY = 1f;
    [SerializeField][Range(0, 360)] float _sphereAngleStartDeg = 0f;
    [SerializeField][Range(0, 360)] private float _sphereAngleRangeDeg = 360f;
    [Space]
    [Space]
    [Header("Cluster Settings")]
    [SerializeField] private int _diskStepMin = 10;
    [SerializeField] private int _diskStepMax = 70;
    [SerializeField][Range(0, 360)] private float _angleStartRange = 90f;
    [SerializeField][Range(0, 360)] private float _angleEndRange = 360;

    private void Awake()
    {
        _debrisPrefab = Resources.LoadAll<GameObject>("Prefabs/Debris"); // May need to split this into it's own file to load on game start
        _spaceStationPrefab = Resources.LoadAll<GameObject>("Prefabs/SpaceStation");
        _clusterPositions = new List<Vector3>();
        Random.InitState(Seed);
        _debug = false;
    }

    void Start()
    {
        _globalReferences = GlobalReferences.Singleton;

        if (_debrisPrefab.Length == 0)
        {
            Debug.LogError("No Debris Prefabs found on Object Spawner");
        }
        else
        {
            GenerateSpawnPoints(false);

            if (_clusterPositions == null || _clusterPositions.Count <= 0)
            {
                Debug.LogError("Cluster Position Array is NULL or EMPTY, No Debris will spawn :|: ObjectSpawner");
            }
            else
            {
                for (int i = 0; i < _clusterPositions.Count; i++)
                {
                    _debris = Instantiate(_debrisPrefab[Random.Range(0, _debrisPrefab.Length)], _clusterPositions[i], Quaternion.identity);
                    _debris.transform.parent = _globalReferences.PlanetEarth.transform;

                    _debris.transform.rotation = Random.rotation;
                    
                    //may not be needed
                    _debris.tag = "Debris";

                    _debris.AddComponent<DebrisController>();

                    _rotateComponent = _debris.AddComponent<Rotate>();
                    _rotateComponent.xRotationSpeed = Random.Range(minSpinSpeed, maxSpinSpeed);
                    _rotateComponent.yRotationSpeed = Random.Range(minSpinSpeed, maxSpinSpeed);
                    _rotateComponent.zRotationSpeed = Random.Range(minSpinSpeed, maxSpinSpeed);
                }

                if(_spawnSpaceStation) 
                {
                    //_spaceStationSpawnPosition
                    /*_spaceStation = Instantiate(_spaceStationPrefab[0], Vector3.zero, Quaternion.identity);
                    _spaceStation.transform.SetParent(_globalReferences.PlanetEarth.transform, true);
                    _spaceStation.transform.localPosition = new Vector3(-0.0406229943f, -0.0479751825f, -0.0107436618f);
                    _spaceStation.transform.localScale = new Vector3(0.0033333f, 0.0033333f, 0.0033333f);
                    _spaceStation.transform.localEulerAngles = new Vector3(356.508362f, 331.667572f, 77.424736f);*/

                }
            }
        }

    }

    private void GenerateSpawnPoints(bool debug)
    {
        for (int i = 1; i < _sphereSteps - 1; i++) //Start at 1 end -1 (removes the first and last point which overlap)
        {
            float sY = (i / (_sphereSteps - 1f) * (_sphereMaxY - _sphereMinY) + _sphereMinY) * 2f - 1f;

            var theta = Phi * i;

            if (_sphereAngleStartDeg != 0f || _sphereAngleRangeDeg != 360f)
            {
                theta = theta % Pi2;
                theta = theta < 0 ? theta + Pi2 : theta;

                var a1 = _sphereAngleStartDeg * Mathf.Deg2Rad;
                var a2 = _sphereAngleRangeDeg * Mathf.Deg2Rad;

                theta = theta * a2 / Pi2 + a1;
            }

            var radiusY = Mathf.Sqrt(1 - sY * sY);
            float sX = radiusY * Mathf.Cos(theta);
            float sZ = radiusY * Mathf.Sin(theta);

            _spawnPosition = new Vector3(sX, sY, sZ) * _radius;

            //Generate Debris Disk
            if (i != _stationPosition)
            {
                if (_debug)
                {
                    Gizmos.DrawSphere(transform.position + _spawnPosition, Mathf.Sqrt((float)_radius / (float)_sphereSteps));
                }

                _diskMaxY = Random.Range(0.999f, 1f);
                _diskAngleStartDeg = Random.Range(0f, 360f);
                _diskAngleRangeDeg = Random.Range(_angleStartRange, _angleEndRange);

                #region Calculate Max Disk Steps To Stop Overlapping
                int _newDiskStepMax = _diskStepMax;
                float _currentAngelPercent = _angleStartRange / 360; //Current angel percentage based on max angel (360) (90 / 360 = 0.25 * 100 = 25%)
                float _diskStepReduction = 1 - _currentAngelPercent; //Get percentage difference (1 - 0.25 = 0.75 * 100 = 75%)
                                                                     //if(_currentAngelPercent == 1) { _diskStepReduction = 1; }
                float _reducePercentage = (float)_newDiskStepMax * _diskStepReduction;//Percentage to reduce by
                int result = _newDiskStepMax - (int)_reducePercentage;
                _newDiskStepMax = result;
                #endregion

                _diskSteps = Random.Range(_diskStepMin, _newDiskStepMax);

                for (int j = 0; j < _diskSteps - 1; j++)
                {

                    float dY = (j / (_diskSteps - 1f) * (_diskMaxY - _diskMinY) + _diskMinY) * 2f - 1f;
                    var dTheta = Phi * j;

                    if (_diskAngleStartDeg != 0f || _diskAngleRangeDeg != 360f)
                    {
                        dTheta = dTheta % Pi2;
                        dTheta = dTheta < 0 ? dTheta + Pi2 : dTheta;

                        var a1 = _diskAngleStartDeg * Mathf.Deg2Rad;
                        var a2 = _diskAngleRangeDeg * Mathf.Deg2Rad;

                        dTheta = dTheta * a2 / Pi2 + a1;
                    }

                    float diskRadius = Mathf.Sqrt(1 - dY * dY);
                    float dX = diskRadius * Mathf.Cos(dTheta);
                    float dZ = diskRadius * Mathf.Sin(dTheta);

                    Vector3 _diskSpawnPosition = new Vector3(dX, dY - _diskHeight, dZ) * _radius;
                    Vector3 rot = Quaternion.FromToRotation(Vector3.up, (_spawnPosition).normalized).eulerAngles;
                    Vector3 _rotatedDiskSpawnPosition = RotatePointAroundPivot(transform.position + _spawnPosition + _diskSpawnPosition, transform.position + _spawnPosition, new Vector3(rot.x, rot.y, rot.z));

                    if (!_debug) { _clusterPositions.Add(_rotatedDiskSpawnPosition); }
                    else
                    {
                        _spawnLoc++;
                        Gizmos.DrawWireSphere(_rotatedDiskSpawnPosition, _diskDebugSphereSize);
                    }
                }
            }
            else //Add Station To Point
            {
                //Instansiate station
                _spawnSpaceStation = true;
                _spaceStationSpawnPosition = transform.position + _spawnPosition;

                if (_debug) { Gizmos.DrawSphere(transform.position + _spawnPosition, 35.0f); }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_debug)
        {
            Random.InitState(Seed);
            Gizmos.DrawWireSphere(transform.position, _radius);
            Gizmos.color = Color.cyan;
            _spawnLoc = 0;
            GenerateSpawnPoints(_debug);
        }
    }

    Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles) 
    {
        Vector3 dir = point - pivot; // get point direction relative to pivot
        dir = Quaternion.Euler(angles) * dir; // rotate it
        point = dir + pivot; // calculate rotated point
        return point; // return it
    }
}
