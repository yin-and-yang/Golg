using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using CnControls;
//using UnityEditor;

public class Starn_menu : MonoBehaviour {

    public List<string> NextScen;

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
            Application.LoadLevel(NextScen[0]);
        }
        else if (CnInputManager.GetButtonDown("Ophens"))
        {

        }
        else if (CnInputManager.GetButtonDown("Exit"))
        {
           // if ()
          //  {
          
          //  }
         //   else
         //   {

          //  }
        }
        

	}
}
