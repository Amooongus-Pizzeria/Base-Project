using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 dragOrigin;

    private void Update()
    {
        PanCamera();
    }


    private void PanCamera() {
        //save position of mouse in world space when drag starts (first time clicked)


        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

            //calculate distance between drag origin and new position if it is still held down

        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            print("origin " + dragOrigin + "newPosition " + cam.ScreenToWorldPoint(Input.mousePosition) + " = difference " + difference);

            //move the caerma by that distance

            cam.transform.position += difference;
        }
        }

}