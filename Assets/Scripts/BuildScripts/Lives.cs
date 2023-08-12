using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    private static Lives instance = null;
    private Text gameLivesText;

    public static Lives Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameLives").AddComponent<Lives>();
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
        print("Lives instances destroyed");

        instance = null;
    }

    public void UpdateLivesText(string appendString)
    {
        gameLivesText.text = "";
        gameLivesText.text = "Lives: " + appendString;
    }

    public void Initialize()
    {
        print("Lives initialized");
        Vector2 vec = new Vector2(944, 758);

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;

        gameLivesText = gameObject.AddComponent<Text>();
        gameLivesText.text = "Lives: ";
        gameLivesText.PixelAdjustPoint(vec);
    }
}
