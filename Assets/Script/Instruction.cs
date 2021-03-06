﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour {



    public GUISkin menuSkin;
    public Rect menuArea;
    public Rect backButton;

    Rect menuAreaNormalized;
    string menuPage = "main";

    void Start()
    {

        menuAreaNormalized =
            new Rect(menuArea.x * Screen.width - (menuArea.width * 0.5f), menuArea.y * Screen.height - (menuArea.height * 0.5f), menuArea.width, menuArea.height);
    }
    void OnGUI()
    {
        GUI.skin = menuSkin;
        GUI.BeginGroup(menuAreaNormalized);
        GUI.skin.button.fontSize = 32;

        if (GUI.Button(new Rect(backButton), "Back"))
        {
            Application.LoadLevel("MenuScene");
        }


        GUI.EndGroup();
    }


}

