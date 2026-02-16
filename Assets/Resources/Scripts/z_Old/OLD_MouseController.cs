

/*
public class MouseController : MonoBehaviour
{
    //public float rotationSpeed;
    private float ballistaYaw;
    private float ballistaPitch;
    private GameObject ballistaObject;


    private new Collider collider;
    private RaycastHit hit;
    private bool hitDetected;
    [SerializeField] private float maxDistance = 300f;
    [SerializeField] private Vector3 boxSizeMultiplier = Vector3.one * 0.5f;


    void Awake()
    {
        ballistaObject = GameObject.Find("BallistaMain");
        collider = ballistaObject.GetComponent<Collider>();

        ballistaYaw = ballistaObject.transform.localEulerAngles.y;
        ballistaPitch = ballistaObject.transform.localEulerAngles.x;
    }
    

    private void OnTiltLeft(InputValue inputValue)
    {
        if (ballistaYaw > -20)
        {
            ballistaYaw -= 10;
            this.Tilt(ballistaPitch,ballistaYaw);
        }
    }
    private void OnTiltRight(InputValue inputValue)
    {
        if (ballistaYaw < 20)
        {
            ballistaYaw += 10;
            this.Tilt(ballistaPitch,ballistaYaw);
        }
    }
    private void OnTiltUp(InputValue inputValue)
    {
        if (ballistaPitch < 15)
        {
            ballistaPitch += 5;
            this.Tilt(ballistaPitch,ballistaYaw);
        }
    }
    private void OnTiltDown(InputValue inputValue)
    {
        if (ballistaPitch > -15)
        {
            ballistaPitch -= 5;
            this.Tilt(ballistaPitch,ballistaYaw);
        } 
    }

    void Tilt (float yaw, float pitch)
    {
        ballistaObject.transform.localRotation = Quaternion.Euler(yaw, pitch, 0f);
    }

    
    void FixedUpdate()
    {
        Vector3 halfExtents = Vector3.Scale(transform.localScale, boxSizeMultiplier);
        Vector3 origin = collider.bounds.center;
        Vector3 direction = transform.forward*-1;
        
        //Test to see if there is a hit using a BoxCast
        //Calculate using the center of the GameObject's Collider(could also just use the GameObject's position), half the GameObject's size, the direction, the GameObject's rotation, and the maximum distance as variables.
        //Also fetch the hit data
        hitDetected = Physics.BoxCast(
            origin, 
            halfExtents, 
            direction,
            out hit, 
            transform.rotation,
            maxDistance);
        
        if (hitDetected)
        {
            //Output the name of the Collider your Box hit
            Debug.Log("Hit : " + hit.collider.name);
        }
    }

    //Draw the BoxCast as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        if (hitDetected)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance * -1);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance * -1, transform.localScale);
        }
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.forward * maxDistance * -1);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + transform.forward * maxDistance * -1, transform.localScale);
        }
    }


/*
    void FixedUpdate()
    {


        /*
        Rigidbody ballistaRigidbody = ballistaObject.GetComponent<Rigidbody>();
        Quaternion ballistaRotation = Quaternion.Euler(
            movementInput.y * rotationSpeed,
            movementInput.x * rotationSpeed,
            0);
        //Debug.Log("MOVEMENT INPUT: " + movementInput);
        //Debug.Log("EULER ROTATION: " + ballistaRotation);
        Quaternion endRotation = ballistaRigidbody.rotation * ballistaRotation;
        Debug.Log(ballistaObject.transform.eulerAngles.x);
        if (Math.Abs(ballistaObject.transform.eulerAngles.x) >= 12)
        {
            //ballistaObject.transform.rotation.Set(0,ballistaObject.transform.rotation.y,ballistaObject.transform.rotation.z,0);
            endRotation = new Quaternion (0,endRotation.y,0,0);
        }
        
        ballistaRigidbody.MoveRotation(endRotation);
        */




        /*
        Vector3 mousePosition = playerInput.actions.FindAction("MousePosition").ReadValue<Vector2>();
        Vector2 mousePositionNormalized = new Vector2(
            (float)((mousePosition.x / Screen.width)-0.5),
            (float)((mousePosition.y / Screen.height)-0.5)
        );
        //Vector3 test = camera.ScreenToWorldPoint(mousePosition);
        Debug.Log(mousePositionNormalized);
        Rigidbody ballistaRigidbody = ballistaObject.GetComponent<Rigidbody>();

        float ballistaVerticalRotation = mousePositionNormalized.y;
        float ballistaHorizontalRotation = mousePositionNormalized.x;
        
        if (Math.Abs(ballistaRigidbody.rotation.x) >= 12)
        {
            ballistaVerticalRotation = 0;
        }
        if (Math.Abs(ballistaRigidbody.rotation.y) >= 20)
        {
            ballistaHorizontalRotation = 0;
        }
        Quaternion ballistaRotation = Quaternion.Euler(ballistaVerticalRotation,ballistaHorizontalRotation,0);
        ballistaRigidbody.MoveRotation(ballistaRigidbody.rotation * ballistaRotation);
        //Quaternion ballistaRotation = new Quaternion ((mousePosition.y/100).normalized,mousePosition.x/100,0,0);
        //ballistaRigidbody.rotation = ballistaRotation;
        */



        /*
        Vector2 movementInput = playerInput.actions.FindAction("MouseDelta").ReadValue<Vector2>() * Time.deltaTime;
        Rigidbody ballistaRigidbody = ballistaObject.GetComponent<Rigidbody>();
        Quaternion ballistaRotation = Quaternion.Euler(
            movementInput.y * rotationSpeed,
            movementInput.x * rotationSpeed,
            0);
        Debug.Log("MOVEMENT INPUT: " + movementInput);
        Debug.Log("EULER ROTATION: " + ballistaRotation);
        ballistaRigidbody.MoveRotation(ballistaRigidbody.rotation * ballistaRotation);
        if (ballistaRigidbody.rotation.x >= 12)
        {
            ballistaRigidbody.rotation.Set(12,ballistaRigidbody.rotation.y,ballistaRigidbody.rotation.z,0);
        }
        else if (ballistaRigidbody.rotation.x <= -12)
        {
            ballistaRigidbody.rotation.Set(-12,ballistaRigidbody.rotation.y,ballistaRigidbody.rotation.z,0);
        }
        if (ballistaRigidbody.rotation.y >= 20)
        {
            ballistaRigidbody.rotation.Set(ballistaRigidbody.rotation.x,20,ballistaRigidbody.rotation.z,0);
        }
        else if (ballistaRigidbody.rotation.y <= -20)
        {
            ballistaRigidbody.rotation.Set(ballistaRigidbody.rotation.x,-20,ballistaRigidbody.rotation.z,0);
        }
        */
