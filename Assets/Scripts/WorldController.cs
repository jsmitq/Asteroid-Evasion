using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class WorldController : MonoBehaviour
{
    [SerializeField]
    private List<Asteroid> m_AsteroidTemplates = new List<Asteroid>();
    public List<Asteroid> AsteroidTemplates
    {
        get
        {
            return m_AsteroidTemplates;
        }

        set
        {
            m_AsteroidTemplates = value;
        }
    }


    [SerializeField]
    private Transform m_Player = null;
    public Transform Player
    {
        get
        {
            return m_Player;
        }

        set
        {
            m_Player = value;
        }
    }


    [SerializeField]
    private SceneFader m_SceneFader = null;
    public SceneFader SceneFader
    {
        get
        {
            return m_SceneFader;
        }

        set
        {
            m_SceneFader = value;
        }
    }


    [SerializeField]
    private int m_AsteroidCount = 100;
    public int AsteroidCount
    {
        get
        {
            return m_AsteroidCount;
        }

        set
        {
            m_AsteroidCount = value;
        }
    }


    [SerializeField]
    private float m_WorldRadius = 200.0f;
    public float WorldRadius
    {
        get
        {
            return m_WorldRadius;
        }

        set
        {
            m_WorldRadius = value;
        }
    }


    private long m_Score = 0;
    public long Score
    {
        get
        {
            return m_Score;
        }

        set
        {
            m_Score = value;
            if (ScoreText)
                ScoreText.text = m_Score.ToString();
        }
    }


    [SerializeField]
    private Text m_ScoreText;
    public Text ScoreText
    {
        get
        {
            return m_ScoreText;
        }

        set
        {
            m_ScoreText = value;
        }
    }


    private List<Asteroid> m_Asteroids = new List<Asteroid>();
    protected List<Asteroid> Asteroids
    {
        get
        {
            return m_Asteroids;
        }

        set
        {
            m_Asteroids = value;
        }
    }


    private bool m_IsGameOver = false;
    protected bool IsGameOver
    {
        get
        {
            return m_IsGameOver;
        }

        set
        {
            m_IsGameOver = value;
        }
    }


    private void Start()
    {
        IsGameOver = false;
        Score = 0;

        SpawnAsteroids();
    }
    

    private void SpawnAsteroids()
    {
        if (AsteroidCount <= 0) return;

        if(m_AsteroidTemplates.Count == 0)
        {
            Debug.LogError("No Asteroid Templates!");
            return;
        }

        var prng = new System.Random();

        for(int i = 0; i < AsteroidCount; i++)
        {
            Vector3 newPosition = Vector3.zero;
            bool badPosition = true;
            while (badPosition)
            {
                float magnitude = (Random.value * WorldRadius * 0.6f) + WorldRadius * 0.4f;
                newPosition = Random.onUnitSphere;
                newPosition *= magnitude;

                // Check that the new asteroid is far enough away from other asteroids
                badPosition = false;
                for(int j=0; j < Asteroids.Count; j++)
                {
                    if(Vector3.Distance(newPosition, Asteroids[j].transform.position) < 20.0f )
                    {
                        badPosition = true;
                        break;
                    }
                }
            }

            int templateIndex = prng.Next(0, AsteroidTemplates.Count - 1);
            var newAsteroid = Instantiate(AsteroidTemplates[templateIndex], newPosition, Quaternion.identity) as Asteroid;
            newAsteroid.transform.parent = transform;
            Asteroids.Add(newAsteroid);
        }
    }


    private void Update()
    {
        CheckPlayer();
        CheckAsteroids();
        UpdateScore();
	}


    private void CheckAsteroids()
    {
        if (Player)
        {
            // If an asteroid goes outside of the world boundary, move it to the other side
            for (int i = 0; i < Asteroids.Count; i++)
            {
                Vector3 asteroidToPlayer = Player.position - Asteroids[i].transform.position;
                if (asteroidToPlayer.magnitude >= WorldRadius)
                {
                    Asteroids[i].transform.position += 1.95f * asteroidToPlayer;
                }
            }
        }
    }


    private void CheckPlayer()
    {
        if (!Player)
        {
            // Player's ship exploded
            GameOver();
            return;
        }
    }


    private void UpdateScore()
    {
        if (Player)
        {
            Score += Mathf.RoundToInt(Time.deltaTime * 100);
        }
    }


    private void GameOver()
    {
        if (IsGameOver) return;

        IsGameOver = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        GameData.FinalScore = Score;

        if (SceneFader)
            SceneFader.OnFadeOutToScene("GameOverScene");
        else
            SceneManager.LoadScene("GameOverScene");
    }
}
