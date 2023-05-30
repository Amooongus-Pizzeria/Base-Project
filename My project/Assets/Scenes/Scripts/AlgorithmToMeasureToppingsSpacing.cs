using UnityEngine;

public class AlgorithmToMeasureToppings : MonoBehaviour
{
    private bool isDragging = false;
    private GameObject draggedObject;
    private GameObject combinedObject;
    private float dragDistanceThreshold = 0.1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.CompareTag("Draggable"))
            {
                isDragging = true;
                draggedObject = hit.collider.gameObject;
            }
        }

        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            draggedObject.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                isDragging = false;

                Collider2D[] colliders = Physics2D.OverlapCircleAll(draggedObject.transform.position, dragDistanceThreshold);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject != draggedObject && collider.gameObject.CompareTag("Draggable"))
                    {
                        CombineObjects(draggedObject, collider.gameObject);
                        break;
                    }
                }

                draggedObject = null;
            }
        }
    }

    void CombineObjects(GameObject obj1, GameObject obj2)
    {
        Vector3 combinedPosition = (obj1.transform.position + obj2.transform.position) / 2f;
        combinedObject = new GameObject("CombinedObject");
        combinedObject.transform.position = combinedPosition;

        obj1.transform.SetParent(combinedObject.transform);
        obj2.transform.SetParent(combinedObject.transform);
    }

    public float GetDistanceBetweenObjects(GameObject obj1, GameObject obj2)
    {
        if (obj1 != null && obj2 != null)
        {
            return Vector3.Distance(obj1.transform.position, obj2.transform.position);
        }

        return 0f;
    }
}
