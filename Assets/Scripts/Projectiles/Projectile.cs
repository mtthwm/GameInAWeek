using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D m_rb2d;
    private Vector2 m_velocity;

    public void CleanUp ()
    {
        Destroy(this.gameObject);
    }

    public void Setup (Vector2 velocity)
    {
        m_velocity = velocity;
    }

    private void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
        m_rb2d.velocity = m_velocity;
    }

    private void FixedUpdate()
    {
        m_rb2d.velocity = m_rb2d.velocity.normalized * m_velocity.magnitude;
    }
}
