using UnityEngine;

public class ShootController : MonoBehaviour
{
    Vector3 halfExtents;
    Vector3 origin;
    Vector3 direction;
    private new Collider collider;
    private RaycastHit hit;
    private bool hitDetected;
    private ValuesController valuesController;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject stringEmpty;
    [SerializeField] private GameObject stringLoaded;
    [SerializeField] private float maxDistance = 300f;
    [SerializeField] private Vector3 boxSizeMultiplier = Vector3.one * 0.5f;
    [SerializeField] private AudioClip ballistaReloadSound;
    [SerializeField] private AudioClip ballistaShootSound;


    void Awake()
    {
        valuesController = playerObject.GetComponent<ValuesController>();
        collider = gameObject.GetComponent<Collider>();
    }
    
    public void Shoot ()
    {
        if (!valuesController.isBallistaLoaded) return; //No shot if ballista is not loaded
        valuesController.isBallistaLoaded = false;
        //stringEmpty.transform.position = new Vector3 (stringLoaded.transform.position.x,stringLoaded.transform.position.y,stringLoaded.transform.position.z);
        //stringLoaded.transform.position = new Vector3 (0,-100,0);
        foreach (Transform child in stringEmpty.transform)
        {
            child.gameObject.GetComponent<Renderer>().enabled = true;
        }
        foreach (Transform child in stringLoaded.transform)
        {
            child.gameObject.GetComponent<Renderer>().enabled = false;
        }
        AudioSource.PlayClipAtPoint(ballistaShootSound, transform.position, 0.3f);

        //Test to see if there is a hit using a BoxCast
        //Calculate using the center of the GameObject's Collider(could also just use the GameObject's position), half the GameObject's size, the direction, the GameObject's rotation, and the maximum distance as variables.
        //Also fetch the hit data
        halfExtents = Vector3.Scale(transform.localScale, boxSizeMultiplier);
        origin = collider.bounds.center;
        direction = transform.forward*-1;

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
            if (hit.collider.CompareTag("Enemy"))
            {
                //Destroy(hit.collider);
                hit.collider.GetComponent<SingleEnemyController>().Death();
            }
        }
    }

    public void Reload()
    {
        valuesController.isBallistaLoaded = true;
        valuesController.hasArrow = false;
        foreach (Transform child in stringEmpty.transform)
        {
            child.gameObject.GetComponent<Renderer>().enabled = false;
        }
        foreach (Transform child in stringLoaded.transform)
        {
            child.gameObject.GetComponent<Renderer>().enabled = true;
        }
        AudioSource.PlayClipAtPoint(ballistaReloadSound, transform.position, 0.3f);
        //stringEmpty.transform.position = new Vector3 (0,-100,0);
        //stringLoaded.transform.position = new Vector3 (0,0,0);
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
}