using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public List<GameObject> doorsToControl; // list of doors controlled by this pressure plate
    public AudioClip activateAudioClip; // audio clip to play when the plate is activated
    public AudioClip deactivateAudioClip; // audio clip to play when the plate is deactivated
    private bool isActivated; // whether the plate is currently activated
    private AudioSource audioSource; // reference to the audio source component

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            ActivatePlate();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            DeactivatePlate();
        }
    }

    private void ActivatePlate()
    {
        if (!isActivated)
        {
            isActivated = true;
            foreach (GameObject door in doorsToControl)
            {
                door.SetActive(false); // open the door
            }
            if (activateAudioClip != null)
            {
                audioSource.clip = activateAudioClip;
                audioSource.Play();
            }
        }
    }

    private void DeactivatePlate()
    {
        if (isActivated)
        {
            isActivated = false;
            foreach (GameObject door in doorsToControl)
            {
                door.SetActive(true); // close the door
            }
            if (deactivateAudioClip != null)
            {
                audioSource.clip = deactivateAudioClip;
                audioSource.Play();
            }
        }
    }
}


/*
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public List<GameObject> doorsToControl; // list of doors controlled by this pressure plate
    private bool isActivated; // whether the plate is currently activated

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            ActivatePlate();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            DeactivatePlate();
        }
    }

    private void ActivatePlate()
    {
        if (!isActivated)
        {
            isActivated = true;
            foreach (GameObject door in doorsToControl)
            {
                door.SetActive(false); // open the door
            }
        }
    }

    private void DeactivatePlate()
    {
        if (isActivated)
        {
            isActivated = false;
            foreach (GameObject door in doorsToControl)
            {
                door.SetActive(true); // close the door
            }
        }
    }
}
*/