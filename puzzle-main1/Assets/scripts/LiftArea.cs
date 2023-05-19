using UnityEngine;

public class LiftArea : MonoBehaviour
{
    public float liftForce;

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector2.up * liftForce);
        }
    }
}
