using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public sealed class IosVibrationWrapper 
{

#if UNITY_IOS
    /*
    [DllImport("__Internal")]
    private static extern void _Initialize();

    [DllImport("__Internal")]
    private static extern void _PlayTest();
    */
    
#endif

    public void Initialize()
    {
       // _Initialize();
       // _PlayTest();
    }
}
