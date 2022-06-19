using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    private int level;
    private int experience;
    private int experienceToNextLevel;
    public ExpBar expbar;

    public LevelSystem()
    {
        this.level = 0;
        this.experience = 0;
        this.experienceToNextLevel = 100;
        // this.expbar = new ExpBar();
    }

    public int GetLevel()
    {
        return this.level;
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
