using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    
    private TextMeshProUGUI textDisplay;
    private PlayerAttribute attributes;

    // Start is called before the first frame update
    void Start()
    {
        this.textDisplay = this.gameObject.GetComponent<TextMeshProUGUI>();
        this.attributes = GameObject.FindWithTag("Player").GetComponent<PlayerAttribute>();
        this.textDisplay.text = "Level: " + this.attributes.level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        this.textDisplay.text = "Level: " + this.attributes.level.ToString();
    }
}
