namespace EasyHaptic_EvilBurgers
{
    public static class EasyHaptic
    {
        public static VibrationEngine vibrationEngine = new VibrationEngine();


        public static void Play(EVibrationType vibrationType)
        {
#if UNITY_EDITOR
            return;
#endif
            vibrationEngine.PlayTyped(vibrationType);
        }

        public static void PlayCustom(CustomVibrationData customVibration)
        {
#if UNITY_EDITOR
            return;
#endif
            vibrationEngine.PlayCustomVibro(customVibration);
        }
    }
}

// Predifined types, do not modify this. If wanna custom vibro use CustomVibrationData 
public enum EVibrationType
{
    LightImpact,
    MediumImpact,
    HeavyImpact,
    Success,
    Warning,
    Failure
}

[System.Serializable]
public class CustomVibrationData
{
    public double durationInSeconds;
    public float amplitude;

    /// <summary>
    /// <value> Sharpness only for IOS </value>-
    /// </summary>
    public float sharpness;
}

