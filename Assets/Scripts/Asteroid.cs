using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float m_moveForce = 100;
    public float MoveForce
    {
        get
        {
            return m_moveForce;
        }

        set
        {
            m_moveForce = value;
        }
    }

    [SerializeField]
    private float m_spinForce = 100;
    public float SpinForce
    {
        get
        {
            return m_spinForce;
        }

        set
        {
            m_spinForce = value;
        }
    }

    private void Start()
    {
        var rb = GetComponent<Rigidbody>();

        if (rb)
        {
            rb.AddForce(Random.onUnitSphere * MoveForce * Random.value, ForceMode.Impulse);
            rb.AddTorque(Random.onUnitSphere * SpinForce * Random.value, ForceMode.Impulse);
        }
    }
}
