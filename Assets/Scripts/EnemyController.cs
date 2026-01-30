using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public int arrangeId = 0;
    public int hp = 3;
    public float speed = 0.5f;
    public float reactionDistance = 4f;
    bool isActive = false;
    float axisH, axisV;
    Animator animator;
    Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        axisH = 0;
        axisV = 0;
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float dist = Vector2.Distance(transform.position, player.transform.position);

            if (dist < reactionDistance)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }

            animator.SetBool("IsActive", isActive);

            if (isActive)
            {
                animator.SetBool("IsActive", isActive);
                float dx = player.transform.position.x - transform.position.x;
                float dy = player.transform.position.y - transform.position.y;
                float rad = Mathf.Atan2(dy, dx);
                float angle = rad * Mathf.Rad2Deg;
                int direction;

                if (angle > -45f && angle <= 45f)
                {
                    direction = 3;
                }
                else if (angle > 45f && angle <= 135f)
                {
                    direction = 2;
                }
                else if (angle >= -135f && angle <= -45f)
                {
                    direction = 0;
                }
                else
                {
                    direction = 1;
                }

                animator.SetInteger("Direction", direction);
                axisH = Mathf.Cos(rad) * speed;
                axisV = Mathf.Sin(rad) * speed;
            }
        }
        else
        {
            isActive = false;
        }
    }

    void FixedUpdate()
    {
        if (isActive && hp > 0)
        {
            rbody.velocity = new Vector2(axisH, axisV).normalized;
        }
        else
        {
            rbody.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            hp--;

            if (hp <= 0)
            {
                GetComponent<CircleCollider2D>().enabled = false;
                rbody.velocity = Vector2.zero;
                animator.SetBool("IsDead", true);
                SaveDataManager.SetArrangeId(arrangeId, gameObject.tag);
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
