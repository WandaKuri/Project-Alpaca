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
    private static readonly int MoveX = Animator.StringToHash("moveX");
    private static readonly int MoveY = Animator.StringToHash("moveY");
    private static readonly int LastMoveX = Animator.StringToHash("lastMoveX");
    private static readonly int LastMoveY = Animator.StringToHash("lastMoveY");
    public LevelSystem levelSystem;

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
        this.levelSystem = new LevelSystem();
        levelSystem.expbar.SetExp(0);
        levelSystem.expbar.SetExperienceToNextLevel(100);
    }

    // Update is called once per frame
    void Update()
    {
        playerRigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        myAnimator.SetFloat(MoveX, playerRigid.velocity.x);
        myAnimator.SetFloat(MoveY, playerRigid.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            levelSystem.AddExperience(20);
        }
        
        if (Mathf.Approximately(Input.GetAxisRaw("Horizontal"), 1)
            || Mathf.Approximately(Input.GetAxisRaw("Horizontal"), -1)
            || Mathf.Approximately(Input.GetAxisRaw("Vertical"), 1)
            || Mathf.Approximately(Input.GetAxisRaw("Vertical"), -1))
        {
            myAnimator.SetFloat(LastMoveX, Input.GetAxisRaw("Horizontal"));
            myAnimator.SetFloat(LastMoveY, Input.GetAxisRaw("Vertical"));
        }
    }
}
