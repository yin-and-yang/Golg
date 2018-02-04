using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDA_Camera : MonoBehaviour {
    public GameObject Player;
    public float offsetX = 0;
    public float offsetZ = -5;
    public float PlayerVelocity = 5;
    private float movementX;
    private float movementZ;


    public float RoffsetX = 0;
    public float RoffsetZ = -5;
    private float RmovementX;
    private float RmovementZ;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        movementX = ((Player.transform.position.x + offsetX - this.transform.position.x));
        movementZ = ((Player.transform.position.z + offsetZ - this.transform.position.z));

        RmovementX = ((Player.transform.rotation.x + RoffsetX - this.transform.rotation.x));
        RmovementZ = ((Player.transform.rotation.z + RoffsetZ - this.transform.rotation.z));

        this.transform.position += new Vector3((movementX * PlayerVelocity * Time.deltaTime), 0, (movementZ * PlayerVelocity * Time.deltaTime));
        //this.transform.rotation = new Quaternion(RmovementX,0, RmovementZ,0);

    }
}
