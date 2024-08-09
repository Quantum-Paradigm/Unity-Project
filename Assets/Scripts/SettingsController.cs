using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Button soundButton;          // Reference to the sound button
    public Button musicButton;          // Reference to the music button
    public Image soundMuteIcon;         // Reference to the sound mute icon
    public Image musicMuteIcon;         // Reference to the music mute icon

    private bool isSoundMuted = false;  // Track the sound mute state
    private bool isMusicMuted = false;  // Track the music mute state

    private void Start()
    {
        // Ensure the mute icons are initially inactive
        soundMuteIcon.gameObject.SetActive(false);
        musicMuteIcon.gameObject.SetActive(false);

        // Add listeners to the buttons
        soundButton.onClick.AddListener(ToggleSound);
        musicButton.onClick.AddListener(ToggleMusic);
    }

    private void ToggleSound()
    {
        isSoundMuted = !isSoundMuted;  // Toggle the mute state
        soundMuteIcon.gameObject.SetActive(isSoundMuted);  // Show/hide the mute icon
        Debug.Log("Sound Muted: " + isSoundMuted);  // Log the state for testing
    }

    private void ToggleMusic()
    {
        isMusicMuted = !isMusicMuted;  // Toggle the mute state
        musicMuteIcon.gameObject.SetActive(isMusicMuted);  // Show/hide the mute icon
        Debug.Log("Music Muted: " + isMusicMuted);  // Log the state for testing
    }
}
