using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenDeath : MonoBehaviour
{
    private static ScreenDeath instance = null;
    private Image deathScreenBackground;
    private Color deathColor;
    private Color invisColor;

    public static ScreenDeath Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("ScreenDeath").AddComponent<ScreenDeath>();
            }

            return instance;
        }
    }

    public void OnApplicationQuit()
    {
        DestroyInstance();
    }

    public void DestroyInstance()
    {
        print("Screen Death Instance destroyed");

        instance = null;
    }

    public IEnumerator FlashDeathScreen()
    {
        deathScreenBackground.color = deathColor;

        yield return new WaitForSeconds(0.1f);

        deathScreenBackground.color = invisColor;

        yield return new WaitForSeconds(0.1f);

        deathScreenBackground.color = deathColor;

        yield return new WaitForSeconds(0.1f);

        deathScreenBackground.color = invisColor;

        yield return new WaitForSeconds(0.1f);

        deathScreenBackground.color = deathColor;

        yield return new WaitForSeconds(0.1f);

        deathScreenBackground.color = invisColor;

        yield return new WaitForSeconds(0.1f);

        deathScreenBackground.color = deathColor;

        yield return new WaitForSeconds(0.1f);

        deathScreenBackground.color = invisColor;

        yield return new WaitForSeconds(0.1f);
    }

    public void Initialize()
    {
        print("ScreenDeath initialized");

        transform.position = new Vector3(0, 0, 2);
        transform.rotation = Quaternion.identity;
        transform.localScale = new Vector3(0.01f, 0.01f, 1.0f);

        deathScreenBackground = gameObject.AddComponent<Image>();

        Texture2D deathTexture = TextureHelper.Create1x1Texture(Color.red);

        deathScreenBackground.sprite = Sprite.Create(deathTexture, new Rect(0, 0, deathTexture.width, deathTexture.height), Vector2.zero);
        deathScreenBackground.rectTransform.sizeDelta = new Vector2(1024, 768);
        invisColor = new Color(deathScreenBackground.color.r, deathScreenBackground.color.g, deathScreenBackground.color.b, 0.3f);

        deathScreenBackground.color = invisColor;
    }

}
