using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mowe_home : MonoBehaviour, IPointerDownHandler
{
    public GameObject particle;
    // Use this for initialization
    void Start () {
		
	}
    public void OnPointerDown(PointerEventData eventData)
    {

        Debug.Log(eventData.position);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray);
            if (Physics.Raycast(ray))
            {
                particle.transform.Translate(new Vector3(ray.direction.x, ray.direction.y, ray.direction.z) * Time.deltaTime);
              
            }

            //Instantiate(particle, transform.position, transform.rotation);
           
            //  transform.localScale *= 1.1f;
        }
    }
}
