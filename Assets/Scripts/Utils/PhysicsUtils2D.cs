using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PhysicsUtils2D : MonoBehaviour
{
    public static RaycastHit2D[] BouncingRaycast (Vector2 position, Vector2 direction, float maxDistance)
    {
        Vector2 dir = direction;
        Vector2 pos = position;
        List<RaycastHit2D> hits = new List<RaycastHit2D>();
        float distanceTravelled = 0f;
        while (distanceTravelled < maxDistance)
        {
            Debug.Log(distanceTravelled + " " + maxDistance);
            RaycastHit2D hit = Physics2D.Raycast(pos, dir, maxDistance - distanceTravelled);
            if (hit.collider != null)
            {
                distanceTravelled += hit.distance;
                pos = hit.point;
                dir = Vector2.Reflect(dir, hit.normal);
                hits.Add(hit);
            }
            else
            {
                distanceTravelled = maxDistance;
            }
        }
        return hits.ToArray();
    }

    public static void DrawBouncingRaycast (Vector2 position, Vector2 direction, float maxDistance)
    {
        RaycastHit2D[] hits = BouncingRaycast(position, direction, maxDistance);
        Vector2 lastPosition = position;
        foreach (RaycastHit2D hit in hits)
        {
            Debug.DrawLine(lastPosition, hit.point);
            lastPosition = hit.point;
        }
    }
}
