using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour
{
    public int arrangeId = 0;
    public bool IsGoldDoor = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (IsGoldDoor)
            {
                if (ItemKeeper.hasGoldKeys > 0)
                {
                    ItemKeeper.hasGoldKeys--;
                    SaveDataManager.SetArrangeId(arrangeId, gameObject.tag);
                    Destroy(this.gameObject);
                }
            }
            else
            {
                if (ItemKeeper.hasSilverKeys > 0)
                {
                    ItemKeeper.hasSilverKeys--;
                    SaveDataManager.SetArrangeId(arrangeId, gameObject.tag);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
