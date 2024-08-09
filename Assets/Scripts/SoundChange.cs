using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundChange : MonoBehaviour
{
    private Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;
    private bool isSoundOn = true;
    // Start is called before the first frame update
    void Start()
    {
        soundOnImage = button.image.sprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick(){
        if (isSoundOn) {
            button.image.sprite = soundOffImage;
            isSoundOn = false;
        } else {
            button.image.sprite = soundOnImage;
            isSoundOn = true;
        }
    }
}
