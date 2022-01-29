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


        internal bool isActivityInitialized;
        internal bool isVibroInitialized;
#endif

        public void Initialize()
        {
#if UNITY_ANDROID
            InitMainActivity();
            InitVibration();

#endif

        }

        // Play one shot vibration 
        public void AndroidOneShotVibration(long milliseconds, int amplitude)
        {
#if UNITY_ANDROID

            Initialize();

            if(GetApiLevel() > 26)
            {
                AndroidJavaObject vibration = vibrationEffect.CallStatic<AndroidJavaObject>("createOneShot", new object[] { milliseconds, amplitude });
                androidVibrator.Call("vibrate", vibration);
            }
            else
            {
                androidVibrator.Call("vibrate", milliseconds);
            }
#endif

        }

        // Play waveform vibration
        public void AndroidWaveformVibration(long[] millisecondsPattern, int[] amplitudesPattern, int repeat = -1)
        {
            #if UNITY_ANDROID
            Initialize();

            if (GetApiLevel() > 26)
            {
                AndroidJavaObject vibration = vibrationEffect.CallStatic<AndroidJavaObject>("createWaveform", new object[] { millisecondsPattern, /*amplitudesPattern,*/ repeat });
                androidVibrator.Call("vibrate", vibration);
            }
            else
            {
                androidVibrator.Call("vibrate", millisecondsPattern, repeat);
            }
#endif
        }

        // Connection to android activity stream
        void InitMainActivity()
        {
            #if UNITY_ANDROID
            if(unityPlayerActivity != null && currentActivity != null) return;

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
#endif
        }

        // Connection to android.os.VibrationEffect class
        void InitVibration()
        {
            #if UNITY_ANDROID
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
#endif
        }

        public static int GetApiLevel()
        {
#if UNITY_ANDROID
            using (var version = new AndroidJavaClass("android.os.Build$VERSION"))
            {
                return version.GetStatic<int>("SDK_INT");
            }
#endif
            return -1;
        }

        public void StopVibration()
        {
#if UNITY_ANDROID
            if(isVibroInitialized)
                androidVibrator.Call("cancel");
            else
                Initialize();
#endif
        }

        public bool HasAmplitudeControl()
        {
#if UNITY_ANDROID
            return androidVibrator.Call<bool>("hasAmplitudeControl");
#endif
            return false;
        }

        public bool HasVibrator()
        {
#if UNITY_ANDROID
            return androidVibrator.Call<bool>("hasVibrator");
#endif
            return false;
        }
    }
}

