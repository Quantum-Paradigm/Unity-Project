using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class PlantSpawner : MonoBehaviour
{
    public GameObject plantPrefab; // Assign your plant prefab here
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    private GameObject spawnedPlant;
    private Vector2 initialTouchPosition;
    private float initialTouchDistance;
    private Vector3 initialScale;

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount == 1) // Move object
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                initialTouchPosition = touch.position;

                if (arRaycastManager.Raycast(touch.position, hitResults, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hitResults[0].pose;

                    if (spawnedPlant == null)
                    {
                        SpawnPlant(hitPose.position);
                    }
                    else
                    {
                        MovePlant(hitPose.position);
                    }
                }
            }
        }
        else if (Input.touchCount == 2) // Scale object
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
            {
                initialTouchDistance = Vector2.Distance(touch0.position, touch1.position);
                initialScale = spawnedPlant.transform.localScale;
            }
            else if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
            {
                float currentTouchDistance = Vector2.Distance(touch0.position, touch1.position);
                float scaleMultiplier = currentTouchDistance / initialTouchDistance;

                ScalePlant(initialScale * scaleMultiplier);
            }
        }
    }

    void SpawnPlant(Vector3 spawnPosition)
    {
        spawnedPlant = Instantiate(plantPrefab, spawnPosition, Quaternion.identity);

        // Set an initial scale for the plant
        float initialScale = 0.1f; // Adjust as needed
        spawnedPlant.transform.localScale = new Vector3(initialScale, initialScale, initialScale);

        // Move it slightly above the ground
        spawnedPlant.transform.position += new Vector3(0, 0.1f, 0);
    }

    void MovePlant(Vector3 newPosition)
    {
        if (spawnedPlant != null)
        {
            spawnedPlant.transform.position = newPosition + new Vector3(0, 0.1f, 0);
        }
    }

    void ScalePlant(Vector3 newScale)
    {
        if (spawnedPlant != null)
        {
            spawnedPlant.transform.localScale = newScale;
        }
    }
}
