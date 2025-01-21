using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LineDrawer : MonoBehaviour
{
    public bool drawable {get; private set;}
    private GameObject currentObject;
    private LineRenderer lineRenderer;
    private int pointsCount = 0;

    public static LineDrawer instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void FixedUpdate()
    {
        // Dont calculate if not actual
        if (drawable) AddPoint();
    }

    private void AddPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // If cursor above selected object then add new points to list every frame.
            if (hit.transform.gameObject != currentObject)
            {
                if (Input.GetMouseButtonDown(0)) {EndDrawing(); }
                else return;
            }

            if (pointsCount > 1 && lineRenderer.GetPosition(pointsCount - 1) == hit.point) return; // prevent adding dublicates to list
                                                                          // will be fine change this check from point equalities to distance between points
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                // adding new points to line
                // if shift key is pressed, only the last point will be changed.
                lineRenderer.positionCount = ++pointsCount; 
            }
            lineRenderer.SetPosition(pointsCount - 1, hit.point);
        }
    }

    public void StartDrawing(GameObject target)
    {
        drawable = true;
        currentObject = target;

        // Take linerenderer or addone
        if (lineRenderer = currentObject.GetComponent<LineRenderer>()) { }
        else lineRenderer = currentObject.AddComponent<LineRenderer>();

        // Change default values
        lineRenderer.startWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Простая линия
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        AddPoint();
    }

    public void EndDrawing()
    {
        drawable = false;
        currentObject = null;
        lineRenderer = null;
        pointsCount = 0;
    }
}
