using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{

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
        this.mySpriteRenderer.enabled = true;
        this.anim = GetComponent<Animator>();
        this.player = GameObject.FindWithTag("Player");
        this.target = this.player.transform;
        Physics2D.IgnoreCollision(myBoxCollider, this.player.GetComponent<CircleCollider2D>());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(this.target.position, this.transform.position) <= this.chaseRadius
           && Vector3.Distance(this.target.position, this.transform.position) > this.attackRadius)
        {
            if (this.currentState == EnemyState.idle 
                || this.currentState == EnemyState.walk
                && this.currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position,
                                                         target.position,
                                                         moveSpeed * Time.deltaTime);
                this.myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                this.anim.SetBool("wakeUp", true);
                this.SetFacingDirection();
            }
        } 
        else if (Vector3.Distance(this.target.position,this.transform.position) > this.chaseRadius)
        {
            anim.SetBool("wakeUp", false);
            ChangeState(EnemyState.idle);
        }
    }

    private void SetFacingDirection()
    {
        float difference = this.target.position.x - this.transform.position.x;
        this.mySpriteRenderer.flipX = difference > 0;
    }
    
    private void ChangeState(EnemyState newState)
    {
        if (this.currentState != newState)
        {
            this.currentState = newState;
        }
    }
}
