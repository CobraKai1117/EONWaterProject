using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropScript : MonoBehaviour
{ public bool WaterDropStart;
    [SerializeField] GameObject WaterDropPart;
    [SerializeField] GameObject WaterDropPos;
    [SerializeField] GameObject dropper;
    // Start is called before the first frame update
    void Start()
    {
        WaterDropStart = true;
        
    }

    // Update is called once per frame
    void Update()
    { if (WaterDropStart)
        {
          
           transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            transform.localRotation = Quaternion.Euler(-65f, -90f, 0f);
            transform.Translate(new Vector3(0.5f, -1, 0) / 100, Space.World);
             
            //MoveDrop(dropper.transform.position, WaterDropPos.transform.position, T, 0.01f);
            Destroy(gameObject, 1);

        }

    }
}
