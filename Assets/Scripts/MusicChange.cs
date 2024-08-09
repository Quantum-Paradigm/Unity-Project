using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicChange : MonoBehaviour
{
    private Sprite musicOnImage;
    public Sprite musicOffImage;
    public Button button;
    private bool isMusicOn = true;
    // Start is called before the first frame update
    void Start()
    {
        musicOnImage = button.image.sprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick(){
        if (isMusicOn) {
            button.image.sprite = musicOffImage;
            isMusicOn = false;
        } else {
            button.image.sprite = musicOnImage;
            isMusicOn = true;
        }
    }
}
