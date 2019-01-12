using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    
    [SerializeField]
    private Transform m_ObjectToFollow;
    public Transform ObjectToFollow
    {
        get
        {
            return m_ObjectToFollow;
        }

        set
        {
            m_ObjectToFollow = value;
        }
    }

    [SerializeField]
    private float m_FollowDistance;
    public float FollowDistance
    {
        get
        {
            return m_FollowDistance;
        }

        set
        {
            m_FollowDistance = value;
        }
    }

    [SerializeField]
    private Transform m_Camera;
    public Transform Camera
    {
        get
        {
            return m_Camera;
        }

        set
        {
            m_Camera = value;
        }
    }

    private void Start()
    {
        transform.position = ObjectToFollow.position;
        transform.rotation = ObjectToFollow.rotation;

        Camera.position = ObjectToFollow.position;
        Camera.rotation = ObjectToFollow.rotation;
        Camera.Translate(Vector3.back * FollowDistance);
    }

    private void Update()
    {
        if (ObjectToFollow)
        {
            transform.position = ObjectToFollow.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, ObjectToFollow.rotation, Time.deltaTime);
        }
    }
}
