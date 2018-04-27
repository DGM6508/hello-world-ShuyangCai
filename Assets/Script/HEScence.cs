using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEScence : MonoBehaviour {


    public GUISkin menuSkin;
    public Rect menuArea;
    public Rect restartButton;

    Rect menuAreaNormalized;
    string menuPage = "main";

    void Awake()
    {
        Screen.lockCursor = false;

        Cursor.visible = true;
        menuAreaNormalized =
            new Rect(menuArea.x * Screen.width - (menuArea.width * 0.5f), menuArea.y * Screen.height - (menuArea.height * 0.5f), menuArea.width, menuArea.height);
    }
    void OnGUI()
    {
        GUI.skin = menuSkin;
        GUI.BeginGroup(menuAreaNormalized);
        GUI.skin.button.fontSize = 32;

        if (GUI.Button(new Rect(restartButton), "Restart"))
        {
            Application.LoadLevel("MenuScene");
        }


        GUI.EndGroup();
    }
}
