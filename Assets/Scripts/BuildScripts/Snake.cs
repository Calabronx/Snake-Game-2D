using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] static Snake snakeInstance;
    [SerializeField] List<GameObject> snakeParts;
    [SerializeField] GameObject snakeTail;
    [SerializeField] GameObject snakeHead;
    [SerializeField] int lifes;

    private Vector3 headPositon;
    // private Transform snakeContainer;

    public Snake()
    {

    }

    private void Awake()
    {
        snakeParts = new List<GameObject>();
        // snakeContainer = new GameObject("Snake").transform;
        // snakeContainer.position = snakeHead.transform.position;

        snakeParts.Add(snakeHead); // add HEAD of snake
        headPositon = snakeHead.transform.position;

        if (snakeInstance == null)

            snakeInstance = this;
        else
            Destroy(gameObject);
    }

    public static Snake GetInstance()
    {
        Debug.Log("Instancia de Snake creada");
        return snakeInstance;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision snake!");
        Debug.Log(other.gameObject.name);
        // Food foodInstance = ;
        // float healthRecover = foodInstance.getHealthPoints();

        if (other.gameObject.name == "Food")
        {
            AddSnakePart();
        }
    }

    private void AddSnakePart()
    {
        GameObject newSnakePart = Instantiate(snakeTail, snakeParts[snakeParts.Count - 1].transform.position - Vector3.up * 0.32f, Quaternion.identity);
        newSnakePart.transform.SetParent(snakeHead.transform);
        snakeParts.Add(newSnakePart);
    }
}
