using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    private static Lives instance = null;
    private Text gameLivesText;
    private Canvas canvas;
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
        canvas = GetComponent<Canvas>();

        transform.position = new Vector3(267.1f,0f,0f);
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;

        gameLivesText = gameObject.AddComponent<Text>();
        gameLivesText.text = "Lives: ";
        gameLivesText.PixelAdjustPoint(vec);

        Font arialFont = Resources.GetBuiltinResource<Font>("Arial.ttf");
        if (arialFont != null)
        {
            gameLivesText.font = arialFont;
        }
        else
        {
            Debug.Log("Font asset not found");
        }

        // transform.SetParent(canvas.transform);
    }
}
