using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mowe_home1 : MonoBehaviour, IPointerDownHandler
{
    
    private RaycastHit hit;
    public float speed = 1.3F;
    private bool is_move = false;
    // Use this for initialization
    void Start () {
		
	}
    public void OnPointerDown(PointerEventData eventData)
    {

        Debug.Log(eventData.position);

    }
 
    void Touches()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began || Input.GetMouseButtonDown(0) )
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


                if (Physics.Raycast(ray, out hit))
                {
                    

                    if (hit.transform.gameObject.tag == "floor")
                    {
                        is_move = true;
                    }

                }
            }
        }
    }

    void Move()
    {
        if (is_move == true)
        {
            transform.position = Vector3.Lerp(transform.position, hit.point, Time.deltaTime * speed);
            if (transform.position == hit.point)
                is_move = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Touches();
        Move();

    }
}
