
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PluginHelper : MonoBehaviour
{
    [SerializeField] private Text textResult;

    [DllImport("__Internal")]
    private static extern int _addTwoNumberInIOS(int a, int b);

    
   [DllImport("__Internal")]
   private static extern void _StartEngine();

   [DllImport("__Internal")]
   private static extern void _PlayTest();
   

    IEnumerator Start()
    {
        AddTwoNumber();
        yield return null;

        yield return new WaitForSecondsRealtime(2);
        _StartEngine();
        yield return new WaitForSecondsRealtime(1);
        _PlayTest();

    }

    public void AddTwoNumber()
    {
        int result = _addTwoNumberInIOS(10, 5);
        textResult.text = "10 + 5  is : " + result;
    }
}