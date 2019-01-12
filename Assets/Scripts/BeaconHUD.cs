using UnityEngine;
using System.Text;

public class BeaconHUD : MonoBehaviour
{
    [SerializeField]
    private Transform m_player = null;
    public Transform Player
    {
        get
        {
            return m_player;
        }

        set
        {
            m_player = value;
        }
    }

    [SerializeField]
    private Camera m_camera = null;
    public Camera Camera
    {
        get
        {
            return m_camera;
        }

        set
        {
            m_camera = value;
        }
    }

    [SerializeField]
    private TextMesh m_text = null;
    public TextMesh Text
    {
        get
        {
            return m_text;
        }

        set
        {
            m_text = value;
        }
    }
    
    [SerializeField]
    private float m_sizeOnScreen = 64.0f;
    public float SizeOnScreen
    {
        get
        {
            return m_sizeOnScreen;
        }

        set
        {
            m_sizeOnScreen = value;
        }
    }

    private Vector3 m_playerVector = Vector3.zero;
    protected Vector3 PlayerVector
    {
        get
        {
            return m_playerVector;
        }

        set
        {
            m_playerVector = value;
        }
    }
    
    private StringBuilder m_StringBuilder;
    protected StringBuilder StringBuilder
    {
        get
        {
            return m_StringBuilder;
        }

        set
        {
            m_StringBuilder = value;
        }
    }

    void Start()
    {
        StringBuilder = new StringBuilder();
    }

    void Update()
    {
        transform.LookAt(Camera.transform);
        transform.rotation = Camera.transform.rotation;

        Vector3 a = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 b = new Vector3(a.x, a.y + SizeOnScreen, a.z);

        Vector3 aa = Camera.main.ScreenToWorldPoint(a);
        Vector3 bb = Camera.main.ScreenToWorldPoint(b);

        transform.localScale = Vector3.one * (aa - bb).magnitude;

        if(Player)
            PlayerVector = Player.position - transform.position;
        Text.text = "[" + PlayerVector.magnitude.ToString() + "]";
    }
}
