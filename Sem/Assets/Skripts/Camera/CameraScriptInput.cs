using CnControls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptInput : MonoBehaviour {

	// Use this for initialization
    public CameraScript _object;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (CnInputManager.GetButtonUp("RButton"))
        _object.MoweCam(false);
        else if (CnInputManager.GetButtonUp("LButton"))
        _object.MoweCam(true);

    }
}
