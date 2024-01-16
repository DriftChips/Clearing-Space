using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;

public class RefineryUIController : MonoBehaviour
{
    [SerializeField] private TouchControls _touchControls;
    [SerializeField] private Camera _mainCamera;

    [SerializeField] private GameObject _refineryCanvas;
    [SerializeField] private List<Refinery> _refineries;
    [SerializeField] private List<GameObject> _refineryFrame;
    [SerializeField] private List<GameObject> _refineryUpgradeBoxParent;
    [SerializeField] private List<GameObject> _refineryUpgradeUnlockBox;
    //[SerializeField] private List<GameObject> _refineryUpgradeButton;
    [SerializeField] private Button _refineryExitButton, _refineryNextUpgradeBox, _refineryPreviousUpgradeBox;

    private int _currentRefineryUpgradeBoxIndex = 0;
    private int _previousRefineryUpgradeBoxIndex = -1;

    private bool _isMoving = false;

    private void Start()
    {
        _refineryCanvas.gameObject.SetActive(false);
    }

    private void Awake()
    {
        _touchControls = new TouchControls();

        Button refExitBtn = _refineryExitButton.GetComponent<Button>();
        refExitBtn.onClick.AddListener(ExitRefineryUI);

        Button refNextBtn = _refineryNextUpgradeBox.GetComponent<Button>();
        refNextBtn.onClick.AddListener(NextRefinerySelectionBox);
        Button refPrevBtn = _refineryPreviousUpgradeBox.GetComponent<Button>();
        refPrevBtn.onClick.AddListener(PreviousRefinerySelectionBox);

        Button unlockRefineryOne = _refineryUpgradeUnlockBox[0].GetComponent<Button>();
        unlockRefineryOne.onClick.AddListener(UnlockRefineryOne);
        Button unlockRefineryTwo = _refineryUpgradeUnlockBox[1].GetComponent<Button>();
        unlockRefineryTwo.onClick.AddListener(UnlockRefineryTwo);
        Button unlockRefineryThree = _refineryUpgradeUnlockBox[2].GetComponent<Button>();
        unlockRefineryThree.onClick.AddListener(UnlockRefineryThree);
    }

    private void OnEnable()
    {
        _touchControls.Enable();
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += StartTouch;
    }

