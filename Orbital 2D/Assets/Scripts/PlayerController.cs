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
    
    private bool canMove = true;
    public Transform bottomLeftBox;
    public Transform topRightBox;
    public Vector3 bottomLeftLimit;
    public Vector3 topRightLimit;

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
        topRightLimit = new Vector3(topRightBox.position.x, topRightBox.position.y, topRightBox.position.z);
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

        recheck();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);

    }

    public void setMovement(bool canMove)
    {
        this.canMove = canMove;
    }

    private IEnumerator AttackCo()
    {
        myAnimator.SetBool("attacking", true);
        yield return null;
        myAnimator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.3f);
    }

    private void recheck()
    {
        bottomLeftBox = GameObject.FindGameObjectWithTag("bottomLeft").transform;
        topRightBox = GameObject.FindGameObjectWithTag("topRight").transform;
        bottomLeftLimit = new Vector3(bottomLeftBox.position.x, bottomLeftBox.position.y, bottomLeftBox.position.z);
        topRightLimit = new Vector3(topRightBox.position.x, topRightBox.position.y, topRightBox.position.z);
    }
}
