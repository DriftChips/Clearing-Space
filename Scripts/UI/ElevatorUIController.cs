using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;

public class ElevatorUIController : MonoBehaviour
{
    [SerializeField] private TouchControls _touchControls;
    [SerializeField] private Camera _mainCamera;

    [SerializeField] private GameObject _elevatorCanvas;
    [SerializeField] private List<Elevator> _elevators;
    [SerializeField] private List<GameObject> _elevatorFrame;
    [SerializeField] private List<GameObject> _elevatorUpgradeBoxParent;
    [SerializeField] private List<GameObject> _elevatorUpgradeUnlockBox;
    [SerializeField] private Button _elevatorExitButton, _elevatorPreviousButton, _elevatorNextButton;

    private int _currentElevatorUpgradeBoxIndex = 0;
    private int _previousElevatorUpgradeBoxIndex = -1;

    private bool _isMoving = false;

    private void Start()
    {
        _elevatorCanvas.gameObject.SetActive(false);
    }

    private void Awake()
    {
        _touchControls = new TouchControls();

        Button elvExitBtn = _elevatorExitButton.GetComponent<Button>();
        elvExitBtn.onClick.AddListener(ExitElevatorUI);

        Button elvNextBtn = _elevatorNextButton.GetComponent<Button>();
        elvNextBtn.onClick.AddListener(NextElevatorSelectionBox);
        Button elvPreviousBtn = _elevatorPreviousButton.GetComponent<Button>();
        elvPreviousBtn.onClick.AddListener(PreviousElevatorSelectionBox);

        Button unlockElevatorOne = _elevatorUpgradeUnlockBox[0].GetComponent<Button>();
        unlockElevatorOne.onClick.AddListener(UnlockElevatorOne);
        Button unlockElevatorTwo = _elevatorUpgradeUnlockBox[1].GetComponent<Button>();
        unlockElevatorTwo.onClick.AddListener(UnlockElevatorTwo);
        Button unlockElevatorThree = _elevatorUpgradeUnlockBox[2].GetComponent<Button>();
        unlockElevatorThree.onClick.AddListener(UnlockElevatorThree);
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
            if (hit.collider.tag == "Elevator")
            {
                _elevatorCanvas.gameObject.SetActive(true);        // Sets the canvas to active and animates it
                LeanTween.moveLocal(_elevatorCanvas, new Vector3(0f, 0f, 0f), 0.8f).setEase(LeanTweenType.easeOutQuint);
            }
        }
        //else { Debug.Log("Nothing Hit!"); }
    }

    private void ExitElevatorUI()
    {
        //Debug.Log("The Button Was Clicked");
        LeanTween.moveLocal(_elevatorCanvas, new Vector3(0f, -2712f, 0f), 0.8f).setEase(LeanTweenType.easeOutQuint).setOnComplete(DisableElevvatorUI);
    }

    void DisableElevvatorUI()
    {
        _elevatorCanvas.gameObject.SetActive(false);
    }

    private void NextElevatorSelectionBox()
    {
        if (_isMoving)
        {
            StartCoroutine(WaitAndTryAgain());
            return;
        }

        _previousElevatorUpgradeBoxIndex = _currentElevatorUpgradeBoxIndex;

        // Calculate the index of the next UI element with % being the remainder, this allows us to loop round again. For example if the current index is 1, then: (1+1) / 3 = 0 with a remainder of 2 (next index = 2)
        int nextIndex = (_currentElevatorUpgradeBoxIndex + 1) % _elevatorUpgradeBoxParent.Count;

        // Move the current UI element to the left and deactivate it
        _isMoving = true;
        LeanTween.moveLocal(_elevatorUpgradeBoxParent[_currentElevatorUpgradeBoxIndex], new Vector3(-1200f, 51.8f, 0f), 0.8f).setEase(LeanTweenType.easeOutQuint).setOnComplete(() => {
            _isMoving = false;
            DeactivatePreviousUIElement();
        });

        // Activate and move the next UI element to the center
        _elevatorUpgradeBoxParent[nextIndex].SetActive(true);
        _elevatorUpgradeBoxParent[nextIndex].transform.localPosition = new Vector3(1200f, 51.8f, 0f);
        LeanTween.moveLocal(_elevatorUpgradeBoxParent[nextIndex], new Vector3(0f, 51.8f, 0f), 0.8f).setEase(LeanTweenType.easeOutQuint);

        // Update the index of the current UI element
        _currentElevatorUpgradeBoxIndex = nextIndex;
    }

    private void PreviousElevatorSelectionBox()
    {
        if (_isMoving)
        {
            StartCoroutine(WaitAndTryAgain());
            return;
        }

        _previousElevatorUpgradeBoxIndex = _currentElevatorUpgradeBoxIndex;

        // Calculate the index of the previous UI element
        int prevIndex = (_currentElevatorUpgradeBoxIndex - 1 + _elevatorUpgradeBoxParent.Count) % _elevatorUpgradeBoxParent.Count;

        // Move the current UI element to the right and deactivate it
        _isMoving = true;
        LeanTween.moveLocal(_elevatorUpgradeBoxParent[_currentElevatorUpgradeBoxIndex], new Vector3(1200f, 51.8f, 0f), 0.8f).setEase(LeanTweenType.easeOutQuint).setOnComplete(() =>
        {
            _isMoving = false;
            DeactivateNextUIElement();
        });

        // Activate and move the previous UI element to the center
        _elevatorUpgradeBoxParent[prevIndex].SetActive(true);
        _elevatorUpgradeBoxParent[prevIndex].transform.localPosition = new Vector3(-1200f, 51.8f, 0f);
        LeanTween.moveLocal(_elevatorUpgradeBoxParent[prevIndex], new Vector3(0f, 51.8f, 0f), 0.8f).setEase(LeanTweenType.easeOutQuint);

        // Update the index of the current UI element
        _currentElevatorUpgradeBoxIndex = prevIndex;
    }

    private IEnumerator WaitAndTryAgain()
    {
        yield return new WaitForSeconds(0.1f);
        NextElevatorSelectionBox();
    }

    private void DeactivateNextUIElement()
    {
        _elevatorUpgradeBoxParent[(_currentElevatorUpgradeBoxIndex + 1) % _elevatorUpgradeBoxParent.Count].transform.localPosition = new Vector3(-1200f, 51.8f, 0f);
        _elevatorUpgradeBoxParent[(_currentElevatorUpgradeBoxIndex + 1) % _elevatorUpgradeBoxParent.Count].SetActive(false);
    }

    private void DeactivatePreviousUIElement()
    {
        _elevatorUpgradeBoxParent[(_currentElevatorUpgradeBoxIndex - 1 + _elevatorUpgradeBoxParent.Count) % _elevatorUpgradeBoxParent.Count].transform.localPosition = new Vector3(1200f, 51.8f, 0f);
        _elevatorUpgradeBoxParent[(_currentElevatorUpgradeBoxIndex - 1 + _elevatorUpgradeBoxParent.Count) % _elevatorUpgradeBoxParent.Count].SetActive(false);
    }

    private void UnlockElevatorOne()
    {
        //Costs Junk
        if (UIManager.Singleton.GetResourcesJunkValue >= 10)
        {
            UIManager.Singleton.SetResourcesJunkValue -= 10;
            Destroy(_elevatorUpgradeUnlockBox[0]);
            _elevators[0].gameObject.SetActive(true);
            _elevatorFrame[0].gameObject.SetActive(false);
            _elevatorFrame[1].gameObject.SetActive(true);
        }
    }

    private void UnlockElevatorTwo()
    {
        //Costs Currency
        if (UIManager.Singleton.GetResourcesCurrencyValue >= 10)
        {
            UIManager.Singleton.SetResourcesCurrencyValue -= 10;
            Destroy(_elevatorUpgradeUnlockBox[1]);
            _elevators[1].gameObject.SetActive(true);
            _elevatorFrame[1].gameObject.SetActive(false);
            _elevatorFrame[2].gameObject.SetActive(true);
        }
    }

    private void UnlockElevatorThree()
    {
        //Costs Currency 
        if (UIManager.Singleton.GetResourcesCurrencyValue >= 10)
        {
            UIManager.Singleton.SetResourcesCurrencyValue -= 10;
            Destroy(_elevatorUpgradeUnlockBox[2]);
            _elevators[2].gameObject.SetActive(true);
            _elevatorFrame[2].gameObject.SetActive(false);
        }
    }
}
