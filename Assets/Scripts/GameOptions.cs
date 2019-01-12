using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOptions : MonoBehaviour
{
    private static bool m_InvertXAxis = false;
    public static bool InvertXAxis
    {
        get
        {
            return m_InvertXAxis;
        }

        set
        {
            m_InvertXAxis = value;
        }
    }


    private static bool m_InvertYAxis = true;
    public static bool InvertYAxis
    {
        get
        {
            return m_InvertYAxis;
        }

        set
        {
            m_InvertYAxis = value;
        }
    }


    [SerializeField]
    private Toggle m_InvertXAxisToggle;
    protected Toggle InvertXAxisToggle
    {
        get
        {
            return m_InvertXAxisToggle;
        }

        set
        {
            m_InvertXAxisToggle = value;
        }
    }


    [SerializeField]
    private Toggle m_InvertYAxisToggle;
    protected Toggle InvertYAxisToggle
    {
        get
        {
            return m_InvertYAxisToggle;
        }

        set
        {
            m_InvertYAxisToggle = value;
        }
    }


    private void Start()
    {
        if (InvertXAxisToggle)
            InvertXAxisToggle.isOn = InvertXAxis;

        if (InvertYAxisToggle)
            InvertYAxisToggle.isOn = InvertYAxis;
    }


    public void OnToggleInvertXAxis()
    {
        InvertXAxis = InvertXAxisToggle.isOn;
    }


    public void OnToggleInvertYAxis()
    {
        InvertYAxis = InvertYAxisToggle.isOn;
    }
}
