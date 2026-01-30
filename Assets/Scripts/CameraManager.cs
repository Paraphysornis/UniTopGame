using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject otherTarget;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            if (otherTarget != null)
            {
                Vector2 pos = Vector2.Lerp(player.transform.position, otherTarget.transform.position, 0.5f);
                transform.position = new Vector3(pos.x, pos.y, -10);
            }
            else
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            }
        }
    }
}
