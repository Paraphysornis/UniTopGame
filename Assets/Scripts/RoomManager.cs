using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    public static int doorNumber = 0;
    
    void Start()
    {
        GameObject[] enters = GameObject.FindGameObjectsWithTag("Exit");

        for (int i = 0; i < enters.Length; i++)
        {
            GameObject doorObj = enters[i];
            Exit exit = doorObj.GetComponent<Exit>();

            if (doorNumber == exit.doorNumber)
            {
                float x = doorObj.transform.position.x;
                float y = doorObj.transform.position.y;

                if (exit.direction == ExitDirection.up)
                {
                    y++;
                }
                else if (exit.direction == ExitDirection.down)
                {
                    y--;
                }
                else if (exit.direction == ExitDirection.right)
                {
                    x++;
                }
                else if (exit.direction == ExitDirection.left)
                {
                    x--;
                }

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = new Vector3(x, y);
                break;
            }
        }

        string scenename = PlayerPrefs.GetString("LastScene");

        if (scenename == "BossStage")
        {
            SoundManager.soundManager.PlayBgm(BGMType.InBoss);
        }
        else
        {
            SoundManager.soundManager.PlayBgm(BGMType.InGame);
        }
    }

    public static void ChangeScene(string scnename, int doornum)
    {
        doorNumber = doornum;
        string nowScene = PlayerPrefs.GetString("LastScene");

        if (nowScene != "")
        {
            SaveDataManager.SaveArrangeData(nowScene);
        }

        PlayerPrefs.SetString("LastScene", scnename);
        PlayerPrefs.SetInt("LastDoor", doornum);
        ItemKeeper.SaveItem();
        SceneManager.LoadScene(scnename);
    }
}
