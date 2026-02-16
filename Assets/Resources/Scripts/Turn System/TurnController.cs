using UnityEngine;

[CreateAssetMenu(fileName = "TurnController", menuName = "Scriptable Objects/TurnController")]
public class TurnController : ScriptableObject
{
    private GameObject moonObject;
    private GameObject canvasObject;
    private GameObject playerObject;
    private ValuesController valuesController;
    public int turnCount;
    void OnEnable()
    {
        turnCount = 0;
    }
    public void TurnChange()
    {
        playerObject = GameObject.Find("Player");
        canvasObject = GameObject.Find("Canvas");
        turnCount++;
        valuesController = playerObject.GetComponent<ValuesController>();
        valuesController.fatigueLevel += 5;
        Debug.Log ("==========TURN COUNT " + turnCount + "==========");

        canvasObject.GetComponent<BlinkingController>().Blink();
        moonObject = GameObject.Find("Moon");
        if (moonObject == null)
        {
            moonObject = GameObject.Find("BloodMoon(Clone)");
        }
        moonObject.GetComponent<MoonController>().MoonMotion();
    }

    public void TurnReset()
    {
        turnCount = 0;
        valuesController = playerObject.GetComponent<ValuesController>();
        valuesController.fatigueLevel = 0;
        valuesController.breachLevel = 0;
        Debug.Log ("==========TURN COUNT " + turnCount + "==========");
    }
}




