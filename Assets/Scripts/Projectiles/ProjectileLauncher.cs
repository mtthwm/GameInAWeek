using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    public void Fire (Vector2 start, Vector2 velocity)
    {
        Instantiate(projectilePrefab, start, Quaternion.identity).GetComponent<Projectile>().Setup(velocity);
    }
}
