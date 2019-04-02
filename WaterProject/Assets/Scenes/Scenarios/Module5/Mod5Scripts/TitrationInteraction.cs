using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitrationInteraction : MonoBehaviour
{
    [SerializeField] GameObject BottomButtonPivot;
    [SerializeField] Quaternion buttonRot;
    [SerializeField] GameObject TopButtonPivot;
    [SerializeField] GameObject ObjToMov;
    [SerializeField, Range(0, 360)] float[] PivotAngles;
    [Space]
    [Space]
    [SerializeField] GameObject PotasJar;
    [SerializeField] GameObject agitator;
    [Space]
    [Space]

   
    bool knobRotate;
   // [SerializeField] float knobEulerAngle;
    float knobA;
    float knobB;
    float knobC;
    float speed = 80f;
    List<float> KnobValues = new List<float>();
   [SerializeField] int Knob;
    bool JarAppear;

    


    // Start is called before the first frame update
    void Start()
    {
       // JarAppear = true;


        Knob = 0;
        knobA = 156.6f;
        knobB = 192.5f;
        knobC = 142.9f;

       
        KnobValues.Add(knobA);
        KnobValues.Add(knobB);
        KnobValues.Add(knobC);

       


    


        // knobRotate = true;
        //float speed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) { knobRotate = true; }
       // if (knobRotate) { KnobMovement(BottomButtonPivot, PivotAngles[Knob], speed); }
        if (Input.GetKeyDown(KeyCode.G)) { JarAppear = true; }
        if (JarAppear) { MovePotassiumJar(); }

  
        

   
       
        //float test = Time.deltaTime;
      
    }

    public void KnobMovement(GameObject ObjToMov, float pivotAngles, float speed)
    {
       if (Knob >= PivotAngles.Length) { knobRotate = false; }
        ObjToMov.transform.Rotate(0, 0, speed * Time.deltaTime);
       float  knobEulerAngle = ObjToMov.transform.eulerAngles.z;
       

        if (Mathf.Abs(knobEulerAngle - pivotAngles) < 1f) 
        {
            Knob++;
            knobRotate = false;
           
        }

    }




    public void MovePotassiumJar()
    {
       // PotasJar.transform.position = Vector3.Lerp(PotasJar.transform.position, agitator.transform.position - new Vector3(0, 1.0f, -1.1f), 1 * Time.deltaTime * 3);

        //PotasJar.transform.position + new Vector3((agitator.transform.position.x - .5f), 0, 0), 1 * Time.deltaTime * 3);

        //agitator.transform.position - new Vector3(-.147f, 0, 0)), 1 * Time.deltaTime * 3);

        // - new Vector3(0, .3904078f,0), (1 * Time.deltaTime * 3 ));

       // JarAppear = false;



    }


}
