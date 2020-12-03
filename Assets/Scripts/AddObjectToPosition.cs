using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Experimental.XR;
using System;

public class AddObjectToPosition : MonoBehaviour
{
    public GameObject boardgame;
    public GameObject objectToPlace;
    public GameObject placementIndicator;

    private GameObject TouchedGameobject;

    public ARPlaneManager planeManager;

    private Vector3 touchPosition;

    private bool terrainIsPlaced;

    public LayerMask PlaneLayer;
    public LayerMask InteractibleLayer;

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
        if (!terrainIsPlaced) UpdatePlacementPoseStart();
        else UpdatePlacementDuringGame();
        UpdatePlacementIndicator();

        isTouchingEmplacement = cursorScript.cursorTouchEmplacement; //c'est au cas où il touche un objet mais oklm



        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPosition = Input.touches[0].position;

            if (placementPoseIsValid && TouchDetection(touchPosition) == null)
            {
                if (!terrainIsPlaced)
                {
                    PlaceObject();
                    terrainIsPlaced = true;
                    planeManager.enabled = false;
                }
                else
                {
                    PlaceObject();
                }
            }
        }
    }

    private void PlaceObject()
    {
        if(!terrainIsPlaced) Instantiate(boardgame, placementPose.position, placementPose.rotation);

        if (isTouchingEmplacement) Instantiate(objectToPlace, cursorScript.touchedObject.transform.position, placementPose.rotation);
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

    private void UpdatePlacementPoseStart()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    private void UpdatePlacementDuringGame()
    {
        RaycastHit raycast;
        Ray ray = Camera.current.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
        if (Physics.Raycast(ray, out raycast, 100, PlaneLayer))
        {
            placementPoseIsValid = true;
            placementPose.position = raycast.point;
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
        else placementPoseIsValid = false;
    }

    private GameObject TouchDetection(Vector3 TouchedScreenPosition)
    {
        RaycastHit raycast;
        Ray ray = Camera.current.ScreenPointToRay(TouchedScreenPosition);

        if(Physics.Raycast(ray, out raycast, 100, InteractibleLayer))
        {
            return raycast.collider.gameObject;
        }
        else return null;
    }


}