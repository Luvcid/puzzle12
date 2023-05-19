using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController1 : MonoBehaviour
{
    public GameObject[] platforms;
    public PlayerScript playerScript;
    public float activationDistance;

    //public Transform cameraPositionWhenControllingPlatforms;

    private GameObject player;
    //private Camera mainCamera;
    //private Transform originalCameraTransform;

    private int currentPlatformIndex = 0;
    private bool isControllingPlatforms = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //mainCamera = Camera.main;
        //originalCameraTransform = mainCamera.transform;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= activationDistance)
        {
            ActivateUpdateFunction();
        }
    }
    
    void ActivateUpdateFunction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isControllingPlatforms)
            {
                DisableScript();
                isControllingPlatforms = true;
                platforms[currentPlatformIndex].GetComponent<PlatformMovement>().StartControlling();
                //mainCamera.transform.position = cameraPositionWhenControllingPlatforms.position;
                //mainCamera.transform.rotation = cameraPositionWhenControllingPlatforms.rotation;
            }
            /*else
            {
                EnableScript();
                isControllingPlatforms = false;
                platforms[currentPlatformIndex].GetComponent<PlatformMovement>().StopControlling();
            }*/
        }

        if (isControllingPlatforms && Input.GetKeyDown(KeyCode.R))
        {
            platforms[currentPlatformIndex].GetComponent<PlatformMovement>().StopControlling();
            currentPlatformIndex = (currentPlatformIndex + 1) % platforms.Length;
            platforms[currentPlatformIndex].GetComponent<PlatformMovement>().StartControlling();
        }

        if (isControllingPlatforms && Input.GetKeyDown(KeyCode.Q))
        {
            EnableScript();
            isControllingPlatforms = false;
            platforms[currentPlatformIndex].GetComponent<PlatformMovement>().StopControlling();
            //mainCamera.transform.position = originalCameraTransform.position;
            //mainCamera.transform.rotation = originalCameraTransform.rotation;
        }
    }

    public void EnableScript()
    {
        playerScript.enabled = true;
    }

    public void DisableScript()
    {
        playerScript.enabled = false;
    }
}
