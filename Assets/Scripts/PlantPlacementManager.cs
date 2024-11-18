using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlantPlacementManager : MonoBehaviour
{
    public GameObject[] flowerPrefabs;
    public ARSessionOrigin sessionOrigin;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    void Update()
    {
        if(Input.GetTouch(0).phase == TouchPhase.Began){
            // shoot Raycast
            // place the game object randomly
            // disable plane and plane manager

            bool collision = raycastManager.Raycast(Input.mousePosition, raycastHits, TrackableType.PlaneWithinPolygon);

            if(collision){
                GameObject clonePrefab = Instantiate(flowerPrefabs[Random.Range(0, flowerPrefabs.Length-1)]);
                clonePrefab.transform.position = raycastHits[0].pose.position;
            }

            foreach(var plane in planeManager.trackables){
                plane.gameObject.SetActive(false);
            }
            planeManager.enabled = false;
        }
    }

}
