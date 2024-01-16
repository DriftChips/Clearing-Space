using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToStationPointer : MonoBehaviour
{
    private GameObject _spaceStation;
    private GameObject _spaceShip;

    [SerializeField] private float radius = 250.0f;
    [SerializeField] private Transform arrowPrefab;

    private LineRenderer _lineRenderer;
    [SerializeField] private int _linePositionCount = 50;
    private Transform arrowInstance;


    void Start()
    {
        _spaceStation = GameObject.FindGameObjectWithTag("SpaceStation");
        _spaceShip = GameObject.FindGameObjectWithTag("Ship");

        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _linePositionCount;

        arrowInstance = Instantiate(arrowPrefab, _spaceStation.transform.position, Quaternion.identity);
    }

    void Update()
    {
        for (int i = 0; i < _lineRenderer.positionCount; i++)
        {
            float t = (float)i / (float)(_lineRenderer.positionCount - 1);
            Vector3 pos = GetQuadraticCurvePoint(_spaceShip.transform.position, Vector3.zero, _spaceStation.transform.position, t);
            pos = pos.normalized * radius;
            _lineRenderer.SetPosition(i, pos);
        }

        arrowInstance.position = _spaceShip.transform.position;
        arrowInstance.rotation = Quaternion.LookRotation(_lineRenderer.GetPosition(1) - arrowInstance.position);
    }

    Vector3 GetQuadraticCurvePoint(Vector3 start, Vector3 control, Vector3 end, float t)
    {
        Vector3 curvePoint = (1 - t) * (1 - t) * start + 2 * (1 - t) * t * control + t * t * end;
        return curvePoint;
    }
}
