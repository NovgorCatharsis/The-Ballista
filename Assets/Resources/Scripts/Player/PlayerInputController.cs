using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private GameObject ballistaObject;
    [SerializeField] private AudioClip waterSplashSound;
    [SerializeField] private AudioClip clickSound;
    private TurnController turnController;
    private TiltController tiltController;
    private ShootController shootController;
    private ValuesController valuesController;
    private PlayerInput playerInput;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private bool isCursorOnArrow = false;
    private bool isCursorOnBallista = false;
    private bool isCursorOnWater = false;
    private GameObject objectBeingLookedAt;


    void Awake ()
    {
        tiltController = ballistaObject.GetComponent<TiltController>();
        shootController = ballistaObject.GetComponent<ShootController>();
        valuesController = gameObject.GetComponent<ValuesController>();
        playerInput = gameObject.GetComponent<PlayerInput>();

        turnController = Resources.Load<TurnController>("Scripts/Turn System/TurnController");
    }

    private void OnTiltLeft(InputValue inputValue)
    {
        tiltController.Tilt(-5,0);
    }
    private void OnTiltRight(InputValue inputValue)
    {
        tiltController.Tilt(5,0);
    }
    private void OnTiltUp(InputValue inputValue)
    {
        tiltController.Tilt(0,2.5f);
    }
    private void OnTiltDown(InputValue inputValue)
    {
        tiltController.Tilt(0,-2.5f);
    }

    private void OnShoot(InputValue inputValue)
    {
        if (valuesController.isBallistaLoaded)
        {
            shootController.Shoot();
            turnController.TurnChange();
        }
    }

    private void OnInteract(InputValue inputValue)
    {
        if (isCursorOnArrow)
        {
            AudioSource.PlayClipAtPoint(clickSound, transform.position, 0.25f);
            valuesController.hasArrow = true;
            Destroy(objectBeingLookedAt);
            turnController.TurnChange();
        }
        else if (isCursorOnBallista)
        {
            AudioSource.PlayClipAtPoint(clickSound, transform.position, 0.25f);
            shootController.Reload();
            turnController.TurnChange();
        }
        else if (isCursorOnWater)
        {
            AudioSource.PlayClipAtPoint(waterSplashSound, transform.position, 0.15f);
            turnController.TurnChange();
            valuesController.fatigueLevel = 0;
        }
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(playerInput.actions.FindAction("MousePosition").ReadValue<Vector2>());
        if (Physics.Raycast(ray, out hit))
        if (hit.transform)
        {
            objectBeingLookedAt = hit.transform.gameObject;
            if (objectBeingLookedAt.name == "Arrow" && !valuesController.hasArrow)
            {
                Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
                isCursorOnArrow = true;
                return;
            }
            else if (objectBeingLookedAt.name == "Crossbow" && valuesController.hasArrow && !valuesController.isBallistaLoaded)
            {
                Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
                isCursorOnBallista = true;
                return;
            }
            else if (objectBeingLookedAt.name == "Water")
            {
                Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
                isCursorOnWater = true;
                return;
            }
            Cursor.SetCursor(null, Vector2.zero, cursorMode); //Returning cursor to default value in case we're not looking at anything of interest
            objectBeingLookedAt = null;
            isCursorOnArrow = false;
            isCursorOnBallista = false;
            isCursorOnWater = false;
        } 
    }
}