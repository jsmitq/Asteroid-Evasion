using UnityEngine;

public class FlightController : MonoBehaviour
{
    private float m_Roll = 0.0f;
    protected float Roll
    {
        get
        {
            return m_Roll;
        }

        set
        {
            m_Roll = value;
        }
    }

    private float m_Pitch = 0.0f;
    protected float Pitch
    {
        get
        {
            return m_Pitch;
        }

        set
        {
            m_Pitch = value;
        }
    }

    private float m_RollDirection = 1.0f;
    protected float RollDirection
    {
        get
        {
            return m_RollDirection;
        }

        set
        {
            m_RollDirection = value;
        }
    }

    private float m_PitchDirection = 1.0f;
    protected float PitchDirection
    {
        get
        {
            return m_PitchDirection;
        }

        set
        {
            m_PitchDirection = value;
        }
    }

    [SerializeField]
    private float thrust = 0.0f;
    public float Thrust
    {
        get
        {
            return thrust;
        }

        set
        {
            thrust = value;
        }
    }

    [SerializeField]
    private float torque = 0.0f;
    public float Torque
    {
        get
        {
            return torque;
        }

        set
        {
            torque = value;
        }
    }

    [SerializeField]
    private Rigidbody m_RigidBody;
    protected Rigidbody Rb
    {
        get
        {
            return m_RigidBody;
        }

        set
        {
            m_RigidBody = value;
        }
    }


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        RollDirection = GameOptions.InvertXAxis ? 1.0f : -1.0f;
        PitchDirection = GameOptions.InvertYAxis ? 1.0f : -1.0f;
        
        Rb.AddForce(transform.forward * Thrust);
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
#endif

        Roll = Input.GetAxis("Mouse X") * RollDirection;
        Pitch = Input.GetAxis("Mouse Y") * PitchDirection;
    }
	
	void FixedUpdate()
    {
        Rb.AddTorque(transform.forward * Torque * Roll * Time.deltaTime);
        Rb.AddTorque(transform.right * Torque * Pitch * Time.deltaTime);
        Rb.AddForce(transform.forward * Thrust * Time.deltaTime);
    }
}
