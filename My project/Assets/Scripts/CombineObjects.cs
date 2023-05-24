using UnityEngine;
public class CombineObjects : MonoBehaviour
{
    public Transform parentObject;

    private GameObject draggingObject;
    private Vector3 offset;

    private void OnMouseDown()
    {
        // Check if the mouse is over a game object
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            // Set the dragging object and its offset from the mouse position
            draggingObject = hit.collider.gameObject;
            offset = draggingObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDrag()
    {
        // Check if there is a dragging object
        if (draggingObject != null)
        {
            // Move the dragging object to the mouse position with the offset
            draggingObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseUp()
    {
        // Check if there is a dragging object and it is over the parent object
        if (draggingObject != null && parentObject != null && parentObject.GetComponent<Collider2D>().bounds.Contains(draggingObject.transform.position))
        {
            // Combine the dragging object with the parent object
            draggingObject.transform.parent = parentObject;
            draggingObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }

        // Reset the dragging object
        draggingObject = null;
    }
}


//hot and cold relationship

