using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScreenBorder : MonoBehaviour
{
    private static ScreenBorder instance = null;

    public static ScreenBorder Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("ScreenBorder").AddComponent<ScreenBorder>();
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
        print("Screen Border Instance destroyed");
        instance = null;
    }

    public void Initialize()
    {
        print("ScreenBorder initialized");

        transform.position = new Vector3(0, 0, -1);
        transform.rotation = Quaternion.identity;
        transform.localScale = new Vector3(0.01f, 0.01f, 1.0f);

        // add our GUITexture component
        Image gameBorderBackground = gameObject.AddComponent<Image>();

        // we create a texture for our GUITexture mainTexture
        Texture2D gameBorderTexture = TextureHelper.Create1x1Texture(Color.gray);

        // we intialize some GUITexture properties
        gameBorderBackground.sprite = Sprite.Create(gameBorderTexture, new Rect(0, 0, gameBorderTexture.width, gameBorderTexture.height), Vector2.zero);
        gameBorderBackground.rectTransform.sizeDelta = new Vector2(1024, 768);
    }
}
