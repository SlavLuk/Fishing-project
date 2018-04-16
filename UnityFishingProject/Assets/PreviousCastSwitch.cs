using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviousCastSwitch : MonoBehaviour {

    public Text button_text;
    private bool buttonPressed = false;
    public GameObject sphere;
    public GameObject sphere2;
    public GameObject onScreenText;
    public GameObject next;
    public GameObject previous;


    public void PressButton() {

        if (this.buttonPressed == true)
        {
            ShowHide(true);

            this.button_text.text = "View Previous Casts";
            this.buttonPressed = false;

        }
        else
        {
            ShowHide(false);
            
            this.buttonPressed = true;
            this.button_text.text = "Back to Live cast";

        }

    }

    public bool GetButtonStatus() {

        return this.buttonPressed;
    }

    public void SetButtonStatus(bool status)
    {

        this.buttonPressed= status;
    }

    public void ShowHide(bool state) {

        sphere.SetActive(state);
        sphere2.SetActive(!state);
        onScreenText.SetActive(state);
        next.SetActive(!state);
        previous.SetActive(false);

    }

}
