﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using CnControls;

public class Starn_menu : MonoBehaviour {

    public string NextScen;

    public GameObject messege_box;
    bool is_true;

	// Use this for initialization
	void Start () {
        is_true = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (CnInputManager.GetButtonDown("Game"))
        {
            Application.LoadLevel(NextScen);
        }
        else if (CnInputManager.GetButtonDown("Ophens"))
        {

        }
        else if (CnInputManager.GetButtonDown("Exit"))
        {
            if (EditorUtility.DisplayDialog(title, message, "Yes", "No"))
            {

            }
            else
            {

            }
        }
        

	}
}
