// using UnityEngine;
// using UnityEngine.Networking;
// using UnityEngine.UI;

// public class FlaskAPIConnector : MonoBehaviour
// {
//     public InputField stageInput;
//     public InputField lightInput;
//     public InputField temperatureInput;
//     public InputField wateringInput;
//     public InputField fertilizerInput;
//     public Text resultText;

//     [System.Serializable]
//     public class PredictionResponse
//     {
//         public float prediction;
//     }

//     public void SendDataToAPI()
//     {
//         // Gather input data
//         string stage = stageInput.text;
//         string light = lightInput.text;
//         int temperature = int.Parse(temperatureInput.text);
//         string watering = wateringInput.text;
//         string fertilizer = fertilizerInput.text;

//         // Create a JSON object with the input data
//         var data = new
//         {
//             stage = stage,
//             light = light,
//             temperature = temperature,
//             watering = watering,
//             fertilizer = fertilizer
//         };

//         string jsonData = JsonUtility.ToJson(data);
        
//         // Send request
//         StartCoroutine(SendRequest(jsonData));
//     }

//     private IEnumerator SendRequest(string jsonData)
//     {
//         using (UnityWebRequest www = new UnityWebRequest("http://localhost:5000/predict_api", "POST"))
//         {
//             byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
//             www.uploadHandler = new UploadHandlerRaw(bodyRaw);
//             www.downloadHandler = new DownloadHandlerBuffer();
//             www.SetRequestHeader("Content-Type", "application/json");

//             // Send the request
//             yield return www.SendWebRequest();

//             if (www.isNetworkError || www.isHttpError)
//             {
//                 Debug.LogError(www.error);
//                 resultText.text = "Error: " + www.error;
//             }
//             else
//             {
//                 // Parse the response
//                 string responseText = www.downloadHandler.text;
//                 PredictionResponse response = JsonUtility.FromJson<PredictionResponse>(responseText);
//                 resultText.text = $"Predicted Score: {response.prediction}";
//             }
//         }
//     }
// }
