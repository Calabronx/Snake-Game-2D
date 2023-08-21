using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasText : MonoBehaviour
{
    private static CanvasText instance = null;
    private Canvas canvas;
    [SerializeField] List<Component> gameInstancesList;
    // private Score score;

    public static CanvasText Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("CanvasText").AddComponent<CanvasText>();
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

    private void DestroyInstance()
    {
        instance = null;
    }

    public void AddTransRefToCanvas(GameObject textRef)
    {
        textRef.transform.SetParent(canvas.transform);
    }

    public void Initialize()
    {
        print("CanvasText initialized");

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;

        canvas = gameObject.AddComponent<Canvas>();
        gameInstancesList = new List<Component>();

        Score score = Score.Instance;
        Lives lives = Lives.Instance;
        SnakeGame game = SnakeGame.Instance;
        ScreenBorder screenBorder = ScreenBorder.Instance;
        ScreenField screenField = ScreenField.Instance;

        gameInstancesList.Add(score);
        gameInstancesList.Add(lives);
        gameInstancesList.Add(game);
        gameInstancesList.Add(screenBorder);
        gameInstancesList.Add(screenField);
        
        foreach (Component instance in gameInstancesList)
        {
            GameObject parseInstance = instance.gameObject;
            AddTransRefToCanvas(parseInstance.transform.gameObject);
        }
    
    }
}
