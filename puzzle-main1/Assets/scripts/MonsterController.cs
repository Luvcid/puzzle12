using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;
    public bool isGrabbing;
    private GameObject grabbedObject;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float grabRange = 1.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        isGrabbing = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!isGrabbing)
            {
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, grabRange);
                foreach (Collider2D hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.CompareTag("Grabbable"))
                    {
                        grabbedObject = hitCollider.gameObject;
                        grabbedObject.transform.SetParent(transform);
                        isGrabbing = true;
                        break;
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            if (isGrabbing)
            {
                ReleaseObject();
            }
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void ReleaseObject()
    {
        grabbedObject.transform.SetParent(null);
        grabbedObject = null;
        isGrabbing = false;
    }
}
