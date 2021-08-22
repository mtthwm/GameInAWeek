using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public delegate void MouseAction (Vector3 position);
    public static event MouseAction OnRightClick;
    public static event MouseAction OnLeftClick;
    public static event MouseAction OnHoverEnter;
    public static event MouseAction OnHoverExit;

    private bool m_mouse_hover = false;
    private bool m_left_clicked = false;
    private bool m_right_clicked = false;

    private void Update()
    {
        HandleHover();
    }

    private void HandleHover ()
    {
        if (m_mouse_hover)
        {
            if (Input.GetMouseButton(0))
            {
                if (!m_left_clicked)
                {
                    m_left_clicked = true;
                    OnLeftClick?.Invoke(MousePosition());
                }
            }
            else
            {
                m_left_clicked = false;
            }
            if (Input.GetMouseButton(1))
            {
                if (!m_right_clicked)
                {
                    OnRightClick?.Invoke(MousePosition());
                    m_right_clicked = true;
                }
            }
            else
            {
                m_right_clicked = false;
            }
        }
    }

    private void OnMouseEnter()
    {
        OnHoverEnter?.Invoke(MousePosition());
        m_mouse_hover = true;
    }

    private void OnMouseExit()
    {
        OnHoverExit?.Invoke(MousePosition());
        m_mouse_hover = false;
    }

    public static Vector3 MousePosition ()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
