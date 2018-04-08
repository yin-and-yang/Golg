using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using CnControls;
//using UnityEditor;

public class Starn_menu : MonoBehaviour {

    #region Pole
    enum Status
    {
        Indecs,ophens, message
    }
    public List<string> NextScen;
    int number_map = 0;

    public GameObject ophens;
    public GameObject indecs;
    public GameObject messege_box;
    Status position_map;
    bool is_true;

    #region Audio
    public AudioClip[] FootSteps;   
    public AudioSource audioSource;  
    #endregion Audio

    #endregion Pole
    // Use this for initialization
    void Start () {
        is_true = false;
        position_map = Status.Indecs;
        ophens.active = false;
        indecs.active = true;
        messege_box.active = false;
    }

    #region Data
    void Save()
    {

    }
    void Load()
    {

    }
    #endregion Data

    #region 
   public void Start_Game()
    {
        Application.LoadLevel(NextScen[number_map]);
    }
    public void Start_Ophens()
    {
        indecs.active = false;
        ophens.active = true;
        messege_box.active = false;
        position_map = Status.ophens;
    }
    public void Start_Indecs()
    {
        indecs.active = true;
        ophens.active = false;
        messege_box.active = false;
        position_map = Status.Indecs;
    }
    public void Start_message()
    {       
        messege_box.active = true;
        position_map = Status.message;
    }


    public void Message_OK()
    {
        Exit();
    }
    public void Message_NO()
    {
        Start_Indecs();
    }

    void Exit()
    {
        Application.Quit();
    }
    public void Back()
    {
        switch (position_map)
        {
            case Status.Indecs:

                Start_message();

                break;
            case Status.ophens:


                Start_Indecs();


                break;
            case Status.message:


                break;

        }
    }
  


    #endregion

    // Update is called once per frame
    void FixedUpdate() {

      
    
     

	}
}
