using UnityEngine;

public class ItemKeeper : MonoBehaviour
{
    public static int hasGoldKeys = 0;
    public static int hasSilverKeys = 0;
    public static int hasArrows = 0;
    public static int hasLights = 10;

    void Start()
    {
        hasGoldKeys = PlayerPrefs.GetInt("GoldKeys");
        hasSilverKeys = PlayerPrefs.GetInt("SilverKeys");
        hasArrows = PlayerPrefs.GetInt("Arrows");
    }

    public static void SaveItem()
    {
        PlayerPrefs.SetInt("GoldKeys", hasGoldKeys);
        PlayerPrefs.SetInt("Arrows", hasArrows);
        PlayerPrefs.SetInt("Arrows", hasArrows);
    }
}
