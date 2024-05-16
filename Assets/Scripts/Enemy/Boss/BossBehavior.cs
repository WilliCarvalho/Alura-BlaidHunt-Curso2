using System;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    
    [Header("Attack properties")]
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private Vector3 attackOffset;
    [SerializeField] private LayerMask attackMask;
    
    private Transform playerPosition;
    private Rigidbody2D rigidbody;
    private Health health;

    private bool isFlipped = true;
    private bool canAttack = false;

    private Vector3 attackPosition;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        playerPosition = GameManager.Instance.GetPlayer().transform;
        
        print($"Player position: {playerPosition}");
    }

    public void FollowPlayer()
    {
        Vector2 target = new Vector2(playerPosition.position.x, transform.position.y);
        Vector2 newPos = Vector2.MoveTowards(rigidbody.position, target, moveSpeed * Time.fixedDeltaTime);
        rigidbody.MovePosition(newPos);
        LookAtPlayer();
        CheckPositionFromPlayer();
    }

    private void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > playerPosition.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < playerPosition.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    
    private void CheckPositionFromPlayer()
    {
        float distanceFromPlayer = Vector2.Distance(playerPosition.position, transform.position);
        print(distanceFromPlayer);
        if (distanceFromPlayer <= attackRange)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }
    }

    private void Attack()
    {
        attackPosition = transform.position;
        attackPosition += transform.right * attackOffset.x;
        attackPosition += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(attackPosition, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<Health>().TakeDamage();
        }
    }

    public bool GetCanAttack()
    {
        return canAttack;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPosition, attackRange);
    }
}
