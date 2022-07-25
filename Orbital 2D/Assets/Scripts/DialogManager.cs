using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class DialogManager : MonoBehaviour
{
    
    public UnityEngine.UI.Text dialogText;
    public UnityEngine.UI.Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;
    public int currentLine;

    public static DialogManager instance;
    public bool justStarted;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //dialogText.text = dialogLines[currentLine];
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!justStarted)
                {
                    currentLine++;

                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);
                        PlayerController.instance.setMovement(true);
                        Enemy.setMovement(true);
                    }
                    else
                    {
                        CheckIfName();

                        dialogText.text = dialogLines[currentLine];
                    }

                    dialogText.text = dialogLines[currentLine];
                } else
                {
                    justStarted = false;
                }
            }
        }
    }
    public void ShowDialog(string[] newLines)
    {
        dialogLines = newLines;

        currentLine = 0;

        CheckIfName();

        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);

        justStarted = true;

        PlayerController.instance.setMovement(false);
        Enemy.setMovement(false);
    }

    private void CheckIfName()
    {
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-","");
            currentLine++;
        }
    }
}
