using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private AudioSource collectibleSound;
    [SerializeField] private AudioSource groundSound;
    [SerializeField] ParticleSystem ground;
    [SerializeField] ParticleSystem collect;
    [SerializeField] ParticleSystem death;

    private Collider2D _playerCollider;
    private void Start()
    {
        _playerCollider = GetComponent<Collider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out JumpPad jumpPad))
        {
            playerController.Jump(jumpPad.GetJumpPadForce(), jumpPad.GetAdditionalSleepJumpTime());
            jumpPad.TriggerJumpPad();
            
        }
        else if (col.TryGetComponent(out Collectibles collectible))
        {
            var collectibleType = collectible.GetCollectibleInfoOnContact();

            switch (collectibleType)
            {
                case CollectibleType.DoubleJump:
                    playerController.EnableDoubleJump();
                    break;
                case CollectibleType.RefillHealth:
                case CollectibleType.RefillEnergy:
                case CollectibleType.RefillDash:
                default:
                    break;
            }
            
            Debug.Log(collectibleType);
            collectibleSound.Play();
            collect.Play();
        }

        if (_playerCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            CreatParticleDeath();
            playerController.TakeDamage();  
        }

        #region Unused

        /*if (!col.TryGetComponent(out Collectibles collectible)) return;  
        // This is an inverted if. If the above condition is not met, return void (stop this function).
        
        var collectibleType = collectible.GetCollectibleInfoOnContact();

        switch (collectibleType)
            {
                case CollectibleType.Red:
                    spriteRenderer.color = redColor;
                    break;
                case CollectibleType.Green:
                    spriteRenderer.color = greenColor;
                    break;
                case CollectibleType.Blue:
                    spriteRenderer.color = blueColor;
                    break;
            }*/

        #endregion
    }

    public void CreatParticleGround()
    {
        ground.Play();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(_playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            groundSound.Play();
            CreatParticleGround();
        }
    }

    void CreatParticleDeath()
    {
        death.Play();
    }

}
