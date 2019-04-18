using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleScript : MonoBehaviour
{[SerializeField] List<GameObject> ListOfPoints = new List<GameObject>();


    [SerializeField] GameObject PH7Flash;
    [SerializeField] GameObject PH10Flash;
    [SerializeField] GameObject PH7Bottle;
    [SerializeField] GameObject PH10Bottle;
    [SerializeField] GameObject ProbePt;
    [SerializeField] GameObject MoveDownPt;
    [SerializeField] GameObject MoveRightPt;
    [SerializeField] GameObject PH7LidPt;
    [SerializeField] GameObject PH10LidPt;
    [SerializeField] GameObject PH7LidTop;
    [SerializeField] GameObject PH10LidTop;
    [SerializeField] GameObject PH7LidOgPos;
    [SerializeField] GameObject PH10LidOgPos;
    [SerializeField] GameObject SolutionWaterPt;
    [SerializeField] float lerpTime;

    [SerializeField] bool lerping;
    [SerializeField] int count;

    int currentStartPoint;
    float journeyLength;
    float startTime;
    float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        currentStartPoint = 0;

         lerping = true;
        FlashDisAppear(PH7Flash);
        FlashDisAppear(PH10Flash);
        count = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
        if (lerping == true)
        {
            lerpTime += Time.deltaTime;
            switch (count)
            {
                case 0:
                    LerpObj(PH7LidTop, ListOfPoints[count], .4f * lerpTime);
                    if (0.4f * lerpTime >=1)
                    {
                        count++;
                        lerpTime = 0;
                    }
                    break;


                case 1:

                    LerpObj(PH7Bottle, ListOfPoints[count], .4f * lerpTime);

                    if (0.4f * lerpTime >= 1)
                    {
                        count++;
                        lerpTime = 0;
                    }
                    break;

                case 2:

                    LerpObj(PH7Bottle, ListOfPoints[count], .4f * lerpTime);

                    if (0.4f * lerpTime >= 1)
                    {
                        count++;
                        lerpTime = 0;
                    }
                    break;

                case 3:

                    LerpObj(PH7Bottle, ListOfPoints[count], .4f * lerpTime);

                    if (0.4f * lerpTime >= 1)
                    {
                        count++;
                        lerpTime = 0;
                    }
                    break;

                case 4:
                    LerpObj(PH7Bottle, ListOfPoints[count], .4f * lerpTime);
                    if (0.4 * lerpTime >=1)
                    {
                        count++;
                        lerpTime = 0;
                        
                    }
                    break;

                case 5:
                    LerpObj(PH7Bottle, ListOfPoints[count], .4f * lerpTime);
                    if (0.4 * lerpTime >=1)
                    {
                        count++;
                        lerpTime = 0;
                    }
                    break;


                case 6:
                    LerpObj(PH7Bottle, ListOfPoints[count], .4f * lerpTime);
                    if (0.4 * lerpTime >=1)
                    {
                        count++;
                        lerpTime = 0;
                    }

                    break;

                case 7:
                    LerpObj(PH7LidTop, ListOfPoints[count], .4f * lerpTime);
                    if (0.4 * lerpTime >=1)
                    {
                        PH7LidTop.transform.parent = PH7Bottle.transform;
                        count++;
                        lerpTime = 0;
                    }
                    break;

                    //DIFFERENT BOTTLE
                case 8:
                    LerpObj(PH10LidTop, ListOfPoints[count], .4f * lerpTime);
                    if (0.4 * lerpTime >=1)
                    {
                        count++;
                        lerpTime = 0;
                    }
                    break;

                case 9:
                    LerpObj(PH10Bottle, ListOfPoints[count], .4f * lerpTime);
                    if (0.4 * lerpTime >=1)
                    {
                        count++;
                        lerpTime = 0;
                    }
                    break;


                case 10:
                    LerpObj(PH10Bottle, ListOfPoints[count], .4f * lerpTime);
                    {
                        if (0.4 * lerpTime >=1)
                        {
                            count++;
                            lerpTime = 0;
                        }
                    }

                    break;


                case 11:
                    LerpObj(PH10Bottle, ListOfPoints[count], .4f * lerpTime);

                    if (0.4 * lerpTime >=1)
                    {
                        count++;
                        lerpTime = 0;
                    }

                    break;

                case 12:
                    LerpObj(PH10Bottle, ListOfPoints[count], .4f * lerpTime);
                    if (0.4 * lerpTime >= 1)
                    {
                        count++;
                        lerpTime = 0;
                    }
                    break;

                case 13:
                    LerpObj(PH10Bottle, ListOfPoints[count], .4f * lerpTime);
                    if (0.4 * lerpTime >= 1)
                    {
                        count++;
                        lerpTime = 0;
                    }
                    break;


                case 14:
                    LerpObj(PH10Bottle, ListOfPoints[count], .4f * lerpTime);
                     if (0.4 * lerpTime >= 1)
                    {
                        count++;
                        lerpTime = 0;
                    }
                    break;

                case 15:
                    LerpObj(PH10LidTop, ListOfPoints[count], .4f * lerpTime);
                    if (0.4 * lerpTime >=1)
                    {
                        PH10LidTop.transform.parent = PH10Bottle.transform;
                        count++;
                        lerpTime = 0;
                    }
                    break;


                case 16:
                    LerpObj(PH7Bottle, ListOfPoints[count], .4f * lerpTime);
                    if(0.4 * lerpTime >=1)
                    {
                        count++;
                        lerpTime = 0;
                    }
                    break;

                case 17:
                    LerpObj(PH7Bottle, ListOfPoints[count], .4f * lerpTime);
                    if (0.4 * lerpTime >= 1)
                    {
                        count++;
                        lerpTime = 0;
                    }
                    break;

                case 18:
                    LerpObj(PH10Bottle, ListOfPoints[count], .4f * lerpTime);
                    if (0.4 * lerpTime >=1)
                    {
                        count++;
                        lerpTime = 0;
                    }
                    break;

                case 19:
                    LerpObj(PH10Bottle, ListOfPoints[count], .4f * lerpTime);
                    if (0.4 * lerpTime >=1)
                    {
                        count++;
                        lerpTime = 0;
                    }
                    break;
                
               
            }

        }


   /*  Vector3 LerpPosOne =Vector3.Lerp(PH7Bottle.transform.position, MoveDownPt.transform.position, .6f * lerpTime);

       PH7Bottle.transform.position = LerpPosOne;


       Vector3 LerpPosTwo = Vector3.Lerp(LerpPosOne, MoveRightPt.transform.position, .6f * lerpTime);
       PH7Bottle.transform.position = LerpPosTwo;

       Vector3 LerpPosThree = Vector3.Lerp(LerpPosTwo, ProbePt.transform.position, .6f * lerpTime); */



        /* float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        PH10Bottle.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        if (fracJourney >=1f && currentStartPoint + 1 < waypoints.Length)
        {
            currentStartPoint++;
            SetPoints();
        } */



        /*if (lerping == true && count ==0)
        { lerpTime += Time.deltaTime;
            LerpObj(PH7Bottle, MoveDownPt, .6f * lerpTime);
            LerpObj(PH7Bottle, MoveRightPt, .6f * lerpTime);
            LerpObj(PH7Bottle, ProbePt, .6f * lerpTime);
         
        } */

    }

    public void FlashAppear(GameObject ObjToFlash)
    {
        ObjToFlash.SetActive(true);
    }


    public void FlashDisAppear(GameObject ObjToDisappear)
    {
        ObjToDisappear.SetActive(false);
    }

    public void LerpObj(GameObject LerpObj, GameObject LerpPt, float speed)
    {
        LerpObj.transform.position = Vector3.Lerp(LerpObj.transform.position, LerpPt.transform.position, speed);
    }

    void SetPoints()
    {
    
    }
}