    private void StartTouch(Finger finger)
    {
        Vector2 position = _touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out RaycastHit hit))       //Sends a ray on StartTouch to see if it hits object with tag "Clickable"
        {
            if (hit.collider.tag == "Refinery")
            {
                _refineryCanvas.gameObject.SetActive(true);        // Sets the canvas to active and animates it
                LeanTween.moveLocal(_refineryCanvas, new Vector3(0f, 0f, 0f), 0.8f).setEase(LeanTweenType.easeOutQuint);
            }

        }
        //else { Debug.Log("Nothing Hit!"); }
    }

    private void ExitRefineryUI()
    {
        Debug.Log("Tweening begun");
        LeanTween.moveLocal(_refineryCanvas, new Vector3(0f, -2712f, 0f), 0.8f).setEase(LeanTweenType.easeOutQuint).setOnComplete(DisableRefineryUI);
    }

    void DisableRefineryUI()
    {
        _refineryCanvas.gameObject.SetActive(false);
    }

    private void NextRefinerySelectionBox()
    {
        if (_isMoving)
        {
            StartCoroutine(WaitAndTryAgain());
            return;
        }

        _previousRefineryUpgradeBoxIndex = _currentRefineryUpgradeBoxIndex;

        // Calculate the index of the next UI element with % being the remainder, this allows us to loop round again. For example if the current index is 1, then: (1+1) / 3 = 0 with a remainder of 2 (next index = 2)
        int nextIndex = (_currentRefineryUpgradeBoxIndex + 1) % _refineryUpgradeBoxParent.Count;

        // Move the current UI element to the left and deactivate it
        _isMoving = true;
        LeanTween.moveLocal(_refineryUpgradeBoxParent[_currentRefineryUpgradeBoxIndex], new Vector3(-1200f, 51.8f, 0f), 0.8f).setEase(LeanTweenType.easeOutQuint).setOnComplete(() => {
            _isMoving = false;
            DeactivatePreviousUIElement();
        });

        // Activate and move the next UI element to the center
        _refineryUpgradeBoxParent[nextIndex].SetActive(true);
        _refineryUpgradeBoxParent[nextIndex].transform.localPosition = new Vector3(1200f, 51.8f, 0f);
        LeanTween.moveLocal(_refineryUpgradeBoxParent[nextIndex], new Vector3(0f, 51.8f, 0f), 0.8f).setEase(LeanTweenType.easeOutQuint);

        // Update the index of the current UI element
        _currentRefineryUpgradeBoxIndex = nextIndex;
    }

    private void PreviousRefinerySelectionBox()
    {
        if (_isMoving)
        {
            StartCoroutine(WaitAndTryAgain());
            return;
        }

        _previousRefineryUpgradeBoxIndex = _currentRefineryUpgradeBoxIndex;

        // Calculate the index of the previous UI element
        int prevIndex = (_currentRefineryUpgradeBoxIndex - 1 + _refineryUpgradeBoxParent.Count) % _refineryUpgradeBoxParent.Count;

        // Move the current UI element to the right and deactivate it
        _isMoving = true;
        LeanTween.moveLocal(_refineryUpgradeBoxParent[_currentRefineryUpgradeBoxIndex], new Vector3(1200f, 51.8f, 0f), 0.8f).setEase(LeanTweenType.easeOutQuint).setOnComplete(() =>
        {
            _isMoving = false;
            DeactivateNextUIElement();
        });

        // Activate and move the previous UI element to the center
        _refineryUpgradeBoxParent[prevIndex].SetActive(true);
        _refineryUpgradeBoxParent[prevIndex].transform.localPosition = new Vector3(-1200f, 51.8f, 0f);
        LeanTween.moveLocal(_refineryUpgradeBoxParent[prevIndex], new Vector3(0f, 51.8f, 0f), 0.8f).setEase(LeanTweenType.easeOutQuint);

        // Update the index of the current UI element
        _currentRefineryUpgradeBoxIndex = prevIndex;
    }

    private IEnumerator WaitAndTryAgain()
    {
        yield return new WaitForSeconds(0.1f);
        NextRefinerySelectionBox();
    }

    private void DeactivateNextUIElement()
    {
        _refineryUpgradeBoxParent[(_currentRefineryUpgradeBoxIndex + 1) % _refineryUpgradeBoxParent.Count].transform.localPosition = new Vector3(-1200f, 51.8f, 0f);
        _refineryUpgradeBoxParent[(_currentRefineryUpgradeBoxIndex + 1) % _refineryUpgradeBoxParent.Count].SetActive(false);
    }

    private void DeactivatePreviousUIElement()
    {
        
        _refineryUpgradeBoxParent[(_currentRefineryUpgradeBoxIndex - 1 + _refineryUpgradeBoxParent.Count) % _refineryUpgradeBoxParent.Count].transform.localPosition = new Vector3(1200f, 51.8f, 0f);
        _refineryUpgradeBoxParent[(_currentRefineryUpgradeBoxIndex - 1 + _refineryUpgradeBoxParent.Count) % _refineryUpgradeBoxParent.Count].SetActive(false);
    }

    private void UnlockRefineryOne()
    {
        //Costs Junk
        if (UIManager.Singleton.GetResourcesJunkValue >= 10)
        {
            UIManager.Singleton.SetResourcesJunkValue -= 10;
            Destroy(_refineryUpgradeUnlockBox[0]);
            _refineries[0].gameObject.SetActive(true);
            _refineryFrame[0].gameObject.SetActive(false);
            _refineryFrame[1].gameObject.SetActive(true);
        }
    }

    private void UnlockRefineryTwo()
    {
        //Costs Currency
        if (UIManager.Singleton.GetResourcesCurrencyValue >= 10)
        {
            UIManager.Singleton.SetResourcesCurrencyValue -= 10;
            Destroy(_refineryUpgradeUnlockBox[1]);
            _refineries[1].gameObject.SetActive(true);
            _refineryFrame[1].gameObject.SetActive(false);
            _refineryFrame[2].gameObject.SetActive(true);
        }
    }

    private void UnlockRefineryThree()
    {
        //Costs Currency 
        if (UIManager.Singleton.GetResourcesCurrencyValue >= 10)
        {
            UIManager.Singleton.SetResourcesCurrencyValue -= 10;
            Destroy(_refineryUpgradeUnlockBox[2]);
            _refineries[2].gameObject.SetActive(true);
            _refineryFrame[2].gameObject.SetActive(false);
        }
    }
}
