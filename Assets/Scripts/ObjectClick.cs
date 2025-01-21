using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ObjectClick : MonoBehaviour
{
    public bool allowHighlight = true;
    public bool allowDraw = true;

   public void OnMouseDown()
   {
        if (allowHighlight) ObjectHighlighter.instance.SelectTarget(gameObject);
        if (LineDrawer.instance.drawable) LineDrawer.instance.EndDrawing();
        else if (allowDraw) LineDrawer.instance.StartDrawing(gameObject);
   }
}
