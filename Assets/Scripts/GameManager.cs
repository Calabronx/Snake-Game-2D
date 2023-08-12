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

        Score.Instance.Initialize();
        Lives.Instance.Initialize();
        Snake snake = Snake.GetInstance();
        SnakeController controller = SnakeController.GetInstance();
        Food food = Food.GetInstance();
    }
}
