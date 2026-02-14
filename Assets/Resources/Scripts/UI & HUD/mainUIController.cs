using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

public class mainUIController : MonoBehaviour
{
    private UIDocument UIDocument;
    private Button lookLeftButton;
    private Button lookRightButton;
    private Button turnSkipButton;
    private Button turnResetButton;
    private GameObject playerObject;
    TurnController turnController;

    void Awake()
    {
        UIDocument = GetComponent<UIDocument>();
        VisualElement root = UIDocument.rootVisualElement;
        playerObject = GameObject.Find("Player");
        lookLeftButton = root.Q<Button>("lookLeftButton");
        lookRightButton = root.Q<Button>("lookRightButton");
        turnSkipButton = root.Q<Button>("turnSkipButton");
        turnResetButton = root.Q<Button>("turnResetButton");
        turnController = Resources.Load<TurnController>("Scripts/Turn System/TurnController");

        turnSkipButton.clickable.clicked += turnController.TurnChange;
        turnResetButton.clickable.clicked += turnController.TurnReset;

        lookLeftButton.clickable.clicked += () => this.LookAround("left");
        lookRightButton.clickable.clicked += () => this.LookAround("right");
    }


    public void LookAround (string direction)
    {
        if (direction == "left")
        {

            lookRightButton.SetEnabled(true);
            lookLeftButton.SetEnabled(false);
            playerObject.transform.rotation *= Quaternion.Euler(0, -90, 0);
        }
        else if (direction == "right")
        {
            lookRightButton.SetEnabled(false);
            lookLeftButton.SetEnabled(true);
            playerObject.transform.rotation *= Quaternion.Euler(0, 90, 0);
        }

        if (playerObject.transform.rotation.Equals(new Quaternion(0,0,0,1)))
        {
            lookRightButton.SetEnabled(true);
            lookLeftButton.SetEnabled(true);
        }
    }
}

