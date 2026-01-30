using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class BulletController : MonoBehaviour
{
    public float deleteTime = 3f;

    void Awake()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    
    void Start()
    {
        Destroy(gameObject, deleteTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
