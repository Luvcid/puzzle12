using UnityEngine;

public class RaycastController : MonoBehaviour
{
    // These variables are public so they can be set in the Inspector
    public GameObject[] LineOfSight;
    public float activationDistance;

    // These variables are private and are set in code
    private GameObject player;
    private PlayerScript playerScript;
    private bool isRotatingRaycast = false;
    private int currentLineOfSight = 0;
    private RotatingRaycast rotatingRaycast;
    private LineRenderer mirrorLineRenderer;
    private Vector3 mirrorLineStartPos;
    public float mirrorLineDistance = 2f;

    void Start()
    {
        // Set player and playerScript variables
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();

        // Set rotatingRaycast variable and check that it's not null
        rotatingRaycast = LineOfSight[currentLineOfSight].GetComponent<RotatingRaycast>();

        // Get the mirror object from the rotatingRaycast
        GameObject Mirror = rotatingRaycast.Mirror;

        // Check that the mirror object is not null before calculating the distance to the player
        {
            // Calculate the distance to the player
            float distance = Vector2.Distance(transform.position, player.transform.position);
            // ...
        }

        if (rotatingRaycast != null)
        {
            if (Mirror != null)
            {
                float distance = Vector2.Distance(transform.position, player.transform.position);
                // ...
            }
            else
            {
                Debug.LogError("The mirror object is null");
            }
        }
        else
        {
            Debug.LogError("The rotatingRaycast object is null");
        }
        LineOfSight = new GameObject[] { Mirror };
        if (currentLineOfSight < 0 || currentLineOfSight >= LineOfSight.Length)
        {
            currentLineOfSight = 0;
        }

        // Set mirrorLineRenderer variable
        mirrorLineRenderer = GetComponent<LineRenderer>();

    }
    void Update()
    {
        // Check if the player is close enough to activate the RaycastController
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= activationDistance)
        {
            ActivateUpdateFunction();
        }
    }

    private void ActivateUpdateFunction()
    {
        // If the player presses 'E', activate the rotatingRaycast
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isRotatingRaycast && LineOfSight[currentLineOfSight] != null)
            {
                DisablePlayerMovement();
                isRotatingRaycast = true;

                // Check if LineOfSight[currentLineOfSight] has the RotatingRaycast component
                rotatingRaycast = LineOfSight[currentLineOfSight].GetComponent<RotatingRaycast>();
                if (rotatingRaycast != null)
                {
                    rotatingRaycast.StartControlling();
                }
            }
        }
        // If the player presses 'Q', stop the rotatingRaycast
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            EnablePlayerMovement();
            isRotatingRaycast = false;

            // Check if LineOfSight[currentLineOfSight] has the RotatingRaycast component
            rotatingRaycast = LineOfSight[currentLineOfSight].GetComponent<RotatingRaycast>();
                        if (rotatingRaycast != null)
            {
                rotatingRaycast.StopControlling();
            }
        }

        // If the player presses 'Tab', cycle through LineOfSight array
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentLineOfSight++;
            if (currentLineOfSight >= LineOfSight.Length)
            {
                currentLineOfSight = 0;
            }

            // Check if LineOfSight[currentLineOfSight] has the RotatingRaycast component
            rotatingRaycast = LineOfSight[currentLineOfSight].GetComponent<RotatingRaycast>();
            if (rotatingRaycast == null)
            {
                Debug.LogError("The rotatingRaycast object is null");
                return;
            }

            // Get the mirror object from the rotatingRaycast and check that it's not null
            GameObject Mirror = rotatingRaycast.Mirror;
            if (Mirror == null)
            {
                Debug.LogError("The mirror object is null");
                return;
            }

            // Update mirrorLineRenderer variables
            mirrorLineRenderer.startWidth = rotatingRaycast.LineOfSight.startWidth;
            mirrorLineRenderer.endWidth = rotatingRaycast.LineOfSight.endWidth;
            mirrorLineStartPos = Mirror.transform.position + Mirror.transform.right * mirrorLineDistance;
            mirrorLineRenderer.SetPosition(0, mirrorLineStartPos);
            mirrorLineRenderer.SetPosition(1, mirrorLineStartPos + Mirror.transform.right * -mirrorLineDistance * 2);
        }
    }

    private void DisablePlayerMovement()
    {
        playerScript.enabled = false;
    }

    private void EnablePlayerMovement()
    {
        playerScript.enabled = true;
    }
}

    