using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionScript : MonoBehaviour
{[SerializeField] GameObject WaterTransform;
    [SerializeField] GameObject ScriptReference;
    public bool interactable;
    Vector3 dist;
    Vector3 startPos;
    float posX;
    float posZ;
    float posY;
    // Start is called before the first frame update
    void Start()
    {
        ScriptReference.GetComponent<DropperInteraction>().FlashDisappear(WaterTransform);
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

            if (startPos == WaterTransform.transform.position)
            {
                //DropperInteraction.FlashDisappear(WaterTransform);
                ScriptReference.GetComponent<DropperInteraction>().FlashDisappear(WaterTransform);
            }
       
            dist = Camera.main.WorldToScreenPoint(transform.position);

            Vector3 dist2 = Camera.main.WorldToScreenPoint(transform.position);
      

            posX = Input.mousePosition.x - dist.x;


            posY = Input.mousePosition.y - dist.y;

            posZ = Input.mousePosition.z - dist.z;

            Debug.Log(startPos);



        }
    }

   public  void OnMouseDrag()
    {
        if (interactable)
        {

            float disX = Input.mousePosition.x - posX;
            float disY = Input.mousePosition.y - posY;
            float disZ = Input.mousePosition.z - posZ;
            Vector3 lastPos = Camera.main.ScreenToWorldPoint(new Vector3(disX, disY, disZ));
            transform.position = new Vector3(lastPos.x, startPos.y, startPos.z);

        }
    }
}
