using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshFromVertices : MonoBehaviour
{
    // Укажите координаты вершин меша
    public Vector3[] vertices = new Vector3[]
    {
        new Vector3(0, 0, 0), // Нижний левый
        new Vector3(1, 0, 0), // Нижний правый
        new Vector3(0, 1, 0), // Верхний левый
        new Vector3(1, 1, 0)  // Верхний правый
    };

    // Укажите треугольники меша (индексы вершин)
    public int[] triangles = new int[]
    {
        0, 2, 1, // Первый треугольник (по часовой стрелке)
        1, 2, 3  // Второй треугольник (по часовой стрелке)
    };

    // Цвета вершин (опционально)
    public Color[] vertexColors = new Color[]
    {
        Color.red,   // Нижний левый
        Color.green, // Нижний правый
        Color.blue,  // Верхний левый
        Color.yellow // Верхний правый
    };

    void Start()
    {
        // Создаем новый меш
        Mesh mesh = new Mesh
        {
            vertices = vertices, // Устанавливаем вершины
            triangles = triangles // Устанавливаем треугольники
        };

        // Опционально: добавляем цвета вершин
        if (vertexColors.Length == vertices.Length)
        {
            mesh.colors = vertexColors;
        }

        // Автоматически рассчитываем нормали для освещения
        mesh.RecalculateNormals();

        // Присваиваем меш компоненту MeshFilter
        GetComponent<MeshFilter>().mesh = mesh;
    }
}

