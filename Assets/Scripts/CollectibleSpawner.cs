using System.Collections;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    // This script is to handle the respawning of the collectible as a disabled gameObject cannot run any methods or coroutines on its own.
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject collectibleGameObject;
    [SerializeField] private AudioSource respawnedSound;
    [SerializeField] ParticleSystem newRespawn;
    
    [Header("Collectible Settings")]
    [SerializeField] private float respawnTime = 4f;

    private void Start()
    {
        spriteRenderer.enabled = false;
    }
    
    private IEnumerator RespawnCollectible()
    {
        yield return new WaitForSeconds(respawnTime);
        SetOutlineSpriteActive(false);
        collectibleGameObject.SetActive(true);
        respawnedSound.Play();
        CreatParticleNew();
        
    }

    private void SetOutlineSpriteActive(bool state)
    {
        spriteRenderer.enabled = state;
    }

    public void SetOutlineSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
    
    public void StartRespawningCountdown() // This method is to let other script trigger the respawn countdown, and let this script handle the coroutine.
    {
        SetOutlineSpriteActive(true);
        StartCoroutine(RespawnCollectible());
        
    }

    void CreatParticleNew()
    {
        newRespawn.Play();
    }
}
