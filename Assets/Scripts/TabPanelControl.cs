using UnityEngine;
using UnityEngine.UI;

public class TabPanelController : MonoBehaviour
{
    public GameObject shopButton;
    public GameObject tabPanel;
    public GameObject homePageBackground;
    public GameObject closeButton;

    private Image homePageImage;

    private void Start()
    {
        // Ensure the tab panel is initially inactive
        tabPanel.SetActive(false);

        // Add listener to the shop button
        shopButton.GetComponent<Button>().onClick.AddListener(OpenTabPanel);

        // Add listener to the close button
        closeButton.GetComponent<Button>().onClick.AddListener(CloseTabPanel);

        // Get the Image component of the home page background
        homePageImage = homePageBackground.GetComponent<Image>();
    }

    public void OpenTabPanel()
    {
        tabPanel.SetActive(true);
        // Apply a light opacity overlay to the home page background
        homePageImage.color = new Color(homePageImage.color.r, homePageImage.color.g, homePageImage.color.b, 0.5f); // semi-transparent overlay
    }

    public void CloseTabPanel()
    {
        tabPanel.SetActive(false);
        // Remove the overlay by setting the color to fully opaque
        homePageImage.color = new Color(homePageImage.color.r, homePageImage.color.g, homePageImage.color.b, 1f); // fully opaque
    }
}
