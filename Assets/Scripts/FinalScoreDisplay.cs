using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalScoreDisplay : MonoBehaviour
{
	void Start()
    {
        Text displayText = GetComponent<Text>();

        if (displayText)
        {
            displayText.text = GameData.FinalScore.ToString();
        }
	}
}
