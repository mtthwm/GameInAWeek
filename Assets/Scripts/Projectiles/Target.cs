using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Projectile projectile = collision.collider.gameObject.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.CleanUp();
            HandleHit();
        }
    }

    private void HandleHit ()
    {
        Debug.Log("THAT'S A HIT!");
    }
}
