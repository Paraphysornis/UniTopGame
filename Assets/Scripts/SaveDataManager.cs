using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataList arrangeDataList;
    
    void Start()
    {
        arrangeDataList = new SaveDataList();
        arrangeDataList.saveDatas = new SaveData[] { };
        string stageName = PlayerPrefs.GetString("LastScene");
        string data = PlayerPrefs.GetString(stageName);

        if (data != "")
        {
            arrangeDataList = JsonUtility.FromJson<SaveDataList>(data);

            for (int i = 0; i < arrangeDataList.saveDatas.Length; i++)
            {
                SaveData savedata = arrangeDataList.saveDatas[i];
                string objTag = savedata.objTag;
                GameObject[] objects = GameObject.FindGameObjectsWithTag(objTag);

                for (int ii = 0; ii < objects.Length; ii++)
                {
                    GameObject obj = objects[ii];

                    if (objTag == "Door")
                    {
                        Door door = obj.GetComponent<Door>();

                        if (door.arrangeId == savedata.arrangedId)
                        {
                            Destroy(obj);
                        }
                    }
                    else if (objTag == "ItemBox")
                    {
                        ItemBox box = obj.GetComponent<ItemBox>();

                        if (box.arrangeId == savedata.arrangedId)
                        {
                            box.isClosed = false;
                            box.GetComponent<SpriteRenderer>().sprite = box.openImage;
                        }
                    }
                    else if (objTag == "Item")
                    {
                        ItemData item = obj.GetComponent<ItemData>();

                        if (item.arrangeId == savedata.arrangedId)
                        {
                            Destroy(obj);
                        }
                    }
                    else if (objTag == "Enemy")
                    {
                        EnemyController enemy = obj.GetComponent<EnemyController>();

                        if (enemy.arrangeId == savedata.arrangedId)
                        {
                            Destroy(obj);
                        }
                    }
                }
            }
        }
    }

    public static void SetArrangeId(int arrangeId, string objTag)
    {
        if (arrangeId == 0 || objTag == "")
        {
            return;
        }

        SaveData[] newSavedatas = new SaveData[arrangeDataList.saveDatas.Length + 1];

        for (int i = 0; i < arrangeDataList.saveDatas.Length; i++)
        {
            newSavedatas[i] = arrangeDataList.saveDatas[i];
        }

        SaveData savedata = new SaveData();
        savedata.arrangedId = arrangeId;
        savedata.objTag = objTag;
        newSavedatas[arrangeDataList.saveDatas.Length] = savedata;
        arrangeDataList.saveDatas = newSavedatas;
    }

    public static void SaveArrangeData(string stageName)
    {
        if (arrangeDataList.saveDatas != null && stageName != "")
        {
            string saveJson = JsonUtility.ToJson(arrangeDataList);
            PlayerPrefs.SetString(stageName, saveJson);
        }
    }
}
