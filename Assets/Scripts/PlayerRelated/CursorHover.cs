using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHover : MonoBehaviour
{

    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D activeCursor;

    private CursorMode m_cursorMode = CursorMode.Auto;

    private void OnEnable()
    {
        ClickableObject.OnHoverEnter += HandleHoverEnter;
        ClickableObject.OnHoverExit += HandleHoverExit;
    }

    private void OnDisable()
    {
        ClickableObject.OnHoverEnter -= HandleHoverEnter;
        ClickableObject.OnHoverExit -= HandleHoverExit;
    }

    private void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, m_cursorMode);
    }

    private void HandleHoverEnter (Vector3 position)
    {
        Cursor.SetCursor(activeCursor, Vector2.zero, m_cursorMode);
    }

    private void HandleHoverExit (Vector3 position)
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, m_cursorMode);
    }
}
