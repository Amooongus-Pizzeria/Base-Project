using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public float panSpeed = 10f;   // Speed at which the camera pans
    public float panBorderThickness = 10f;   // Thickness of the border around the screen where panning is triggered

    // Update is called once per frame
    void Update()
    {
        // Check for keyboard input to pan the camera
        Vector3 pos = transform.position;
        if (Input.GetKey("w"))
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        // Update the camera's position
        transform.position = pos;
    }
}
