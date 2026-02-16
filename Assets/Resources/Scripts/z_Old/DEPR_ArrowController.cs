

/*
public class ArrowController : MonoBehaviour {
    void Update() 
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            if (hit.transform != null) {
                Debug.Log("Hit " + hit.transform.gameObject.name);
                if (hit.transform.gameObject.name == "Arrow")
                    {
                        Destroy(hit.transform.gameObject);
                    }
            }
        }
    }
}
*/


// Attach this script to a GameObject with a Collider, then mouse over the object to see your cursor change.