using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public KeyCode summonKey = KeyCode.E;
    public KeyCode teleportKey = KeyCode.R;
    public KeyCode removeKey = KeyCode.Q;
    public GameObject portalPrefab;
    public int maxPortals = 2;
    public float summonDistance = 1f;
    private List<GameObject> portals = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(summonKey))
        {
            if (portals.Count < maxPortals)
            {
                Vector2 summonPosition = transform.position + transform.right * summonDistance;
                GameObject newPortal = Instantiate(portalPrefab, summonPosition, Quaternion.identity);
                portals.Add(newPortal);
            }
        }

        if (Input.GetKeyDown(teleportKey))
        {
            if (portals.Count == maxPortals)
            {
                GameObject currentPortal = GetPortalUnderPlayer();
                if (currentPortal != null)
                {
                    GameObject otherPortal = portals.Find(p => p != currentPortal);
                    if (otherPortal != null)
                    {
                        Teleport(transform, otherPortal.transform.position);
                    }
                }
            }
        }

        if (Input.GetKeyDown(removeKey))
        {
            GameObject portalToRemove = GetPortalUnderPlayer();
            if (portalToRemove != null)
            {
                RemovePortal(portalToRemove);
            }
        }
    }

    private GameObject GetPortalUnderPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
        foreach (Collider2D collider in colliders)
        {
            if (portals.Contains(collider.gameObject))
            {
                return collider.gameObject;
            }
        }
        return null;
    }

    private void Teleport(Transform target, Vector2 destination)
    {
        target.position = destination;
    }

    private void RemovePortal(GameObject portal)
    {
        portals.Remove(portal);
        Destroy(portal);
    }
}
