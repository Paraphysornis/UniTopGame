using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class ArrowController : MonoBehaviour
{
    public float deleteTime = 2;
    Rigidbody2D rbody;

    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
    }
    
    void Start()
    {
        Destroy(gameObject, deleteTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        transform.SetParent(collision.transform);
        GetComponent<CircleCollider2D>().enabled = false;
        rbody.simulated = false;
    }
}
