using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpPadForce = 13f;
    /*
    [SerializeField] private float additionalSleepJumpTime = 0.3f;

    private static readonly int Bounce = Animator.StringToHash("Bounce");
    
    public float GetJumpPadForce() => additionalSleepJumpTime;

    public void TriggerJumpPad()
    {
        animator.SetTrigger(Bounce);
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPadForce, ForceMode2D.Impulse);
        animator.SetTrigger("collap");
    }
}
