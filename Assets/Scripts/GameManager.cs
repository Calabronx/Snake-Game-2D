using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    private GameManager() { }

    private void Awake()
    {
        ScreenBorder.Instance.Initialize();
        ScreenField.Instance.Initialize();
        CanvasText.Instance.Initialize();
        Score.Instance.Initialize();
        Lives.Instance.Initialize();
        SnakeGame.Instance.Initialize();
        Food.Instance.Initialize();
        Snake.Instance.Initialize();
        ScreenDeath.Instance.Initialize();
        // SnakeController controller = SnakeController.GetInstance();
    }
}
