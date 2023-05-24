using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceMouseController : MonoBehaviour
{

    [SerializeField] private GameObject slicePrefab;
    private Vector2 startPoint;
    private LineRenderer lineRenderer;
    private bool isDrawing = false;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, startPoint);
            lineRenderer.enabled = true;
            isDrawing = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
            lineRenderer.enabled = false;
        }

        if (isDrawing)
        {
            Vector2 currentPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(1, currentPoint);
        }
    }
}
