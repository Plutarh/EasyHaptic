using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyHaptic_EvilBurgers;
using UnityEngine.UI;
using System;

public class Test : MonoBehaviour
{

    public InputField millisecondsInput;
    public InputField amplitudeInput;
    public InputField sharpnessInput;

    public Text amplitudeControll;

    public Button btnPrefab;

    public Gradient buttonsColor;

    public GameObject buttonsGroup;

    List<Button> allButtons = new List<Button>();

    private void Awake() 
    {
        CreateTestButtons();
        SetButtonsColor();
    }

    void CreateTestButtons()
    {
        foreach (EVibrationType type in (EVibrationType[])Enum.GetValues(typeof(EVibrationType)))
        {
            Button createdBtn = Instantiate(btnPrefab,buttonsGroup.transform);

            createdBtn.GetComponentInChildren<Text>().text = type.ToString();

            createdBtn.onClick.AddListener(() => EasyHaptic.Play(type));
            allButtons.Add(createdBtn);
        }

        btnPrefab.gameObject.SetActive(false);
    }

    void SetButtonsColor()
    {
        for (int i = 0; i < allButtons.Count; i++)
        {
            var btn = allButtons[i];

            float lerpredValue = (float)i / (float)allButtons.Count;
            Color lerpedColor = buttonsColor.Evaluate(lerpredValue);
            btn.GetComponent<Image>().color = lerpedColor;
        }
    }

    public void PlayCustom()
    {
        long customDurationInSeconds = 0;
        int customAmplitude = 0;
        float sharpness = 0;

        customDurationInSeconds = long.Parse(millisecondsInput.text);
        customAmplitude = int.Parse(amplitudeInput.text);
        sharpness = float.Parse(sharpnessInput.text);

        CustomVibrationData customData = new CustomVibrationData();
        customData.amplitude = customAmplitude;
        customData.durationInSeconds = customDurationInSeconds;
        customData.sharpness = sharpness;

        EasyHaptic.PlayCustom(customData);
    }
}
