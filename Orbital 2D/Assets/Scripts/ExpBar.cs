using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        this.slider = GetComponent<Slider>();
    }

    public void SetExp(int experience)
    {
        this.slider.value = experience;
    }

    public void SetExperienceToNextLevel(int experience)
    {
        this.slider.maxValue = experience;
    }
}
