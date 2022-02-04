using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyHaptic_EvilBurgers;
using UnityEngine.UI;
using System;

#if UNITY_IOS 
using UnityEngine.iOS;
#endif

public class Test : MonoBehaviour
{

    [SerializeField] private InputField millisecondsInput;
    [SerializeField] private InputField amplitudeInput;
    [SerializeField] private InputField sharpnessInput;

    [SerializeField] private Text systemInfo;
    [SerializeField] private Button btnPrefab;
    [SerializeField] private Gradient buttonsColor;
    [SerializeField] private GameObject buttonsGroup;


    List<Button> allButtons = new List<Button>();

    [SerializeField] CustomVibrationData data;

    private void Start() {
        Init();
    }

    public void PlayCustomVibration()
    {
        long customDurationInSeconds = 0;
        float customAmplitude = 0;
        float sharpness = 0;

        long.TryParse(millisecondsInput.text, out customDurationInSeconds);
        float.TryParse(amplitudeInput.text, out customAmplitude);
        float.TryParse(sharpnessInput.text, out sharpness);

        CustomVibrationData customData = new CustomVibrationData();
        customData.amplitude = customAmplitude;
        customData.durationInSeconds = customDurationInSeconds;
        customData.sharpness = sharpness;

        Debug.Log($"Try play custom vibro - {customData}");

        EasyHaptic.PlayCustom(customData);
    }

    void Init()
    {
#if UNITY_ANDROID
        sharpnessInput.gameObject.SetActive(false);
#elif UNITY_IOS
        sharpnessInput.gameObject.SetActive(true);
#endif

        CreatePredifinedButtons();
        SetButtonsColor();
        ShowSystemInfo();
    }

    void CreatePredifinedButtons()
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
        if(allButtons.Count == 0)
        {
            Debug.LogError("Predifined buttons not created, please check all prefab refs");
            return;
        }

        for (int i = 0; i < allButtons.Count; i++)
        {
            var btn = allButtons[i];

            float lerpredValue = (float)i / (float)allButtons.Count;
            Color lerpedColor = buttonsColor.Evaluate(lerpredValue);
            btn.GetComponent<Image>().color = lerpedColor;
        }
    }

    void ShowSystemInfo()
    {
        string customUse = " Cannot support custom vibrations";

        string sysInfo = $"Device Name - {SystemInfo.deviceName} \n ";
        sysInfo += $"Device model - {SystemInfo.deviceModel} \n";
        sysInfo += $"OS version - {SystemInfo.operatingSystem}";

#if UNITY_ANDROID
        string androidAmplitudeController = "not support";
        bool amplitudeSupport = EasyHaptic.vibrationEngine.SupportAmplitudeController();

        if (amplitudeSupport)
            androidAmplitudeController = "<color=green>Support</color>";
        else
            androidAmplitudeController = "<color=red>Not Support</color> \n <color=yellow> You can play with duration value</color>";

        sysInfo += $" \n \n \n Amplitude Controller - {androidAmplitudeController}";
#endif
        systemInfo.text = sysInfo;
    }

    
}
