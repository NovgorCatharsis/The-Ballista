using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "TurnController", menuName = "Scriptable Objects/TurnController")]
public class TurnController : ScriptableObject
{
    private GameObject moonObject;
    private GameObject canvasObject;
    public int turnCount;
    void OnEnable()
    {
        //blinkingController = Resources.Load<BlinkingController>("Scripts/UI/BlinkingController");
        canvasObject = GameObject.Find("Canvas");
        moonObject = GameObject.Find("Moon");
        turnCount = 0;
    }
    public void TurnChange()
    {
        turnCount++;
        Debug.Log ("==========TURN COUNT " + turnCount + "==========");

        //blinkingController.Blink();
        Debug.Log (canvasObject == null);
        canvasObject.GetComponent<BlinkingController>().Blink();
        moonObject.GetComponent<MoonController>().MoonMotion();
    }

    public void TurnReset()
    {
        turnCount = 0;
        Debug.Log ("==========TURN COUNT " + turnCount + "==========");
    }
}




