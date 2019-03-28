using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackingMarker : MonoBehaviour, ITrackableEventHandler
{
    TrackableBehaviour mTrackableBehaviour;
    public Camera mainCam;
    bool scenarioHasStarted;
    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour = GameObject.Find("ImageTarget").GetComponent<TrackableBehaviour>();

        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);


        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if ((newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) && previousStatus == TrackableBehaviour.Status.NO_POSE && scenarioHasStarted == false)
        {
            Debug.Log("Starting story");
            scenarioHasStarted = true;
            StartCoroutine("SludgeJudgeStory");
        }
    }
}
