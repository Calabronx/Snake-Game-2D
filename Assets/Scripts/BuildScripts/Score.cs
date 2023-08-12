using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    private static Score instance = null;
    private Text gameScoreText;

    public static Score Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameScore").AddComponent<Score>();
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
        print("Score instance destroyed");

        instance = null;
        // Destroy(instance);
    }

    public void UpdateScoreText(string appendString)
    {
        gameScoreText.text = "";
        gameScoreText.text = "Score: " + appendString;
    }

    public void Initialize()
    {
        print("Score initialized");
        Vector2 pixelVec = new Vector2(10, 758);

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;

        gameScoreText = gameObject.AddComponent<Text>();
        gameScoreText.text = "Score: ";
        gameScoreText.PixelAdjustPoint(pixelVec);
    }
}
