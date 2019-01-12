using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField]
    private AudioClip m_rolloverSound = null;
    public AudioClip RolloverSound
    {
        get
        {
            return m_rolloverSound;
        }

        set
        {
            m_rolloverSound = value;
        }
    }


    [SerializeField]
    private AudioClip m_clickSound = null;
    public AudioClip ClickSound
    {
        get
        {
            return m_clickSound;
        }

        set
        {
            m_clickSound = value;
        }
    }


    [SerializeField]
    private Color m_normalColor = Color.green;
    public Color NormalColor
    {
        get
        {
            return m_normalColor;
        }

        set
        {
            m_normalColor = value;
        }
    }


    [SerializeField]
    private Color m_highlightColor = Color.white;
    public Color HighlightColor
    {
        get
        {
            return m_highlightColor;
        }

        set
        {
            m_highlightColor = value;
        }
    }
    

    private AudioSource m_audioSource = null;
    private AudioSource AudioSource
    {
        get
        {
            return m_audioSource;
        }

        set
        {
            m_audioSource = value;
        }
    }


    private Text m_text = null;
    private Text Text
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


    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        if (AudioSource)
        {
            AudioSource.playOnAwake = false;
        }

        Text = GetComponentInChildren<Text>();
	}


    public void OnPointerClick(PointerEventData eventData)
    {
        if (AudioSource && ClickSound)
        {
            AudioSource.clip = ClickSound;
            AudioSource.Play();
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (AudioSource && RolloverSound)
        {
            AudioSource.clip = RolloverSound;
            AudioSource.Play();
        }

        if (Text)
        {
            Text.color = HighlightColor;
        }
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        if (Text)
        {
            Text.color = NormalColor;
        }
    }
}