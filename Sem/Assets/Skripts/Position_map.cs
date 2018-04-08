using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Position_map : MonoBehaviour {

    public List<string> map;
    int indecs;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Select_map(int i)
    {
        indecs = i;
    }
}
