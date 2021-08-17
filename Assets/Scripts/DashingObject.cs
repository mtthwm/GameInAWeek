using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DashingObject : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject spriteObject;

    private Rigidbody2D m_rb2d;
    private bool m_dashing = false;
    private Vector2 m_direction = new Vector3(0f, 1f, 0f);



    private void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_dashing = false;
    }

    private void Update()
    {
        if (m_dashing)
        {
            m_rb2d.velocity = m_direction * speed;
        } else
        {
            m_rb2d.velocity = Vector3.zero;
            spriteObject.transform.localScale = Vector3.one;
        }
    }

    
    private void StretchSprite (Vector2 direction, float amount)
    {
        Vector3 scale = spriteObject.transform.localScale;
        Vector3 verticalStretched = new Vector3(scale.x, scale.y * amount, scale.z);
        spriteObject.transform.localScale = direction * verticalStretched;
    }


    public void Dash (Vector2 direction)
    {
        m_dashing = true;
        m_direction = direction;
        StretchSprite(direction, 2f);
        
    }

    public bool CanDash ()
    {
        return !m_dashing;
    }
}
