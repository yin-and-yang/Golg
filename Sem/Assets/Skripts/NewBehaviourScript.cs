using CnControls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       if( CnInputManager.GetButtonDown("Look"))
            UnityEngine.Debug.Log("Look ");
        
        
    }
}
