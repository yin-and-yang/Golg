using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down_Pol : MonoBehaviour {

    public GameObject unit;
     GameObject start_unit;
    public float point;


	// Use this for initialization
	void Start () {
        start_unit = unit;

    }
	
	// Update is called once per frame
	void Update () {
        unit.transform.localScale = new Vector3(start_unit.transform.localScale.x, start_unit.transform.localScale.y);

    }
}
