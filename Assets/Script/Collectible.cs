using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleColors
    {
        Red,
        Green,
        Blue,
    }
    
    public CollectibleColors Colors;

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


