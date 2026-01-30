using UnityEngine;

public enum ExitDirection
{
    right, left, down, up
}

[RequireComponent(typeof(CircleCollider2D))]
public class Exit : MonoBehaviour
{
    public string sceneName = "";
    public int doorNumber = 0;
    public ExitDirection direction = ExitDirection.down;

    void Start()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (doorNumber == 100)
            {
                SoundManager.soundManager.StopBgm();
                SoundManager.soundManager.SEPlay(SEType.GameClear);
                GameObject.FindObjectOfType<UIManager>().GameClear();
            }
            else
            {
                string nowScene = PlayerPrefs.GetString("LastScene");
                SaveDataManager.SaveArrangeData(nowScene);
                RoomManager.ChangeScene(sceneName, doorNumber);
            }
        }
    }
}
