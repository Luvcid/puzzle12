using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    public string collisionTag = "Beast";
    public AudioClip destructionSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(collisionTag))
        {
            Destroy(gameObject);
            PlayDestructionSound();
        }
    }

    private void PlayDestructionSound()
    {
        if (destructionSound != null)
        {
            AudioSource.PlayClipAtPoint(destructionSound, transform.position);
        }
    }
}
