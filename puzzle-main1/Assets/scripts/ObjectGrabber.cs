using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    public KeyCode grabKey = KeyCode.X;
    public KeyCode releaseKey = KeyCode.Z;
    public float grabRadius = 0.5f;
    public string grabbableTag = "Ball";
    private GameObject grabbedObject;
    private Vector2 originalObjectPosition;

    private void Update()
    {
        if (Input.GetKeyDown(grabKey))
        {
            if (grabbedObject == null)
            {
                // Check if there is a grabbable object nearby
                Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(transform.position, grabRadius);
                foreach (Collider2D collider in nearbyObjects)
                {
                    if (collider.CompareTag(grabbableTag))
                    {
                        // Grab the first object found with the specified tag
                        grabbedObject = collider.gameObject;
                        originalObjectPosition = grabbedObject.transform.position;
                        grabbedObject.transform.parent = transform;
                        break;
                    }
                }
            }
        }

        if (Input.GetKeyDown(releaseKey))
        {
            if (grabbedObject != null)
            {
                // Release the grabbed object
                grabbedObject.transform.parent = null;
                //grabbedObject.transform.position = originalObjectPosition;
                grabbedObject = null;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, grabRadius);
    }
}
