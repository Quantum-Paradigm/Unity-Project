using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // Import this for scene management

public class UIManager : MonoBehaviour
{
    public Button testButton; // Assign this in the inspector
    public TMP_Dropdown stageDropdown;
    public TMP_Dropdown lightDropdown;
    public TMP_Dropdown temperatureDropdown;
    public TMP_Dropdown wateringDropdown;

    private void Start()
    {
        if (testButton != null)
        {
            testButton.onClick.AddListener(OnTestButtonClick);
        }
        else
        {
            Debug.LogError("TestButton is not assigned.");
        }

        // Initialize dropdown options
        InitializeDropdownOptions();
    }

    private void InitializeDropdownOptions()
    {
        // Example options, replace with your actual options
        stageDropdown.AddOptions(new List<string> { "Seedling", "Juvenile", "Mature", "Flowering", "Spiderettes" });
        lightDropdown.AddOptions(new List<string> { "bright_indirect", "direct_sunlight", "low_light" });

        // Initialize temperature dropdown with a range from 10 to 35
        List<string> temperatureOptions = new List<string>();
        for (int i = 10; i <= 35; i++)
        {
            temperatureOptions.Add(i.ToString());
        }
        temperatureDropdown.AddOptions(temperatureOptions);

        // Initialize watering dropdown with a range from 1 to 11
        List<string> wateringOptions = new List<string>();
        for (int i = 1; i <= 11; i++)
        {
            wateringOptions.Add(i.ToString());
        }
        wateringDropdown.AddOptions(wateringOptions);
    }

    public void OnTestButtonClick()
    {
        if (APIManager.Instance != null)
        {
            // Retrieve values from dropdowns
            string stage = stageDropdown.options[stageDropdown.value].text;
            string light = lightDropdown.options[lightDropdown.value].text;
            int temperature = int.Parse(temperatureDropdown.options[temperatureDropdown.value].text);
            int watering = int.Parse(wateringDropdown.options[wateringDropdown.value].text);

            // Debug logs to verify values
            Debug.Log($"Stage: {stage}");
            Debug.Log($"Light: {light}");
            Debug.Log($"Temperature: {temperature}");
            Debug.Log($"Watering: {watering}");

            // Call API method
            APIManager.Instance.PredictPlantImage(stage, light, temperature, watering);

            // Debug log to confirm API call
            Debug.Log("API call made to PredictPlantImage");
        }
        else
        {
            Debug.LogError("APIManager instance is not available.");
        }
    }

    public void DisplayPlantImage(string imageName)
    {
        // Your implementation for displaying the plant image
        Debug.Log($"Displaying plant image: {imageName}");
    }

    public void DisplayCoinsCollected(int coins)
    {
        // Your implementation for displaying coins collected
        Debug.Log($"Coins collected: {coins}");
    }

    // Method to change scene based on the stage
    public void ChangeSceneBasedOnStage(string stage)
    {
        string sceneName = GetSceneNameForStage(stage);
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is invalid or not found.");
        }
    }

    private string GetSceneNameForStage(string stage)
    {
        // Map stages to scenes
        switch (stage)
        {
            case "Seedling": return "Scene1";
            case "Juvenile": return "Scene2";
            case "Mature": return "Scene3";
            case "Flowering": return "Scene4";
            case "Spiderettes": return "Scene5";
            case "Withered": return "WitheredScene";
            case "ExtremeWithered": return "ExtremeWitheredScene";
            case "Dead": return "DeadScene";
            default: return null;
        }
    }
}
