using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI_gameobj : MonoBehaviour {

    public Slider slider;

    public Color backgroundColor;
    public Color fillColor;

    private Image backgroundImage;
    private Image fillImage;

    void OnEnable() {
        backgroundImage = slider.transform.Find("Background").GetComponent<Image>();
        fillImage = slider.transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
        ChangeColors(backgroundColor, fillColor);
    }

    public void ChangeColors(Color background, Color fill) {
        backgroundImage.color = background;
        fillImage.color = fill;
    }
}
