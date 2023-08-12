using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenField : MonoBehaviour
{
    private static ScreenField instance = null;

    public static ScreenField Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("ScreenField").AddComponent<ScreenField>();
            }

            return instance;
        }
    }

    /// <summary>
    /// Callback sent to all game objects before the application is quit.
    /// </summary>
    private void OnApplicationQuit()
    {
        DestroyInstance();
    }

    public void DestroyInstance()
    {
        print("Screen field instance destroyed");
        instance = null;
    }

    public void Initialize()
    {
        print("ScreenField initialized");

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = new Vector3(0.01f, 0.01f, 1.0f);

        Image gameScreenBackground = gameObject.AddComponent<Image>();

        Texture2D gameTexture = TextureHelper.Create1x1BlackTexture();

        /**
        gameBorderBackground.sprite = Sprite.Create(gameBorderTexture, new Rect(0, 0, gameBorderTexture.width, gameBorderTexture.height), Vector2.zero);
        gameBorderBackground.rectTransform.sizeDelta = new Vector2(1024, 768);
        **/

        gameScreenBackground.sprite = Sprite.Create(gameTexture, new Rect(0, 0, gameTexture.width, gameTexture.height), Vector2.zero);
        gameScreenBackground.rectTransform.sizeDelta = new Vector4(22, 84, 980, 600);
    }
}
