using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public new Transform camera;
    public float cameraMovementSpeed = 5f;
    public float cameraRotationSpeed = 5f;
    public float cameraZoomSpeed = 5f;

    public Transform rotationPivot;
    public Transform positionPivot;

    [SerializeField]
    private float zoomVal = 15f;

    private void Update()
    {

        HorMove();
        VerMove();
        Zoom();
        
        RotateUp();
        RotateRight();
        
    }

    void HorMove()
    {
        float value = 0;
        if (Input.GetKey(KeyCode.W))
        {
            value = cameraMovementSpeed * Time.deltaTime  * Vector3.Distance(camera.position,rotationPivot.position);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            value = -cameraMovementSpeed * Time.deltaTime * Vector3.Distance(camera.position, rotationPivot.position);
        }
        positionPivot.position += positionPivot.forward * value;


    }

    void VerMove()
    {
        float value = 0;
        if (Input.GetKey(KeyCode.A))
        {
            value = -cameraMovementSpeed * Time.deltaTime * Vector3.Distance(camera.position, rotationPivot.position);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            value = cameraMovementSpeed * Time.deltaTime * Vector3.Distance(camera.position, rotationPivot.position);
        }
        positionPivot.position +=(positionPivot.right * value);

    }

    void Zoom()
    {
        if (camera.GetComponent<Camera>().orthographic)
        {
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                camera.GetComponent<Camera>().orthographicSize+= Input.GetAxis("Mouse ScrollWheel") * -cameraZoomSpeed*3;
            }
        }
        else
        {
            float tran = 0;
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {

                tran = Input.GetAxis("Mouse ScrollWheel") * -cameraZoomSpeed;
            }
            rotationPivot.localScale += Vector3.one * tran;
        }
        
    }

    void RotateUp()
    {

        float rot =0;
        if (Input.GetKey(KeyCode.Q))
        {
            rot = cameraRotationSpeed * Time.deltaTime ;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rot = -cameraRotationSpeed * Time.deltaTime ;
        }

        positionPivot.Rotate(positionPivot.up, rot);
       
    }
    void RotateRight()
    {
        float rot = 0;
        if (Input.GetKey(KeyCode.R))
        {
            rot += cameraRotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.F))
        {
            rot = -cameraRotationSpeed * Time.deltaTime;
        }

        rotationPivot.Rotate(Vector3.right, rot);
    }
}
