using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private CollectibleSpawner collectibleSpawner;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SoCollectibles collectibleObject;
    [SerializeField] private Transform EndMovePoint;

    private CollectibleType _collectibleType;
    private bool _isRespawnable;

    private void Start()
    {
        SetCollectible();
        _isRespawnable = FindObjectOfType<GameManager>();
        transform.DOMove(EndMovePoint.position, 3f).SetEase(Ease.InOutBack).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }

    public CollectibleType GetCollectibleInfoOnContact()
    {
        gameObject.SetActive(false);

        if (_isRespawnable)
        {
            collectibleSpawner.StartRespawningCountdown();
        }

        return _collectibleType;
    }
    
    private void SetCollectible()
    {
        collectibleSpawner.SetOutlineSprite(collectibleObject.GetOutlineSprite());
        spriteRenderer.sprite = collectibleObject.GetSprite();
        _collectibleType = collectibleObject.GetCollectibleType();
        _isRespawnable = collectibleObject.GetRespawnable();
    }
}
