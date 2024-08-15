using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class APIManager : MonoBehaviour
{
    public static APIManager Instance { get; private set; }

    public readonly string base_url = "http://127.0.0.1:5000/"; // Update this to the correct URL

    private void Awake()
    {
        // Ensure there's only one instance of APIManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PredictPlantImage(string stage, string light, int temperature, int watering)
    {
        if (Instance == null)
        {
            Debug.LogError("APIManager instance is null.");
            return;
        }

        var request = new
        {
            stage = stage,
            light = light,
            temperature = temperature,
            watering = watering
        };

        string json = JsonConvert.SerializeObject(request);
        Debug.Log(json);
        StartCoroutine(PostData("predict_api", json, ResponsePredictPlantImage));
    }

    private IEnumerator PostData(string api, string data, System.Action<Dictionary<string, object>> callback)
    {
        if (Instance == null)
        {
            Debug.LogError("APIManager instance is null while posting data.");
            yield break;
        }

        string url = base_url + api;
        Debug.Log(url);

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);

        using (UnityWebRequest www = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST))
        {
            www.uploadHandler = new UploadHandlerRaw(bytes);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("accept", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string results = www.downloadHandler.text;
                Debug.Log(results);

                Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(results);
                if (Instance != null)
                {
                    callback?.Invoke(values);
                }
            }
        }
    }

    private void ResponsePredictPlantImage(Dictionary<string, object> values)
    {
        if (values != null)
        {
            if (values.TryGetValue("image", out var imageNameObj))
            {
                string imageName = imageNameObj.ToString();
                Debug.Log($"Predicted Plant Image: {imageName}");

                UIManager uiManager = FindObjectOfType<UIManager>();
                if (uiManager != null)
                {
                    uiManager.DisplayPlantImage(imageName);

                    if (values.TryGetValue("coins_collected", out var coinsObj))
                    {
                        int coinsCollected = int.Parse(coinsObj.ToString());
                        uiManager.DisplayCoinsCollected(coinsCollected);
                    }

                    // Get the scene name from the API response
                    if (values.TryGetValue("scene", out var sceneNameObj))
                    {
                        string sceneName = sceneNameObj.ToString();
                        Debug.Log($"Scene to Load: {sceneName}");
                        SceneManager.LoadScene(sceneName);
                    }
                    else
                    {
                        Debug.LogError("Failed to get a valid 'scene' from the response.");
                    }
                }
                else
                {
                    Debug.LogError("UIManager not found.");
                }
            }
            else
            {
                Debug.LogError("Failed to get a valid 'image' from the response.");
            }
        }
        else
        {
            Debug.LogError("Failed to get a valid response from the AI model.");
        }
    }
}
