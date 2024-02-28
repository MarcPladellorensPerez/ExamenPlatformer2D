using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Animaciones")]
    [SerializeField] private Animator animator;
    [SerializeField] private KeyCode attackKey = KeyCode.Alpha1;
    [SerializeField] private KeyCode hurtKey = KeyCode.Alpha2;
    [SerializeField] private KeyCode dieKey = KeyCode.Alpha3;

    [Header("Teleport")]
    [SerializeField] private float dist_x = 5f;
    [SerializeField] private float dist_y = 5f;

    private bool isAttacking = false;

    private void Update()
    {
        HandleAnimationInput();
        FlipCharacter();
    }

    private void HandleAnimationInput()
    {
        if (Input.GetKeyDown(attackKey))
        {
            animator.SetTrigger("Attack");
            isAttacking = true;
        }
        else if (Input.GetKeyDown(hurtKey))
        {
            animator.SetTrigger("Hurt");
            isAttacking = false;
        }
        else if (Input.GetKeyDown(dieKey))
        {
            animator.SetTrigger("Die");
            isAttacking = false;
        }
    }

    private void FlipCharacter()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void Teleport()
    {
        Vector3 teleportDirection = new Vector3(Mathf.Sign(transform.localScale.x), 1, 0);
        Vector3 teleportPosition = transform.position + new Vector3(teleportDirection.x * dist_x, dist_y, 0f);
        transform.position = teleportPosition;
    }

    private void OnDrawGizmos()
    {
        if (isAttacking)
        {
            Gizmos.color = Color.red;
            Vector3 teleportDirection = new Vector3(Mathf.Sign(transform.localScale.x), 1, 0);
            Vector3 teleportDestination = transform.position + new Vector3(teleportDirection.x * dist_x, dist_y, 0f);
            Gizmos.DrawLine(transform.position, teleportDestination);
        }
    }
}
