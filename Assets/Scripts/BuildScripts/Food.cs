using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] static Food foodInstance;
    private float healthPoints = 0.5f;


    // private void Awake()
    // {
    //     if (foodInstance == null)
    //     {
    //         foodInstance = this;
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    private float getHealthPoints() {
       return healthPoints;
    }

    public static Food GetInstance()
    {
        Debug.Log("Instancia de Food creada");
        return foodInstance;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision food!");
        Destroy(gameObject);
    }
}
