using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject foodSprite;
    [SerializeField] Food foodInstance;
    [SerializeField] int rows;
    [SerializeField] int columns;
    [SerializeField] float xOffSet;
    [SerializeField] float yOffSet;
    [SerializeField] int rotation;

    private List<GameObject> items;

    private int itemsCounter;

    private FoodSpawner()
    {
        items = new List<GameObject>();
    }
    void Start()
    {
        Debug.Log("creando foods");
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float xPosition = col * xOffSet - ((columns - 1) * xOffSet / 2);
                float yPosition = row * yOffSet + 2.5f;
                GameObject foodItem = Instantiate(foodSprite, new Vector3(xPosition, yPosition, 0f), Quaternion.Euler(0, 0, rotation));
                foodItem.name = "Food";
                items.Add(foodItem);
                itemsCounter++;
            }
        }
        Debug.Log("Lista : " + items.ToString());
        Debug.Log("Cantidad de items : " + itemsCounter);
    }

}
