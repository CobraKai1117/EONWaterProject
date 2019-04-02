using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperInteraction : MonoBehaviour
{
    [SerializeField] GameObject dropper;
    [SerializeField] Camera cam;
    [SerializeField] Transform indicator;

    Vector3 dist;
    Vector3 startPos;
    float posX;
    float posZ;
    float posY;

    // Start is called before the first frame update
    void Start()
    {
        indicator.gameObject.SetActive(true);
        //cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
      
        Vector3 screenPos = cam.WorldToScreenPoint(Input.mousePosition);
       
       // Debug.Log("The target is" + screenPos.x + "pixels from the left");

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // get the touch position from the screen touch to world point
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
            }
        }

    }
  




    void OnMouseDown()
    {
        startPos = transform.position;
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;
        posZ = Input.mousePosition.z - dist.z;
    }

    void OnMouseDrag()
    {
        float disX = Input.mousePosition.x - posX;
        float disY = Input.mousePosition.y - posY;
        float disZ = Input.mousePosition.z - posZ;
        Vector3 lastPos = Camera.main.ScreenToWorldPoint(new Vector3(disX, disY, disZ));
        transform.position = new Vector3(lastPos.x, lastPos.y, startPos.z);
    }
}
