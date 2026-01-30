using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class BossController : MonoBehaviour
{
    public int hp = 10;
    public float reactionDistance = 7f;
    public float shootSpeed = 5f;
    public GameObject bulletPrefab;
    bool inAttack = false;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (hp > 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                Vector3 plpos = player.transform.position;
                float dist = Vector2.Distance(transform.position, plpos);

                if (dist <= reactionDistance && !inAttack)
                {
                    inAttack = true;
                    animator.Play("BossAttack");
                    Invoke("Attack", 1);
                }
                else if (dist > reactionDistance && inAttack)
                {
                    inAttack = false;
                    animator.Play("BossIdle");
                }
            }
            else
            {
                inAttack = false;
                animator.Play("BossIdle");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            hp--;

            if (hp <= 0)
            {
                GetComponent<CircleCollider2D>().enabled = false;
                animator.Play("BossDead");
                Destroy(gameObject, 1);
            }
        }
    }

    void Attack()
    {
        Transform tr = transform.Find("gate");
        GameObject gate = tr.gameObject;
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float dx = player.transform.position.x - gate.transform.position.x;
            float dy = player.transform.position.y - gate.transform.position.y;
            float rad = Mathf.Atan2(dy, dx);
            float angle = rad * Mathf.Rad2Deg;
            Quaternion r = Quaternion.Euler(0, 0, angle);
            GameObject bullet = Instantiate(bulletPrefab, gate.transform.position, r);
            float x = Mathf.Cos(rad);
            float y = Mathf.Sin(rad);
            Vector3 v = new Vector3(x, y) * shootSpeed;
            Rigidbody2D rbody = bullet.GetComponent<Rigidbody2D>();
            rbody.AddForce(v, ForceMode2D.Impulse);
            inAttack = false;
        }
    }
}
