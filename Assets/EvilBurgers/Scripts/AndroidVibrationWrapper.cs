using UnityEngine;

namespace EasyHaptic_EvilBurgers
{
    public sealed class AndroidVibrationWrapper
    {
#if UNITY_ANDROID
        private AndroidJavaClass unityPlayerActivity;
        private AndroidJavaClass vibrationEffect;

        private AndroidJavaObject currentActivity;
        private AndroidJavaObject androidVibrator;
#endif

        internal bool isActivityInitialized;
        internal bool isVibroInitialized;

        public void Initialize()
        {
            InitMainActivity();
            InitVibration();
        }

        // Play one shot vibration 
        public void AndroidOneShotVibration(long milliseconds, int amplitude)
        {
            if (isVibroInitialized == false)
                InitVibration();

            // Maximum amplitude for android by https://developer.android.com/ is 255
            if(amplitude > 255) amplitude = 255; 

            AndroidJavaObject vibration = vibrationEffect.CallStatic<AndroidJavaObject>("createOneShot", new object[] { milliseconds, amplitude });

            androidVibrator.Call("vibrate", vibration);
        }

        // Play waveform vibration
        public void AndroidWaveformVibration(long[] millisecondsPattern, int[] amplitudesPattern, int repeat = -1)
        {
            if (isVibroInitialized == false)
                InitVibration();

            AndroidJavaObject vibration = vibrationEffect.CallStatic<AndroidJavaObject>("createWaveform", new object[] { millisecondsPattern, amplitudesPattern, repeat });

            androidVibrator.Call("vibrate", vibration);
        }

        // Connection to android activity stream
        void InitMainActivity()
        {
            // Get unity android stream
            unityPlayerActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

            if (unityPlayerActivity == null)
            {
                throw new System.Exception("Cannot connect to 'com.unity3d.player.UnityPlayer' ");
            }

            // Get current unity activity
            currentActivity = unityPlayerActivity.GetStatic<AndroidJavaObject>("currentActivity");

            if (currentActivity == null)
            {
                throw new System.Exception("Cannot get UnityPlayer 'currentActivity' ");
            }

            isActivityInitialized = true;
        }

        // Connection to android.os.VibrationEffect class
        void InitVibration()
        {
            if (isActivityInitialized == false)
            {
                Initialize();
                throw new System.Exception("Unity activity is not initialized");
            }

            vibrationEffect = new AndroidJavaClass("android.os.VibrationEffect");

            if (vibrationEffect == null)
            {
                throw new System.Exception("Cannot find 'android.os.VibrationEffect' class, please check your AndroidManifest for uses - permission android: name = 'android.permission.VIBRATE'");
            }

            androidVibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");

            if (androidVibrator == null)
            {
                throw new System.Exception("Cannot getSystemService vibrator");
            }

            isVibroInitialized = true;
        }

        public static int GetApiLevel()
        {
            using (var version = new AndroidJavaClass("android.os.Build$VERSION"))
            {
                return version.GetStatic<int>("SDK_INT");
            }
        }

        public bool HasAmplitudeControl()
        {
            return androidVibrator.Call<bool>("hasAmplitudeControl");
        }

        public bool HasVibrator()
        {
            return androidVibrator.Call<bool>("hasVibrator");
        }
    }
}

