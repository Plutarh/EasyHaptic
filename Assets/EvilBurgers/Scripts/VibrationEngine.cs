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


        public void TestVibro()
        {
            if (androidVibrationWrapper.isActivityInitialized == false)
                androidVibrationWrapper.Initialize();


            androidVibrationWrapper.AndroidOneShotVibration(40, 80);
        }

        public void PlayCustomVibro(long milliseconds, int amplitude)
        {
            if (androidVibrationWrapper.isActivityInitialized == false)
                androidVibrationWrapper.Initialize();

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

        public void PlaySuccessPattern()
        {
            androidVibrationWrapper.AndroidWaveformVibration(AndroidPredifinedVariables.successPatternDuration, AndroidPredifinedVariables.successPatternAmplitude);
        }

        public void PlayFailurePattern()
        {
            androidVibrationWrapper.AndroidWaveformVibration(AndroidPredifinedVariables.failurePatternDuration, AndroidPredifinedVariables.failurePatternAmplitude);
        }
    }
}

