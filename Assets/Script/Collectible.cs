using UnityEngine;

public class Collectible : MonoBehaviour
{   
    [SerializeField] private SoCollectible collectibleObject;

    private void OnTriggerEnter2D(Collider2D col)
    {
        gameObject.SetActive(false);
        Debug.Log(collectibleObject.name);
        
    }

    
}

