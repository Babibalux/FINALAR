using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class AddObjectToPosition : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject objectToPlace2;
    public GameObject placementIndicator;

    private ARRaycastManager arRaycastManager;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    private bool isTouchingEmplacement;
    private ELC_CursorProperties cursorScript;

    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        cursorScript = FindObjectOfType<ELC_CursorProperties>();

    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        isTouchingEmplacement = cursorScript.cursorTouchEmplacement;

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
        }
    }

    private void PlaceObject()
    {
        if (isTouchingEmplacement) Instantiate(objectToPlace2, cursorScript.touchedObject.transform.position, placementPose.rotation);
        else Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}