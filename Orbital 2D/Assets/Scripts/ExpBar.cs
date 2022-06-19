using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider slider;

    // public ExpBar()
    // {
    //     this.slider.value = 0;
    //     this.slider.maxValue = 100;
    // }

    public void SetExp(int experience)
    {
        this.slider.value = experience;
    }

    public void SetExperienceToNextLevel(int experience)
    {
        this.slider.maxValue = experience;
    }
}
