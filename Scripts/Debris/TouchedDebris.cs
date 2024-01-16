using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(LineRenderer))]
public class TouchedDebris : MonoBehaviour
{
    private AudioSource _laser;

    private TouchControls _touchControls;
    private LineRenderer _lineRenderer;
    private DebrisController _debris;
    private Transform _hitTransform;

    private float _laserRange = 20f;

    private bool _laserEnabled = false;
    [SerializeField] private bool _debugLaser = true;

    public GameObject Firepoint;
    public float Distance;

    Vector2 position;
    RaycastHit hit;
    Ray ray;

    private void Awake()
    {
        _touchControls = new TouchControls();
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
        _laser = GetComponent<AudioSource>();
    }



    private void OnEnable()
    {
        _touchControls.Enable();
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += StartTouch;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerMove += DuringTouch;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp += EndTouch;
    }

    private void OnDisable()
    {
        _touchControls.Disable();
        EnhancedTouchSupport.Disable();
        TouchSimulation.Disable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= StartTouch;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerMove -= DuringTouch;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp -= EndTouch;
    }

    private void Update()
    {
        if(_debugLaser) 
        { 
            //Debug.DrawCircle(transform.position, transform.rotation, _laserRange, 32, Color.magenta);
        }
        
        if(_laserEnabled)
        {
            SetLineRendererPos(0, transform.position);
            if (_hitTransform) { SetLineRendererPos(1, _hitTransform.position); }
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
        

        //new way of checking for null (is null) or (is not null) very readable
        if (_debris is not null)
        { 
            //when the distance between the player and debris is greater than the range of the laser.
            if(_debris.Distance > _laserRange)
            {
                DisableDamage();
                DisableLaser();
                _debris.OnDestroyed -= _debris_OnDestroyed;
            }
        }
    }

    private void StartTouch(Finger finger)
    {
        //if we were firing at a previous piece of debris
        DisableDamage();
        DisableLaser();
        //Get position
        position = _touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        ray = Camera.main.ScreenPointToRay(position);

        //Cast Ray
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Did we hit Debris
            if (hit.transform.parent.CompareTag("Debris"))
            {
                //Does debris have a controller (if not error)
                if(_debris = hit.transform.parent.GetComponent<DebrisController>())
                {
                    if (_debris.Distance < _laserRange)
                    {
                        _hitTransform = hit.transform;

                        EnableDamage();

                        GetComponent<AudioSource>().Play();

                        EnableLaser(_hitTransform.position); //hit.point

                        //subscribe to debris death event
                        _debris.OnDestroyed += _debris_OnDestroyed;
                    }
                } 
                else { Debug.LogError("Debris Controller Not Found! [TouchedDebris]"); }
            }
        }
    }

    private void _debris_OnDestroyed(object sender, EventArgs e)
    {
        //StartCoroutine(StopLaserAudioCouroutine());
        GetComponent<AudioSource>().Stop();
        DisableLaser();
        FindObjectOfType<AudioManager>().Play("SizzlingFadeOut");
        //No need to disable damange as debris has been destroyed, set to null for good measure
        _debris = null;
    }

    private void EnableLaser(Vector3 vec)
    {
        _lineRenderer.enabled = true;
        SetLineRendererPos(1, vec);
        _laserEnabled = true;
    }

    private void DisableLaser()
    {
        _laserEnabled = false;
        _lineRenderer.enabled = false;
        SetLineRendererPos(1, Vector3.zero);
    }

    // tried to get the audio to stop only when the loop is complete to avoid popping noise. For some reason it works the first time, but stops the audio early other times.

    /*IEnumerator StopLaserAudioCouroutine()
    {
        yield return new WaitForSeconds(_laser.clip.length);
        _laser.Stop();
    }*/

    private void EnableDamage()
    {
        if (_debris != null) { _debris.DamageDebris = true; }
    }

    private void DisableDamage()
    {
        if (_debris != null) { _debris.DamageDebris = false; }
    }

    private void DuringTouch(Finger finger)
    {
    }

    private void EndTouch(Finger finger)
    {
    }

    private void SetLineRendererPos(int index, Vector3 pos)
    {
        if (_lineRenderer.enabled) { _lineRenderer.SetPosition(index, pos); }
    }
}
