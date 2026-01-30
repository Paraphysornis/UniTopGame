using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemBox : MonoBehaviour
{
    public Sprite openImage;
    public GameObject itemPrefab;
    public bool isClosed = true;
    public int arrangeId = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isClosed && collision.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = openImage;
            isClosed = false;

            if (itemPrefab != null)
            {
                Instantiate(itemPrefab, transform.position, Quaternion.identity);
            }

            SaveDataManager.SetArrangeId(arrangeId, gameObject.tag);
        }
    }
}
