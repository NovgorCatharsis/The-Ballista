using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

public class mainUIController : MonoBehaviour
{
    private UIDocument UIDocument;
    private Button turnSkipButton;
    private Button turnResetButton;
    TurnController turnController;

    void Awake()
    {
        UIDocument = GetComponent<UIDocument>();
        VisualElement root = UIDocument.rootVisualElement;
        turnSkipButton = root.Q<Button>("turnSkipButton");
        turnResetButton = root.Q<Button>("turnResetButton");
        turnController = Resources.Load<TurnController>("Scripts/Turn System/TurnController");

        turnSkipButton.clickable.clicked += turnController.TurnChange;
        turnResetButton.clickable.clicked += turnController.TurnReset;
    }
}

