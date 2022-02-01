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

            return;
            switch (vibrationType)
            {
                case EVibrationType.LightImpact:
                    vibrationEngine.PlayLightImpact();
                    break;
                case EVibrationType.MediumImpact:
                    vibrationEngine.PlayMediumImpact();
                    break;
                case EVibrationType.HeavyImpact:
                    vibrationEngine.PlayHeavyImpact();
                    break;
                case EVibrationType.Success:
                    vibrationEngine.PlaySuccessPattern();
                    break;
                case EVibrationType.Warning:
                    vibrationEngine.PlayWarningPattern();
                    break;
                case EVibrationType.Failure:
                    vibrationEngine.PlayFailurePattern();
                    break;
            }
        }

        public static void PlayCustom(long duration, int amplitude)
        {

#if UNITY_EDITOR
            return;
#endif
            vibrationEngine.PlayCustomVibro(duration,amplitude);
        }
    }
}

public enum EVibrationType
{
    LightImpact,
    MediumImpact,
    HeavyImpact,
    Success,
    Warning,
    Failure
}

