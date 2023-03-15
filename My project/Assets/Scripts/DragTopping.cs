using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTopping : MonoBehaviour
{
    Vector2 difference = Vector2.zero; // initialize Vector2 so I can use this in a global state

    private void OnMouseDown()
    {
        Vector2 difference = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2) transform.position; 
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }
}
