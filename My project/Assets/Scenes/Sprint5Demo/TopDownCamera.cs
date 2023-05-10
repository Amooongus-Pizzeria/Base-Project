using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public float panSpeed = 20f;   // Speed at which the camera pans
    public float panBorderThickness = 10f;   // Thickness of the border around the screen where panning is triggered

    // Update is called once per frame
    void Update()
    {
        // Check for keyboard input to pan the camera
        Vector3 pos = transform.position;
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        // Update the camera's position
        transform.position = pos;
    }
}
