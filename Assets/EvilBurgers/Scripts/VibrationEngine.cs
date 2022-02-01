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
#if UNITY_ANDROID && !UNITY_EDITOR
            androidVibrationWrapper.Initialize();
#elif UNITY_IOS && !UNITY_EDITOR

            iosVibrationWrapper.Initialize();
#endif
        }

        public void PlayCustomVibro(long milliseconds, int amplitude)
        {
#if UNITY_ANDROID //&& !UNITY_EDITOR
            androidVibrationWrapper.AndroidOneShotVibration(milliseconds, amplitude);
            androidVibrationWrapper.Initialize();
#elif UNITY_IOS //&& !UNITY_EDITOR

           // iosVibrationWrapper.PlayCustom();
#endif
            
        }

        public void PlayTyped(EVibrationType type)
        {
#if UNITY_ANDROID //&& !UNITY_EDITOR
            
#elif UNITY_IOS //&& !UNITY_EDITOR

            iosVibrationWrapper.PlayHaptic(type);
#endif
        }

        public void PlayLightImpact()
        {
#if UNITY_ANDROID //&& !UNITY_EDITOR
            androidVibrationWrapper.AndroidOneShotVibration(AndroidPredifinedVariables.lightImpactDuration,AndroidPredifinedVariables.lightImpactAmplitude);
#elif UNITY_IOS //&& !UNITY_EDITOR

            //iosVibrationWrapper.pla();
#endif

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

