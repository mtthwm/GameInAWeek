using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineTo : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private float startRadius;

    //private Vector3 m_position;
    private float m_nextClearTime = 0;

    private void Update()
    {
        if (Time.time >= m_nextClearTime)
        {
            line.enabled = false;
        }
    }

    public void Draw(Vector2 to, float maxDistance = 5f, bool bounce = false)
    {
        line.enabled = true;
        m_nextClearTime = Time.time + 2f;
        Vector2 dir = to - (Vector2) this.transform.position;
        dir.Normalize();

        Vector2 origination = (Vector2)this.transform.position + dir * startRadius;
        List<Vector3> points = new List<Vector3>();
        points.Add(origination);
        
        RaycastHit2D hit = Physics2D.Raycast(origination, dir, maxDistance);
        if (hit.collider != null)
        {
            Debug.Log(hit.point);
            points.Add(hit.point);
        }
        else
        {
            points.Add((Vector2) this.transform.position + dir * maxDistance);
        }

        line.SetPositions(points.ToArray());
    }
}
