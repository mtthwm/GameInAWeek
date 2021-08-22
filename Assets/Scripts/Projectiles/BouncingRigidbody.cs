using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BouncingRigidbody : MonoBehaviour
{
    public int NumBounces { get; private set; }

    private Rigidbody2D m_rb2d;
    private Vector2 m_oldVelocity;

    private void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        m_oldVelocity = m_rb2d.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        Vector2 newAngle = Vector2.Reflect(m_oldVelocity, normal);
        m_rb2d.velocity = newAngle;
        NumBounces++;
    }
}
