using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColors : MonoBehaviour
{
    [SerializeField] private Sprite[] SpriteCollection = new Sprite[3];
    private int index;
    public enum CollectibleColors
    {
        Red,
        Green,
        Blue,
    }

    public CollectibleColors Colors;

    void Start()
    {
        index = Random.Range(0, SpriteCollection.Length);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteCollection[index];
        if(index == 0)
            {Colors = CollectibleColors.Red;}
        else if(index == 1)
            {Colors = CollectibleColors.Green;}
        else if(index == 2)
            {Colors = CollectibleColors.Blue;}

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        gameObject.SetActive(false);
        switch (Colors)    
        {
            case CollectibleColors.Red:
                col.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case CollectibleColors.Green:
                col.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case CollectibleColors.Blue:
                col.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
        }
    }
}
