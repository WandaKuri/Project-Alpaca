using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    private int level;
    private int experience;
    private int experienceToNextLevel;

    public LevelSystem()
    {
        this.level = 0;
        this.experience = 0;
        this.experienceToNextLevel = 100;
    }

    public int GetLevel()
    {
        return this.level;
    }

    public void AddExperience(int amount)
    {
        this.experience += amount;
        if (this.experience >= experienceToNextLevel)
        {
            this.level++;
            this.experience -= experienceToNextLevel;
            this.experienceToNextLevel = Convert.ToInt32(this.experienceToNextLevel * 1.2);
        }
    }

    public void MinusExperience(int amount)
    {
        this.experience = Math.Max(this.experience - amount, 0);
    }
}
