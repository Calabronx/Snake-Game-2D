using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private static Snake instance = null;

    private List<Rect> snakePos = new List<Rect>();
    private List<Texture2D> snakeIcon = new List<Texture2D>();
    private int snakeLength = 2;
    private float moveDelay = 0.5f;
    private AudioClip move1;
    private AudioClip move2;
    private AudioClip death;

    public enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public static Snake Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("Snake").AddComponent<Snake>();
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
        print("Snake instance destroyed");
        instance = null;
    }

    void Start()
    {
        StartCoroutine(UpdateSnake());
    }

    IEnumerator UpdateSnake()
    {
        while (true)
        {
            if (InputHelper.GetStandardMoveMultiInputKeys())
            {
                Debug.Log("We are pressing multiple keys for direction");
                yield return null;
                continue;
            }

            if (InputHelper.GetStandardMoveUpDirection())
            {
                yield return StartCoroutine(MoveSnake(Direction.UP));
                //Debug.Log ("We are moving UP");
            }

            if (InputHelper.GetStandardMoveLeftDirection())
            {
                yield return StartCoroutine(MoveSnake(Direction.LEFT));
                //Debug.Log ("We are moving LEFT");
            }

            if (InputHelper.GetStandarMoveDownDirection())
            {
                yield return StartCoroutine(MoveSnake(Direction.DOWN));
                //Debug.Log ("We are moving DOWN");
            }
            if (InputHelper.GetStandardMoveDownDirection())
            {
                yield return StartCoroutine(MoveSnake(Direction.RIGHT));
                //Debug.Log ("We are moving RIGHT");
            }

            if (SnakeCollidedWithSelf() == true)
            {
                break;
            }
            yield return new WaitForSeconds(moveDelay);
        }
        // audio.clip = death;
        // audio.Play();

        yield return StartCoroutine(ScreenDeath.Instance.FlashDeathScreen());

        SnakeGame.Instance.UpdateLives(-1);

        if (SnakeGame.Instance.gameLives == 0)
        {
            Application.LoadLevel("UniSnake");
        }
        else
        {
            Initialize();
            Start();
        }
    }

    public IEnumerator MoveSnake(Direction moveDirection)
    {
        List<Rect> tempRects = new List<Rect>();
        Rect segmentRect = new Rect(0, 0, 0, 0);

        for (int i = 0; i < snakePos.Count; i++)
        {
            tempRects.Add(snakePos[i]);
        }
        switch (moveDirection)
        {
            case Direction.UP:
                if (snakePos[0].y > 94)
                {
                    snakePos[0] = new Rect(snakePos[0].x, snakePos[0].y - 20, snakePos[0].width, snakePos[0].height);
                    UpdateMovePosition(tempRects);
                    if (CheckForFood() == true)
                    {
                        segmentRect = CheckForValidDownPosition();
                        if (segmentRect.x != 0)
                        {
                            BuildSnakeSegment(segmentRect);
                            snakeLength++;
                            moveDelay = Mathf.Max(0.05f, moveDelay - 0.01f);
                            yield break;
                        }

                        segmentRect = CheckForValidLeftPosition();
                        if (segmentRect.x != 0)
                        {
                            BuildSnakeSegment(segmentRect);
                            snakeLength++;
                            moveDelay = Mathf.Max(0.05f, moveDelay - 0.01f);
                            yield break;
                        }

                        segmentRect = CheckForValidRightPosition();
                        if (segmentRect.x != 0)
                        {
                            BuildSnakeSegment(segmentRect);
                            snakeLength++;
                            moveDelay = Mathf.Max(0.05f, moveDelay - 0.01f);
                        }

                    }
                    // toggle the audio clip and play
                    // audio.clip = (audio.clip == move1) ? move2 : move1;
                    // audio.Play();
                }
                break;
            case Direction.LEFT:
                if (snakePos[0].x > 22)
                {
                    snakePos[0] = new Rect(snakePos[0].x - 20, snakePos[0].y, snakePos[0].width, snakePos[0].height);

                    UpdateMovePosition(tempRects);
                    if (CheckForFood() == true)
                    {
                        segmentRect = CheckForValidRightPosition();
                        if (segmentRect.x != 0)
                        {
                            BuildSnakeSegment(segmentRect);
                            snakeLength++;
                            moveDelay = Mathf.Max(0.05f, moveDelay - 0.01f);
                            yield break;
                        }

                        segmentRect = CheckForValidDownPosition();
                        if (segmentRect.x != 0)
                        {
                            BuildSnakeSegment(segmentRect);
                            snakeLength++;
                            moveDelay = Mathf.Max(0.05f, moveDelay - 0.01f);
                            yield break;
                        }
                    }
                    // // toggle the audio clip and play
                    // audio.clip = (audio.clip == move1) ? move2 : move1;
                    // audio.Play();

                }
                break;
            case Direction.DOWN:
                if (snakePos[0].y < 654)
                {
                    snakePos[0] = new Rect(snakePos[0].x, snakePos[0].y + 20, snakePos[0].width, snakePos[0].height);
                    UpdateMovePosition(tempRects);

                    if (CheckForFood() == true)
                    {
                        segmentRect = CheckForValidUpPosition();
                        if (segmentRect.x != 0)
                        {
                            BuildSnakeSegment(segmentRect);
                            snakeLength++;
                            moveDelay = Mathf.Max(0.05f, moveDelay - 0.01f);
                            yield break;
                        }

                        segmentRect = CheckForValidLeftPosition();
                        if (segmentRect.x != 0)
                        {
                            BuildSnakeSegment(segmentRect);
                            snakeLength++;
                            moveDelay = Mathf.Max(0.05f, moveDelay - 0.01f);
                            yield break;
                        }

                        segmentRect = CheckForValidRightPosition(){
                            if (segmentRect.x != 0)
                            {
                                BuildSnakeSegment(segmentRect);
                                snakeLength++;
                                moveDelay = Mathf.Max(0.05f, moveDelay - 0.01f);
                            }
                        }
                        // // toggle the audio clip and play
                        // audio.clip = (audio.clip == move1) ? move2 : move1;
                        // audio.Play();
                    }
                }
                break;
            case Direction.RIGHT:
                if (snakePos[0].x < 982)
                {
                    snakePos[0] = new Rect(snakePos[0].x + 20, snakePos[0].y, snakePos[0].width, snakePos[0].height);
                    UpdateMovePosition(tempRects);

                    if (CheckForFood() == true)
                    {
                        segmentRect = CheckForValidLeftPosition();
                        if (segmentRect.x != 0)
                        {
                            BuildSnakeSegment(segmentRect);
                            snakeLength++;
                            moveDelay = Mathf.Max(0.05f, moveDelay - 0.01f);
                            yield break;
                        }

                        segmentRect = CheckForValidUpPosition();
                        if (segmentRect.x != 0)
                        {
                            BuildSnakeSegment(segmentRect);
                            snakeLength++;
                            moveDelay = Mathf.Max(0.05f, moveDelay - 0.01f);
                        }
                    }
                    // toggle the audio clip and play
                    // audio.clip = (audio.clip == move1) ? move2 : move1;
                    // audio.Play();

                }
                break;
        }
        yield return null;
    }


    private void UpdateMovePosition(List<Rect> tmpRects)
    {
        for (int i = 0; i < tmpRects.Count - 1; i++)
        {
            snakePos[i + 1] = tmpRects[i];
        }
    }

    private bool CheckForFood()
    {
        if (Food.Instance != null)
        {
            Rect foodRect = Food.Instance.foodPos;
            if (snakePos[0].Contains(new Vector2(foodRect.x, foodRect.y)))
            {
                Debug.Log("We hit the food");
                Food.Instance.UpdateFood();
                SnakeGame.Instance.UpdateScore(1);
                return true;
            }
        }
        return false;
    }


    private bool SnakeCollidedWithSelf()
    {
        throw new NotImplementedException();
    }
}
