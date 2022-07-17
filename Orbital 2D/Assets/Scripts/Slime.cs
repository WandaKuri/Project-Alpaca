using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxCollider;
    private SpriteRenderer mySpriteRenderer;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Animator anim;
    
	// Use this for initialization
	void Start () {
        this.currentState = EnemyState.idle;
        this.myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        this.myBoxCollider = gameObject.GetComponent<BoxCollider2D>();
        this.mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        this.anim = GetComponent<Animator>();
        this.target = GameObject.FindWithTag("Player").transform;
        Physics2D.IgnoreCollision(myBoxCollider, target.GetComponent<CircleCollider2D>());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
           && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle 
                || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position,
                                                         target.position,
                                                         moveSpeed * Time.deltaTime);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
                this.SetFacingDirection();
            }
        } 
        else if (Vector3.Distance(target.position,transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
            ChangeState(EnemyState.idle);
        }
    }

    private void SetFacingDirection()
    {
        float difference = target.position.x - transform.position.x;
        mySpriteRenderer.flipX = difference > 0;
    }
    
    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
