using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{

    public GameObject theMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (theMenu.activeInHierarchy)
            {
                theMenu.SetActive(false);
                PlayerController.instance.setMovement(true);
                Enemy.setMovement(true);
            }
            else
            {
                theMenu.SetActive(true);
                PlayerController.instance.setMovement(false);
                Enemy.setMovement(false);
            }
        }
    }

    public void Close()
    {
        if (theMenu.activeInHierarchy)
        {
            theMenu.SetActive(false);
            PlayerController.instance.setMovement(true);
            Enemy.setMovement(true);
        }
        else
        {
            theMenu.SetActive(true);
            PlayerController.instance.setMovement(false);
            Enemy.setMovement(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
