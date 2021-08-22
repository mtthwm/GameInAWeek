using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BouncingRigidbody))]
public class DestroyOnNumBounces : MonoBehaviour
{
    [SerializeField] int maxBounces;

    private BouncingRigidbody m_bounce;

    private void Start()
    {
        m_bounce = GetComponent<BouncingRigidbody>();
    }

    private void FixedUpdate()
    {
        if (m_bounce.NumBounces > maxBounces)
        {
            Destroy(this.gameObject);
        }
    }
}
