using System.Runtime.InteropServices;
using UnityEngine;
#if UNITY_IOS
using UnityEngine.iOS;
#endif
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace EasyHaptic_EvilBurgers
{
    public sealed class VibrationEngine
    {
        AndroidVibrationWrapper androidVibrationWrapper = new AndroidVibrationWrapper();
        IosVibrationWrapper iosVibrationWrapper = new IosVibrationWrapper();

        [RuntimeInitializeOnLoadMethod]
        public void GloablInitialize()
        {
            androidVibrationWrapper.Initialize();

            iosVibrationWrapper.Initialize();
        }

        public void PlayCustomVibro(long milliseconds, int amplitude)
        {
            androidVibrationWrapper.AndroidOneShotVibration(milliseconds, amplitude);
        }

        public void PlayLightImpact()
        {
            androidVibrationWrapper.AndroidOneShotVibration(AndroidPredifinedVariables.lightImpactDuration,AndroidPredifinedVariables.lightImpactAmplitude);
        }

        public void PlayMediumImpact()
        {
            androidVibrationWrapper.AndroidOneShotVibration(AndroidPredifinedVariables.mediumImpactDuration, AndroidPredifinedVariables.mediumImpactAmplitude);
        }

        public void PlayHeavyImpact()
        {
            androidVibrationWrapper.AndroidOneShotVibration(AndroidPredifinedVariables.heavyImpactDuration, AndroidPredifinedVariables.heavyImpactAmplitude);
        }

        public void PlaySuccessPattern()
        {
            androidVibrationWrapper.AndroidWaveformVibration(AndroidPredifinedVariables.successPatternDuration, AndroidPredifinedVariables.successPatternAmplitude);
        }

        public void PlayWarningPattern()
        {
            androidVibrationWrapper.AndroidWaveformVibration(AndroidPredifinedVariables.warningPatternDuration, AndroidPredifinedVariables.warningPatternAmplitude);
        }

        public void PlayFailurePattern()
        {
            androidVibrationWrapper.AndroidWaveformVibration(AndroidPredifinedVariables.failurePatternDuration, AndroidPredifinedVariables.failurePatternAmplitude);
        }
    }
}

