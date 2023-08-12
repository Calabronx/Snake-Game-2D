using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] static SnakeController controllerInstance;
    [SerializeField] GameObject snakeSprite;
    [SerializeField] float movementSpeed;

    private Vector3 currentDirection = Vector3.up;


    private void Awake()
    {
        if (controllerInstance == null)
        {
            controllerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.position += currentDirection * movementSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W) && currentDirection != Vector3.down && currentDirection != Vector3.up)
        {
            transform.Rotate(0, 0, 90);
            currentDirection = Vector3.up;

        }
        else if (Input.GetKeyDown(KeyCode.D) && currentDirection != Vector3.left && currentDirection != Vector3.right)
        {
            transform.Rotate(0, 0, -90);
            currentDirection = Vector3.right;

        }
        else if (Input.GetKeyDown(KeyCode.A) && currentDirection != Vector3.right && currentDirection != Vector3.left)
        {
            transform.Rotate(0, 0, -270);
            currentDirection = Vector3.left;

        }
        else if (Input.GetKeyDown(KeyCode.S) && currentDirection != Vector3.up && currentDirection != Vector3.down)
        {
            transform.Rotate(0, 0, 90);
            currentDirection = Vector3.down;
        }
    }

    public static SnakeController GetInstance()
    {
        Debug.Log("Instancia de controlador creada");
        return controllerInstance;
    }
}
