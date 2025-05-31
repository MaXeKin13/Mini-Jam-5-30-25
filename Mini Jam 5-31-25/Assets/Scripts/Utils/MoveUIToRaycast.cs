using UnityEngine;

public class MoveUIToRaycast : MonoBehaviour
{
    public RectTransform uiElement; // UI element to move
    public Canvas canvas;           // Reference to the canvas
    public Plane plane;             // The plane to raycast against

    void Start()
    {
        // Define a plane in world space (e.g., XZ plane at y = 0)
        plane = new Plane(Vector3.up, Vector3.zero);
    }

    void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera,
            out localPoint
        );

        uiElement.localPosition = localPoint;
    }
}