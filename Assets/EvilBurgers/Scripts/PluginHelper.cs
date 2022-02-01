
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PluginHelper : MonoBehaviour
{
    [SerializeField] private Text textResult;

    

    
    [DllImport("__Internal")]
    private static extern void _StartEngine();

    [DllImport("__Internal")]
    private static extern void _PlayCustom(float intensity,float sharpness, double duration);

    [DllImport("__Internal")]
    private static extern void _PlayTest();

    public Button testVibro;

    public InputField instensityInput;
    public InputField sharpInput;
    public InputField millisecondsInput;


    IEnumerator Start()
    {
        AddTwoNumber();
        yield return null;

        yield return new WaitForSecondsRealtime(2);
       
        yield return new WaitForSecondsRealtime(1);
        //_PlayTest();

    }



    public void TestVibro()
    {
        _PlayTest();
    }

    public void Init()
    {
        _StartEngine();
    }

    public void AddTwoNumber()
    {
        //int result = _addTwoNumberInIOS(10, 5);
       // textResult.text = "10 + 5  is : " + result;
    }

    public void PlayCustom()
    {
        double customMilliseconds = 0;
        float sharp = 0;
        float intens = 0;

        double.TryParse(millisecondsInput.text, out customMilliseconds);
        float.TryParse(sharpInput.text, out sharp);
        float.TryParse(instensityInput.text,out intens);

        _PlayCustom(intens, sharp, customMilliseconds);
    }
}