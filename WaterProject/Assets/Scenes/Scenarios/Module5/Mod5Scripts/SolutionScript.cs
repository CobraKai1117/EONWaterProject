using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionScript : MonoBehaviour
{
    public bool interactable;
    Vector3 dist;
    Vector3 startPos;
    float posX;
    float posZ;
    float posY;
    // Start is called before the first frame update
    void Start()
    {
       // interactable = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (interactable)
        {
           

           
            startPos = transform.position;
            Debug.Log(startPos);
            

            dist = Camera.main.WorldToScreenPoint(transform.position);

            Vector3 dist2 = Camera.main.WorldToScreenPoint(transform.position);
            Debug.Log("DISTANCE" + dist);

            Debug.Log("DISTANCE 2" + dist2);

            posX = Input.mousePosition.x - dist.x;

            Debug.Log("MOUSE INPUT" + Input.mousePosition.x);

            Debug.Log(posX);

            posY = Input.mousePosition.y - dist.y;

            Debug.Log(posY);

            posZ = Input.mousePosition.z - dist.z;

            Debug.Log(posZ);


        }
    }

   public  void OnMouseDrag()
    {
        if (interactable)
        {

            float disX = Input.mousePosition.x - posX;
            Debug.Log(disX + "FLOAT");
            float disY = Input.mousePosition.y - posY;
            float disZ = Input.mousePosition.z - posZ;
            Vector3 lastPos = Camera.main.ScreenToWorldPoint(new Vector3(disX, disY, disZ));
            transform.position = new Vector3(lastPos.x, startPos.y, startPos.z);

        }
    }
}
