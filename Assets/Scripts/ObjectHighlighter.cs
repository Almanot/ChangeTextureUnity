using UnityEngine;

public class ObjectHighlighter : MonoBehaviour
{
    [SerializeField] private Color highlightColor = new Color(255, 220, 143);
    private Color defaultColor;
    private GameObject selectedObject;
    #region singleton
    public static ObjectHighlighter instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    // Change color to default before highlight new target.
    public void SelectTarget(GameObject target)
    {
        if (!selectedObject) // no target
        {
            selectedObject = target;
            defaultColor = target.GetComponent<Renderer>().material.color;
            ChangeColor(highlightColor);
        }
        else if (target != selectedObject) // target changed
        {
            ChangeColor(defaultColor);
            selectedObject = target;
            ChangeColor(highlightColor);
        }
        else // target canceled
        {
            ChangeColor(defaultColor);
            selectedObject = null;
        }
    }

    void ChangeColor(Color toColor)
    {
        Renderer renderer = selectedObject.GetComponent<Renderer>();
      
        if (!renderer) return;

        renderer.material.color = toColor;
    }
}