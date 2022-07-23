using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : MonoBehaviour
{
    public int level;
    public int experience;
    public int experienceToNextLevel;
    public int health;
    public int attack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveDamage(int damage)
    {
        this.health -= damage;
        if (this.health <= 0)
        {
            this.gameObject.SetActive(false);
        }
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
        
    }

    public void MinusExperience(int amount)
    {
        this.experience = Math.Max(this.experience - amount, 0);
    }

}
