using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move_map : MonoBehaviour {

    // Use this for initialization
    public Position_map Now_map;

    public GameObject Now_cam;
    public GameObject End_cam;
    NavMeshAgent agent;

    public GameObject End_player;

    public int indecs;
	void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Player")
        {
            agent = col.GetComponent<NavMeshAgent>();
            Now_cam.transform.position = End_cam.transform.position;
          
            Now_map.Select_map(indecs);
            agent.Warp(new Vector3(End_player.transform.position.x + 3, End_player.transform.position.y, End_player.transform.position.z));
        }
    }
}
