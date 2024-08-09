using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlantSpawner : MonoBehaviour
{
    public GameObject[] plantPrefabs; // Array to hold different growth stage prefabs
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // Detect touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Perform a raycast
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;

                    // Check if the detected surface is a table (e.g., horizontal plane with a certain height range)
                    if (hitPose.position.y < 1.0f && hitPose.position.y > 0.5f) // Adjust height range as needed
                    {
                        // Randomly select a plant prefab to spawn
                        GameObject selectedPlant = plantPrefabs[Random.Range(0, plantPrefabs.Length)];
                        Instantiate(selectedPlant, hitPose.position, hitPose.rotation);
                    }
                }
            }
        }
    }
}
