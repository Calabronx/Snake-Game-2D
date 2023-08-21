using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGame : MonoBehaviour
{
    private static SnakeGame instance = null;

    public int gameScore = 0;
    public int gameLives = 3;
    public int scoreMultiplier = 100;
    private Canvas canvas;

    public static SnakeGame Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("SnakeGame").AddComponent<SnakeGame>();
            }

            return instance;
        }
    }

    /// <summary>
    /// Callback sent to all game objects before the application is quit.
    /// </summary>
    public void OnApplicationQuit()
    {
        DestroyInstance();
    }

    public void DestroyInstance()
    {
        print("Snake game instance destroyed");
        instance = null;
    }

    public void UpdateLives(int additive)
    {
        gameLives += additive;
        gameLives = Mathf.Clamp(gameLives, 0, gameLives);
        Lives.Instance.UpdateLivesText(gameLives.ToString());
    }

    public void UpdateScore(int newScore)
    {
        gameScore += newScore;
        gameScore = Mathf.Clamp(newScore, 0, newScore);
        Score.Instance.UpdateScoreText(gameScore.ToString());
    }

    public void Initialize()
    {
        print("SnakeGame initialized");

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;

        gameScore = 0;
        gameLives = 3;
        scoreMultiplier = 100;

        UpdateScore(0);
        UpdateLives(0);
        // transform.SetParent(canvas.transform);
    }
}
