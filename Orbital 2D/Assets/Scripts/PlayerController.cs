using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRigid;
    public float moveSpeed;
    public Animator myAnimator;
    public static PlayerController instance;
    public string areaTransitionName;
    
    private Transform bottomLeftBox;
    private Transform topRightBox;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        bottomLeftBox = GameObject.FindGameObjectWithTag("bottomLeft").transform;
        topRightBox = GameObject.FindGameObjectWithTag("topRight").transform;
        bottomLeftLimit = new Vector3(bottomLeftBox.position.x, bottomLeftBox.position.y, bottomLeftBox.position.z);
        topRightLimit = new Vector3(topRightBox.position.x, topRightBox.position.y, topRightBox.position.z) ;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            playerRigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
            myAnimator.SetFloat("moveX", playerRigid.velocity.x);
            myAnimator.SetFloat("moveY", playerRigid.velocity.y);

            if (Input.GetAxisRaw("Horizontal") == 1
                || Input.GetAxisRaw("Horizontal") == -1
                || Input.GetAxisRaw("Vertical") == 1
                || Input.GetAxisRaw("Vertical") == -1)
            {
                myAnimator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                myAnimator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetButtonDown("Attack"))
            {
                StartCoroutine(AttackCo());
            }
        }
        else
        {
            playerRigid.velocity = Vector2.zero;
        }
        
    }

    private IEnumerator AttackCo()
    {
        myAnimator.SetBool("attacking", true);
        yield return null;
        myAnimator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.3f);
    }
}
