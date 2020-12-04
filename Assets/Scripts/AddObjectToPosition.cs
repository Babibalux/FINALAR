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

    public ARPlaneManager planeManager;
    private ARAnchorManager AnchorManager;

    private Vector3 touchPosition;
    private GameObject touchedGameObject;

    private bool terrainIsPlaced;

    public LayerMask PlaneLayer;
    public LayerMask InteractibleLayer;

    private ARRaycastManager arRaycastManager;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    private bool isTouchingEmplacement;
    private ELC_CursorProperties cursorScript;
    private ELC_hand handScript;

    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        cursorScript = FindObjectOfType<ELC_CursorProperties>();
        handScript = FindObjectOfType<ELC_hand>();
        AnchorManager = FindObjectOfType<ARAnchorManager>();
    }

    void Update()
    {
        if (!terrainIsPlaced) UpdatePlacementPoseStart();
        else UpdatePlacementDuringGame();
        UpdatePlacementIndicator();

        isTouchingEmplacement = cursorScript.cursorTouchEmplacement;



        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPosition = Input.touches[0].position;
            touchedGameObject = TouchDetection(touchPosition);

            if (placementPoseIsValid)
            {
                if (touchedGameObject == null)
                {
                    if (!terrainIsPlaced)
                    {
                        SpawnObjectOnCursor(boardgame);
                        terrainIsPlaced = true;
                        planeManager.enabled = false;
                        foreach (var plane in planeManager.trackables)
                        {
                            plane.gameObject.SetActive(false);
                        }
                    }
                    //else
                    //{
                    //    SpawnObjectOnCursor(objectToPlace);
                    //}
                }

                
            }
            if (handScript.playerHoldSomething && touchedGameObject != null && touchedGameObject != handScript.inHandObject) handScript.inHandObject.GetComponent<FCO_GlobalObjectScript>().UseBehaviour(touchedGameObject, handScript.inHandObject);
            else if (placementPoseIsValid && handScript.playerHoldSomething && touchPosition.x < Screen.width / 2 && touchPosition.y < Screen.height / 2) handScript.PutObjectOnGround();
            else if (touchedGameObject != null && !handScript.playerHoldSomething && touchedGameObject != handScript.inHandObject) handScript.AddObjectToHand(touchedGameObject);

        }
    }

    public void SpawnObjectOnCursor(GameObject GO)
    {
        if (!terrainIsPlaced)
        {
            GameObject boardGO = Instantiate(GO, placementPose.position, placementPose.rotation);
            if(boardGO.GetComponent<ARAnchor>() == null) boardGO.AddComponent<ARAnchor>();
        }

        if (isTouchingEmplacement)
        {
            GameObject emplacementObject = Instantiate(GO, cursorScript.touchedObject.transform.position, placementPose.rotation);
            if (emplacementObject.GetComponent<ARAnchor>() == null) emplacementObject.AddComponent<ARAnchor>();

        }
        else
        {
            GameObject newGO = Instantiate(GO, placementPose.position, placementPose.rotation);
            if (newGO.GetComponent<ARAnchor>() == null) newGO.AddComponent<ARAnchor>();
        }
    }

    public void PlaceObjectOnCursor(GameObject GO)
    {
        GO.transform.SetParent(null);
        if (isTouchingEmplacement) GO.transform.position = cursorScript.touchedObject.transform.position;
        else GO.transform.position = placementPose.position;
        GO.transform.rotation = placementPose.rotation;
        if (GO.GetComponent<ARAnchor>() == null) GO.AddComponent<ARAnchor>();
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
            placementPose.rotation = Quaternion.LookRotation(new Vector3 (cameraBearing.x, 0, cameraBearing.y));
        }
        else placementPoseIsValid = false;
    }

    private GameObject TouchDetection(Vector3 TouchedScreenPosition)
    {
        RaycastHit raycast;
        Ray ray = Camera.current.ScreenPointToRay(TouchedScreenPosition);

        if(Physics.Raycast(ray, out raycast, 1000, InteractibleLayer))
        {
            return raycast.collider.gameObject;
        }
        else return null;
    }




}