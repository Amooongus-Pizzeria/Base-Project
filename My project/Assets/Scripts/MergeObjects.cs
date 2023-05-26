using UnityEngine;



public class MergeObjects : MonoBehaviour
{
    public GameObject mergedParent; // The parent object to merge into
    public bool isDragging; // Flag to indicate if dragging is in progress
    public Vector3 offset; // Offset between the mouse click position and the object's position



    // Start is called before the first frame update
    void Start()
    {
        mergedParent = transform.parent.gameObject; // Get the parent object
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for mouse button down event
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject) // Check if the clicked object is draggable
            {
                isDragging = true;
                offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else if (Input.GetMouseButtonUp(0)) // Check for mouse button up event
        {
            isDragging = false;
            transform.SetParent(mergedParent.transform); // Set the object's parent to the merged parent
        }



        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, 0f);
        }
    }
}
