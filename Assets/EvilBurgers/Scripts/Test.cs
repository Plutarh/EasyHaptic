using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyHaptic_EvilBurgers;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    

    public long customMilliseconds;
    public int customAmplitude;

    public InputField millisecondsInput;
    public InputField amplitudeInput;

    public Text amplitudeControll;


    // public void PlayCustom()
    // {
    //     customMilliseconds = 0;
    //     customAmplitude = 0;

    //     customMilliseconds = long.Parse(millisecondsInput.text);
    //     customAmplitude = int.Parse(amplitudeInput.text);

    //     EasyHaptic.PlayCustomVibro(customMilliseconds, customAmplitude);
    //     Debug.LogError($"Custom Vibro amplitude {customAmplitude} / duration {customMilliseconds}");

    //     amplitudeControll.text = $"Android API level - {AndroidVibrationWrapper.GetApiLevel()} \n Vibrator - {EasyHaptic.android.HasVibrator()} \n Amplitude Controll - {EasyHaptic.android.HasAmplitudeControl()}";
    // }

    public void SuccessPattern()
    {
        EasyHaptic.Play(EVibrationType.Success);
    }

    public void FailurePattern()
    {
        EasyHaptic.Play(EVibrationType.Failure);
    }

    public void LightImpact()
    {
        EasyHaptic.Play(EVibrationType.MediumImpact);
    }
}
