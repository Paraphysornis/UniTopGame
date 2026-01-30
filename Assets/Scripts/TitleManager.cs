using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public Button startButton, continueButton;
    public string firstSceneName;

    void Start()
    {
        startButton.onClick.AddListener(StartButtonClicked);
        continueButton.onClick.AddListener(ContinueButtonClicked);
        string sceneName = PlayerPrefs.GetString("LastScene");

        if (sceneName == "")
        {
            continueButton.interactable = false;
        }
        else
        {
            continueButton.interactable = true;
        }

        SoundManager.soundManager.PlayBgm(BGMType.Title);
    }

    public void StartButtonClicked()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("PlayerHP", 3);
        PlayerPrefs.SetString("LastScene", firstSceneName);
        RoomManager.doorNumber = 0;
        SceneManager.LoadScene(firstSceneName);
    }

    public void ContinueButtonClicked()
    {
        string sceneName = PlayerPrefs.GetString("LastScene");
        RoomManager.doorNumber = PlayerPrefs.GetInt("LastDoor");
        SceneManager.LoadScene(sceneName);
    }
}
