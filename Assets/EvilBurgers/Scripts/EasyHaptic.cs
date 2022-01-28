namespace EasyHaptic_EvilBurgers
{
    public static class EasyHaptic
    {
        public static VibrationEngine vibrationEngine = new VibrationEngine();

      

        public static void  Play(EVibrationType vibrationType)
        {
            switch (vibrationType)
            {
                case EVibrationType.LightImpact:
                    vibrationEngine.PlayLightImpact();
                    break;
                case EVibrationType.MediumImpact:
                    vibrationEngine.PlayMediumImpact();
                    break;
                case EVibrationType.HeavyImpact:
                    break;
                case EVibrationType.Success:
                    vibrationEngine.PlaySuccessPattern();
                    break;
                case EVibrationType.Warning:
                    break;
                case EVibrationType.Failure:
                    vibrationEngine.PlayFailurePattern();
                    break;
            }
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

