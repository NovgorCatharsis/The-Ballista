using UnityEngine;


public class ValuesController : MonoBehaviour
{
    public int fatigueLevel;
    public bool hasArrow;
    public bool isBallistaLoaded;
    public int breachLevel;

    void Awake()
    {
        fatigueLevel = 0;
        breachLevel = 0;
        hasArrow = false;
        isBallistaLoaded = true;
    }
}