using UnityEngine;

public enum ItemType
{
    arrow, Goldkey, Silverkey, life, light
}

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ItemData : MonoBehaviour
{
    public int count = 1;
    public int arrangeId = 0;
    public ItemType type;
    Rigidbody2D itembody;
    CircleCollider2D collider;
    
    void Start()
    {
        itembody = GetComponent<Rigidbody2D>();
        itembody.gravityScale = 0;
        collider = GetComponent<CircleCollider2D>();
        collider.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (type == ItemType.Goldkey)
            {
                ItemKeeper.hasGoldKeys += count;
            }
            else if (type == ItemType.Silverkey)
            {
                ItemKeeper.hasSilverKeys += count;
            }
            else if (type == ItemType.arrow)
            {
                ItemKeeper.hasArrows += count;
            }
            else if (type == ItemType.light)
            {
                ItemKeeper.hasLights += count;
            }
            else if (type == ItemType.life)
            {
                if (PlayerController.hp < 3)
                {
                    PlayerController.hp++;
                    PlayerPrefs.SetInt("PlayerHP", PlayerController.hp);
                }
            }

            collider.enabled = false;
            itembody.gravityScale = 2.5f;
            itembody.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            SaveDataManager.SetArrangeId(arrangeId, gameObject.tag);
            Destroy(gameObject, 0.5f);
        }
    }
}
