using UnityEngine;
using System.Collections;

public class GameData: MonoBehaviour
{
    private static long m_FinalScore = 0;
    public static long FinalScore
    {
        get
        {
            return m_FinalScore;
        }

        set
        {
            m_FinalScore = value;
        }
    }
}
