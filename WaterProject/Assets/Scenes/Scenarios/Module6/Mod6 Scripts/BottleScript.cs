using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleScript : MonoBehaviour
{
    [SerializeField]GameObject PH7Flash;
    [SerializeField]GameObject PH10Flash;
    [SerializeField] GameObject PH7Bottle;
    [SerializeField] GameObject PH10Bottle;
    [SerializeField] GameObject ProbePt;
    float lerpTime;
    bool lerping;
    // Start is called before the first frame update
    void Start()
    {
        lerping = true;
        FlashDisAppear(PH7Flash);
        FlashDisAppear(PH10Flash);

        
    }

    // Update is called once per frame
    void Update()
    { if (lerping)
        { lerpTime += Time.deltaTime;
            Vector3.Lerp(PH10Bottle.transform.position, ProbePt.transform.position,1);
        }
        
    }

    public void FlashAppear(GameObject ObjToFlash)
    {
        ObjToFlash.SetActive(true);
    }


    public void FlashDisAppear(GameObject ObjToDisappear)
    {
        ObjToDisappear.SetActive(false);
    }
}
