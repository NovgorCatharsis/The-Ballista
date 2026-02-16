using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

public class mainUIController : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    private UIDocument UIDocument;
    private Button lookLeftButton;
    private Button lookRightButton;
    private Button turnSkipButton;
    private Button turnResetButton;
    private GameObject playerObject;
    private GameObject ballistaObject;
    TurnController turnController;

    void Awake()
    {
        UIDocument = GetComponent<UIDocument>();
        VisualElement root = UIDocument.rootVisualElement;
        playerObject = GameObject.Find("Player");
        ballistaObject = GameObject.Find("Ballista");
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
        /*float x = ballistaObject.transform.localEulerAngles.x;
        float y = ballistaObject.transform.localEulerAngles.y;
        if (y%90 != 0)
        {
            y = y - (y%90);
        }*/
        AudioSource.PlayClipAtPoint(clickSound, transform.position, 0.25f);

        ballistaObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        ballistaObject.GetComponent<TiltController>().ballistaYaw = 0;
        ballistaObject.GetComponent<TiltController>().ballistaPitch = 0;

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
        //if (y == 180)
        {
            lookRightButton.SetEnabled(true);
            lookLeftButton.SetEnabled(true);
        }
    }
}

