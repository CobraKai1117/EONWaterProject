using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitrationInteraction : MonoBehaviour
{
    [SerializeField] GameObject BottomButtonPivot;
   [SerializeField] Quaternion buttonRot;
    bool knobRotate;
   // [SerializeField] float knobEulerAngle;
    float knobA;
    float knobB;
    float knobC;
    float speed = 80f;
    List<float> KnobValues = new List<float>();
   [SerializeField] int Knob;

    


    // Start is called before the first frame update
    void Start()
    {
        Knob = 0;
        knobA = 156.6f;
        knobB = 192.5f;
        knobC = 142.9f;

       
        KnobValues.Add(knobA);
        KnobValues.Add(knobB);
        KnobValues.Add(knobC);

        Debug.Log(KnobValues[0]);
        Debug.Log(KnobValues[1]);
        Debug.Log(KnobValues[2]);


        buttonRot = BottomButtonPivot.transform.rotation;
     
        knobA = 156.6f;
        knobB = 192.5f;
        knobC = 142.9f;
       // knobRotate = true;
        //float speed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) { knobRotate = true; }
        if (knobRotate) { KnobMovement(KnobValues[Knob], speed); }
        

   
       
        //float test = Time.deltaTime;
      
    }

    public void KnobMovement( float knobValue, float speed)
    {
       if (Knob >= KnobValues.Count) { knobRotate = false; }
        // BottomButtonPivot.transform.RotateAround(BottomButtonPivot.transform.position, new Vector3(0, 0, 1), -20 * Time.deltaTime);
        BottomButtonPivot.transform.Rotate(0, 0, speed * Time.deltaTime);
       float  knobEulerAngle = BottomButtonPivot.transform.eulerAngles.z;
       


      

        if (Mathf.Abs(knobEulerAngle - knobValue) < 1f) 
        {
            Knob++;
            knobRotate = false;
           
        }


      



       
    }
}
