using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//updated
public class Rotate : MonoBehaviour
{
    private Vector3 rotationVector;

    //changed to public//

    [SerializeField]
    private bool rotate = true;

    public float xRotationSpeed = 0.5f;
    public float yRotationSpeed = 0.0f;
    public float zRotationSpeed = 1.0f;


    private void Start()
    {
        rotationVector = new Vector3(xRotationSpeed * Time.deltaTime, yRotationSpeed * Time.deltaTime, zRotationSpeed * Time.deltaTime);
    }


    private void Update()
    {
        if (rotate)
        {
            transform.Rotate(rotationVector);
        }
 
    }
}
