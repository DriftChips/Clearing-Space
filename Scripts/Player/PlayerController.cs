using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private TouchControls _touchControls;

    private Vector3 previousPosition;
    private Vector3 lookAt;

    [SerializeField]
    private float playerSpeed = 2.0f;

    [SerializeField]
    private GameObject pivot;

    private bool _isMoving;
    private Vector2 _previousMovementInput;

    private void Awake()
    {
        _touchControls = new TouchControls();
    }

    private void Start()
    {
        previousPosition = transform.position;
    }

    private void OnEnable()
    {
        _touchControls.Enable();
    }

    private void OnDisable()
    {
        _touchControls.Disable();
    }

    void Update()
    {
        Vector2 movementInput = _touchControls.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 movementDirection = new Vector3(movementInput.y, -movementInput.x, 0.0f);
        movementDirection.Normalize();

        if (movementDirection != Vector3.zero)
        {

            previousPosition = transform.position;

            pivot.transform.Rotate(new Vector3(1, 0, 0), movementDirection.x * playerSpeed * Time.deltaTime);
            pivot.transform.Rotate(new Vector3(0, 1, 0), movementDirection.y * playerSpeed * Time.deltaTime);

            lookAt = transform.position - previousPosition;
            lookAt.Normalize();

            transform.LookAt(transform.position + lookAt, transform.up);
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Thrusters");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + (lookAt * 3), 0.2f);
    }
}
