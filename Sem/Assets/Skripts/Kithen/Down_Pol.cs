using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down_Pol : MonoBehaviour {

    public GameObject unit;
    Vector3 now_unit_herow;
  

    public List<GameObject> start_unit;
    public float point;

    void Awake()
    {       
        now_unit_herow = new Vector3(unit.transform.position.x, unit.transform.position.y, unit.transform.position.z);
    }

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
      
        //mast

        
            unit.transform.localScale = new Vector3((unit.transform.position.z * 100 / now_unit_herow.z) / 100.0f + .1f
                , (unit.transform.position.z * 100 / now_unit_herow.z) / 100.0f + .1f, 
                .1f);

        //
         
    }

   
}
