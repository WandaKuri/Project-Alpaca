using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{

    public Transform target;
    public float attackRadius;
    // Start is called before the first frame update
    void Start()
    {
        this.target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    void CheckDistance()
    {
        
    }
}
