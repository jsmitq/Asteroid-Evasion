using UnityEngine;
using System.Collections;

public class QuitScript : MonoBehaviour
{
	void Start()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
