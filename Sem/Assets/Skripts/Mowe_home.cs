using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mowe_home : MonoBehaviour, IPointerDownHandler
{
    public GameObject particle;
    private RaycastHit hit;
    public float smoothTime = 1.3F;
    private float yVelocity = 0.1F;
    // Use this for initialization
    void Start () {
		
	}
    public void OnPointerDown(PointerEventData eventData)
    {

        Debug.Log(eventData.position);

    }
    void Move()
    {

    }
    void Touches()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


                if (Physics.Raycast(ray, out hit))
                {
                    //  particle.transform.Translate(new Vector3(particle.transform.position.x, particle.transform.position.y, particle.transform.position.z));
                    Debug.Log(particle.transform.position.x + " 1 " + particle.transform.position.z);
                    Debug.Log(hit.point + " --");



                    float newPosition_x = Mathf.SmoothDamp(particle.transform.position.x, hit.point.x, ref yVelocity, smoothTime);
                    float newPosition_z = Mathf.SmoothDamp(particle.transform.position.z, hit.point.z, ref yVelocity, smoothTime);

                    Debug.Log(newPosition_x + " " + newPosition_z);
                    particle.transform.position = Vector3.Lerp(particle.transform.position, hit.point, smoothTime);


                }

            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        Touches();
    }
}
