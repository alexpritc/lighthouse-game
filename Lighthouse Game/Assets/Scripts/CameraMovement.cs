using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject cameraPosLeft;
    public GameObject cameraPosRight;
    public GameObject cameraPosCenter;

    public GameObject cam;
    public GameObject left;
    public GameObject right;

    private bool isMoving = false;

    private Vector3 newCamPos;

    // Start is called before the first frame update
    void Start()
    {
        cam.transform.position = cameraPosCenter.transform.position;
        cam.transform.rotation = cameraPosCenter.transform.rotation;
    }

    private void Update()
    {
        if (isMoving) 
        {
            Move(newCamPos);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == left)
        {
            if (transform.position.x <= left.transform.position.x)
            {
                newCamPos = cameraPosLeft.transform.position;
            }
            else 
            {
                newCamPos = cameraPosCenter.transform.position;
            }

            isMoving = true;
        }
        else if (other.gameObject == right)
        {
            if (transform.position.x >= right.transform.position.x)
            {
                newCamPos = cameraPosRight.transform.position;
            }
            else
            {
                newCamPos = cameraPosCenter.transform.position;
            }

            isMoving = true;
        }
    }

    void Move(Vector3 newPos) 
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, newPos, 0.01f);        

        if (cam.transform.position == newPos) 
        {
            isMoving = false;
        }
    }
}
