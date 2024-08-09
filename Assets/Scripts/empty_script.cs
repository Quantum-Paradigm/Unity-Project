using UnityEngine;
using UnityEngine.UI;

public class PlantSelector : MonoBehaviour
{
    public GameObject[] plantPrefabs; // Assign plant prefabs here
    private GameObject selectedPlantPrefab;

    public void SelectPlant(int index)
    {
        if (index >= 0 && index < plantPrefabs.Length)
        {
            selectedPlantPrefab = plantPrefabs[index];
            Debug.Log("Selected plant: " + plantPrefabs[index].name);
        }
    }

    public GameObject GetSelectedPlantPrefab()
    {
        return selectedPlantPrefab;
    }
}