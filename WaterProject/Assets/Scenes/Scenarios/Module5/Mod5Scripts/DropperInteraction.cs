using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DropperInteraction : MonoBehaviour
{
    [SerializeField] GameObject dropper;
    [SerializeField] Camera cam;
    [SerializeField] Transform indicator;
    [SerializeField] GameObject agitator;
    [SerializeField] Material FlashMat;
    [SerializeField] GameObject Sample;
    [SerializeField] GameObject Dropper2;
    [SerializeField] GameObject H20drop;
    [SerializeField] GameObject WaterDropPos;
    [SerializeField] GameObject TestOb;
    [SerializeField] GameObject SolutionJar;
    [SerializeField] GameObject DropOgPos;
    [SerializeField] GameObject ParentOfWaterDropper;
    [Space]
    [Space]
    [SerializeField] SolutionScript SolutionJarScript;
    [SerializeField] ParticleSystem WaterPart;


    //[SerializeField, Range(0,360)] float[] PivotAngles;

    bool interactable;

    Vector3 dist;
    Vector3 startPos;
    float posX;
    float posZ;
    float posY;
    float distBetweenTwoPoints;
    float dropZAx;
    bool RotationStart;
    [SerializeField] GameObject DropPos;
    public static Camera mainCam;
    public static Vector2 prevMousePos;
    float speed;
    float speed2;
    int dropCount = 0;
    float T = 0f;
    public SolutionScript MoveSolution;
    int WaterDropRun;
    bool FuncRun;
    float ang;
    float angleRot;
    float RotTrans;
    ParticleSystem Test;

    float Timer;

    float test;

    bool TimerRun;

    bool WaterWait;

    //bool FirstRun;

    int RunCount;

    ParticleSystem C;

    [SerializeField] GameObject H20Part;

    [SerializeField] Color32 WaterColor1;
    [SerializeField] Color32 WaterColor2;
    [SerializeField] Color32 WaterColor3;
    [SerializeField] Color32 WaterColor4;
    [SerializeField] Color32 WaterColor5;

 

    float Timer2;

    int timesClicked;
    int count;

    List<Color> WaterMaterials = new List<Color>();

    Material CurrentWaterColor;

    // Start is called before the first frame update
    void Start()
    {
        //  FirstRun = true;
        WaterMaterials.Add(WaterColor1);
        WaterMaterials.Add(WaterColor2);
        WaterMaterials.Add(WaterColor3);
        WaterMaterials.Add(WaterColor4);
        WaterMaterials.Add(WaterColor5);

        dropCount = 0;

        Timer = 0;
        timesClicked = 1;
        speed = 70f;
        interactable = true;
        ColumnAppear();
        dropZAx = 52;
        WaterDropRun = 0;
        speed2 = 0;



        Test = WaterPart.GetComponent<ParticleSystem>();
        Test.Pause(true);

        FlashAppear(Dropper2);
        FlashDisappear(SolutionJar);

        count = 0;

        RunCount = 1;


    }

    // Update is called once per frame
    void Update()
    {

        test = Time.deltaTime;


        if (TimerRun)
        {

            //C = Instantiate(Test);
            C.Play();
            Timer += test;

            if (Timer > 1.0f)
            {
                Renderer WaterCol = H20Part.GetComponent<Renderer>();

                TimerRun = false;
                C.IsAlive(false);
                Destroy(C.gameObject);
                timesClicked = 1;
                Debug.Log("TIMER 2" + Timer);
                ResetTimer(Timer);

                count++;

                if (RunCount == 1)
                {

                    WaterCol.material.SetColor("_FoamColor", WaterMaterials[count]);
                    WaterCol.material.SetColor("_DepthGradientDeep", WaterMaterials[count]);
                    WaterCol.material.SetColor("_DepthGradientShallow", WaterMaterials[count]);
                    Debug.Log("COUNT" + count);
                        //= WaterMaterials[count];

                }

                if (RunCount == 2)
                {
                    WaterCol.material.color = WaterMaterials[0];
                  /*  WaterCol.material.color = WaterMaterials[count--];

                    if (WaterMaterials.Count <= 0)
                    {
                        WaterCol.material.color = WaterMaterials[0];
                    } */
                }

            }
        }


        if (WaterWait)
        {
         
            Timer2 += test;
            if (Timer2 >= 0.5f && WaterDropRun == 1)
            {
                MoveDrop(dropper.transform.position, DropOgPos.transform.position, dropper, 1f);
                speed = -70f;
                //float RotTrans = ParentOfWaterDropper.transform.eulerAngles.z;

                RotateObj(ParentOfWaterDropper, 100, ParentOfWaterDropper.transform.eulerAngles.z);
                float RotTrans = ParentOfWaterDropper.transform.eulerAngles.z;

                Debug.Log(RotTrans);

                if (Math.Abs(RotTrans - 2) < 2)
                {
                    WaterDropRun++;
                    speed = 0;
                    WaterWait = false;

                }
            }
        }
        // test = Time.deltaTime;

        //if (FuncRun) { MoveDrop(dropper.transform.position, DropOgPos.transform.position, dropper, 1f, 50f,70f); }
        //GlobalFunctions.ColorFlash(FlashMat, Color.yellow, 0.1f, 0.24f);

        Vector3 screenPos = cam.WorldToScreenPoint(Input.mousePosition);
        /*  if (WaterDropRun == 1)
          {
              speed = 70f;
              RotateObj(dropper, 100,dropper.transform.eulerAngles.z);
              float RotTrans = dropper.transform.eulerAngles.z;

              if (Math.Abs(RotTrans- 180) <2)
              {
                  WaterDropRun++;
                  speed = 0;

              }


          } */



        // Debug.Log("The target is" + screenPos.x + "pixels from the left");

        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // get the touch position from the screen touch to world point
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
            }
        } */

        distancetoSample(dropper.transform.position, agitator.transform.position);
        // T += Time.deltaTime;
        //Debug.Log(T);



    }


    void OnMouseDown()
    {
        if (interactable)
        {
            FlashDisappear(Dropper2);

            startPos = transform.position;

            dist = Camera.main.WorldToScreenPoint(transform.position);

            posX = Input.mousePosition.x - dist.x;

            posY = Input.mousePosition.y - dist.y;

            posZ = Input.mousePosition.z - dist.z;




        }
    }

    void OnMouseDrag()
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

    /* public static bool SlideObjectHorizontal(Transform itemToMove, Transform pointToLockTo, Transform currentParent, float speedMult, float maxDist, float activationDist)
     {
         if (itemToMove.parent != pointToLockTo)
             itemToMove.parent = pointToLockTo;

         pointToLockTo.LookAt(mainCam.transform);
         pointToLockTo.forward = new Vector3(-pointToLockTo.forward.x, 0, -pointToLockTo.forward.z).normalized;

         float moveDist = 0;
         if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0))
             moveDist = (Input.mousePosition.x - prevMousePos.x) * speedMult;

         itemToMove.localPosition = new Vector3(itemToMove.localPosition.x + moveDist, itemToMove.localPosition.y, 0);

         if (Mathf.Abs(itemToMove.localPosition.x) > maxDist)
             itemToMove.localPosition = new Vector3(maxDist * Mathf.Sign(itemToMove.localPosition.x), itemToMove.localPosition.y, 0);

         if (Vector2.Distance(new Vector2(itemToMove.position.x, itemToMove.position.z), new Vector2(pointToLockTo.position.x, pointToLockTo.position.z)) < activationDist)
         {
             itemToMove.parent = currentParent;
             return true;
         }
         return false;
     } */








    public void ColumnAppear() // Makes marker for agitator appear
    {
        indicator.gameObject.SetActive(true);
    }


    public void ColumnDisappear() // Makes marker for agitator disappear
    {
        indicator.gameObject.SetActive(false);
    }

    public void distancetoSample(Vector3 pointA, Vector3 pointB) // Checks to see if distance between point A and B is small enough, if it is you can't move dropper any more
    {

        distBetweenTwoPoints = Vector3.Distance(pointA, pointB);
        //Debug.Log(distBetweenAgDrop);
        //  Vector3 newDropPos = dropper.transform.position + new Vector3(0, .2f, 0);
        if (distBetweenTwoPoints <= 1f)
        {
            ColumnDisappear();
            interactable = false;


            // Invoke("MoveDrop", .2f);  // Waits a small amount of time before running MoveDrop function
        }

        if (distBetweenTwoPoints <= 1 && pointA == dropper.transform.position && pointB == agitator.transform.position)
        {
            interactable = false;
            // Invoke("MoveDrop", .2f); 
            // WaterWait = true;
            MoveDrop(dropper.transform.position, DropPos.transform.position, dropper, .5f);
           
        }

    }

    public void MoveDrop(Vector3 startPos, Vector3 endPos, GameObject objToMov, float rate)
    {
        objToMov.transform.position = Vector3.Lerp(startPos, endPos, rate);

        if (WaterDropRun == 0)
        {
            RotateObj(ParentOfWaterDropper, 50, ParentOfWaterDropper.transform.eulerAngles.z);
        }

    }

    public void RotateObj(GameObject RotObj, float ang, float RotPoint) //Rotates a GameObject that you select by an angle you want to rotate it to and what axis you want to rotate represented by RotPoint
    {
        RotationStart = true;

        if (RotationStart)
        {
            RotObj.transform.Rotate(0, 0, speed * Time.deltaTime); // This rotates dropper so it properly faces solution

            //float RotPoint = RotObj.transform.eulerAngles.z;
            RotTrans = RotPoint;
            angleRot = ang;


            if (Mathf.Abs(RotPoint - ang) < 2) // Tells program to stop rotating object once the axis reaches the desired angle
            {
                // speed = 0;
                RotationStart = false; // Ensures that rotation stops once dropper is rotated at a certain angle to solution
                if (RotationStart == false) { speed = 0; }


                if (RunCount == 1)
                {

                    WaterDrop(4);
                }

            }

        }
    }



    public void WaterDrop(int dropCount) // Adds drops from dropper to solution
    {

        var y = Test.shape;

        y.position = new Vector3(-0.008f, 0, 0);

        if (count < dropCount)
        {

            if (Input.GetMouseButtonDown(0) && timesClicked == 1)
            {
                Debug.Log(Timer);
                TimerRun = true;
                C = Instantiate(Test);
                Timer = 0;
                timesClicked++;

            }

        }

        if (count >= dropCount)
        {
            MoveSolution.interactable = true;
            MoveSolution.OnMouseDown();
            MoveSolution.OnMouseDrag();
            FlashAppear(SolutionJar);
            WaterDropRun++;
            Timer2 = 0;
            Timer = 0;
            WaterWait = true;
            count = 0;

        }

    }

    public void FlashAppear(GameObject ObjWFlash)
    {
        interactable = true;
        ObjWFlash.SetActive(true);
    }

    public void FlashDisappear(GameObject FlashRem)
    {
        FlashRem.SetActive(false);
    }


    public void ResetTimer(float time)
    {
        time = 0f;

    }


}






