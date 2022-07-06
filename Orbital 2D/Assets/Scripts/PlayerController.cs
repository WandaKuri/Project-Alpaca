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
    public int level;
    public int experience;
    public int experienceToNextLevel;
    public ExpBar expbar;
    
    private static readonly int MoveX = Animator.StringToHash("moveX");
    private static readonly int MoveY = Animator.StringToHash("moveY");
    private static readonly int LastMoveX = Animator.StringToHash("lastMoveX");
    private static readonly int LastMoveY = Animator.StringToHash("lastMoveY");

    private Transform bottomLeftBox;
    private Transform topRightBox;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

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
        playerRigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        myAnimator.SetFloat(MoveX, playerRigid.velocity.x);
        myAnimator.SetFloat(MoveY, playerRigid.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.AddExperience(20); // Placeholder for testing Experience & Leveling
        }
        
        if (Mathf.Approximately(Input.GetAxisRaw("Horizontal"), 1)
            || Mathf.Approximately(Input.GetAxisRaw("Horizontal"), -1)
            || Mathf.Approximately(Input.GetAxisRaw("Vertical"), 1)
            || Mathf.Approximately(Input.GetAxisRaw("Vertical"), -1))
        {
            myAnimator.SetFloat(LastMoveX, Input.GetAxisRaw("Horizontal"));
            myAnimator.SetFloat(LastMoveY, Input.GetAxisRaw("Vertical"));
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
    
    
    public void AddExperience(int amount)
    {
        this.experience += amount;
        if (this.experience >= this.experienceToNextLevel)
        {
            this.level++;
            this.experience -= this.experienceToNextLevel;
            this.experienceToNextLevel = Convert.ToInt32(this.experienceToNextLevel * 1.2);
        }
        this.expbar.SetExp(this.experience);
        this.expbar.SetExperienceToNextLevel(this.experienceToNextLevel);
    }

    public void MinusExperience(int amount)
    {
        this.experience = Math.Max(this.experience - amount, 0);
        this.expbar.SetExp(this.experience);
    }
    
}
