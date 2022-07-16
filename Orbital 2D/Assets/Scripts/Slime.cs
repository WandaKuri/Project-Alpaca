using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxCollider;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;
    
	// Use this for initialization
	void Start () {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        Physics2D.IgnoreCollision(myBoxCollider, target.GetComponent<CircleCollider2D>());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckDistance();
	}

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, 
                            transform.position) <= chaseRadius
           && Vector3.Distance(target.position,
                               transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position,
                                                         target.position,
                                                         moveSpeed * Time.deltaTime);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        } else if (Vector3.Distance(target.position,transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
            ChangeState(EnemyState.idle);
        }
    }

    private void SetAnimFloat(Vector2 setVector){
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    private void changeAnim(Vector2 direction){
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0){
                SetAnimFloat(Vector2.right);
            }else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y)){
            if(direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    private void ChangeState(EnemyState newState){
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
