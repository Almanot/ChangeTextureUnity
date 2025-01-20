using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public bool drawable {get; private set;}
    private Vector3 startPosition;
    private GameObject currentObject;
    private LineRenderer lineRenderer;
    private int vertexIndex = 0;

    private void FixedUpdate()
    {
        // Dont calculate if not actual
        if (!drawable) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Create line renderer if it wasn`t before.
            if (!lineRenderer)
            {
                lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
                lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

                AddPoints(hit.point); // Create first line point from click position
            }
            else
            {
                // If linerenderer exist, then add new points to list every frame.
                AddPoints(hit.point);
            }
        }
    }

    public void AllowDrawing()
    {
        drawable = true;
    }

    public void ProhibitDrawing()
    {
        drawable = false;
    }

    private void AddPoints(Vector3 point)
    {
        if (lineRenderer.GetPosition(vertexIndex - 1) == point) return; // prevent adding dublicates to list
        lineRenderer.SetPosition(vertexIndex, point);
        vertexIndex++;
    }

    private void StartDrawing(GameObject obj)
    {
        drawable = true;
        currentObject = obj;

        // Создаем LineRenderer для рисования линии
        lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f; // Толщина линии в начале
        lineRenderer.endWidth = 0.05f;   // Толщина линии в конце
        lineRenderer.positionCount = 2; // Линия состоит из двух точек
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Простая линия
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, startPosition); // Вторая точка совпадает с первой
    }

    private void EndDrawing(Vector3 position)
    {
        drawable = false;

        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(1, position); // Завершаем линию на финальной точке
        }

        currentObject = null;
        lineRenderer = null;
    }
}
