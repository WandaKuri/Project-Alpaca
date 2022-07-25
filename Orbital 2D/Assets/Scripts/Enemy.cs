using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState 
{
    idle,
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{
    
    public static bool canMove = true;
    public EnemyState currentState;
    public GameObject enemy;
    public string enemyName;
    public float maxHealth;
    public float health;
    public float moveSpeed;
    public int experience;
    public int baseAttack;
    protected GameObject player;
    protected Rigidbody2D myRigidbody;
    protected BoxCollider2D myBoxCollider;
    protected SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        this.health = this.maxHealth;
    }

    private void TakeDamage(float damage)
    {
        this.health -= damage;
        if (health <= 0)
        {
            if (mySpriteRenderer.enabled)
            {
                this.player.GetComponent<PlayerAttribute>().AddExperience(this.experience);
            }
            mySpriteRenderer.enabled = false;
            Invoke("Respawn", 5);
        }
    }

    private void Respawn()
    {
        Instantiate(this.enemy);
        Destroy(this.gameObject);
    }

    public static void setMovement(bool canMove)
    {
        Enemy.canMove = canMove;
    }
    
    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
        }
    }
}
