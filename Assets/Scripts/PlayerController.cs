using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DashingObject))]
public class PlayerController : MonoBehaviour
{

    private DashingObject m_dashingObject;

    private void Start()
    {
        m_dashingObject = GetComponent<DashingObject>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && m_dashingObject.CanDash())
        {
            HandleClick();
        }
    }

    private void HandleClick ()
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = worldPos - (Vector2) this.transform.position;
        dir.Normalize();
        m_dashingObject.Dash(dir);
    }
}
