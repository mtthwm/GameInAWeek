using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DashingObject), typeof(DrawLineTo), typeof(ProjectileLauncher))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float projectileRadius = 1f;
    [SerializeField] private float projectileSpeed = 5f;

    private DashingObject m_dashingObject;
    private ProjectileLauncher m_projectileLauncher;
    private DrawLineTo m_drawLine;

    private void Start()
    {
        m_dashingObject = GetComponent<DashingObject>();
        m_drawLine = GetComponent<DrawLineTo>();
        m_projectileLauncher = GetComponent<ProjectileLauncher>();
    }

    private void OnEnable()
    {
        ClickableObject.OnRightClick += HandleRightClick;
        ClickableObject.OnLeftClick += HandleHover;
    }

    private void OnDisable()
    {
        ClickableObject.OnRightClick -= HandleRightClick;
        ClickableObject.OnLeftClick -= HandleHover;
    }

    private void HandleHover (Vector3 position)
    {
        //m_drawLine.Draw(position);
        Vector2 dir = position - this.transform.position;
        dir.Normalize();
        //PhysicsUtils2D.BouncingRaycast(this.transform.position, dir, 5f);
        //PhysicsUtils2D.BouncingRaycast(this.transform.position, dir, 5f);
    }

    private void HandleRightClick (Vector3 position)
    {
        Vector2 dir = position - this.transform.position;
        dir.Normalize();
        m_dashingObject.Dash(dir);
    }

    private void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 position = ClickableObject.MousePosition();
            Vector2 dir = position - this.transform.position;
            dir.Normalize();
            m_projectileLauncher.Fire((Vector2)this.transform.position + dir * projectileRadius, dir * projectileSpeed);
        }
    }
}
