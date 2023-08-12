using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureHelper
{

    //create and return black texture
    public static Texture2D CreateBlackTexture(int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                texture.SetPixel(i, j, Color.black);
            }
        }
        texture.Apply();

        return texture;
    }

    public static Texture2D CreateTexture(int width, int height, Color color)
    {
        Texture2D texture = new Texture2D(width, height);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                texture.SetPixel(i, j, color);
            }
        }

        texture.Apply();

        return texture;
    }

    public static Texture2D Create1x1BlackTexture()
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.black);
        texture.Apply();

        return texture;
    }

    public static Texture2D Create1x1Texture(Color color)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();

        return texture;
    }

}
