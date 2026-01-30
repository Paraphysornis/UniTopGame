using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    int hasArrows = 0;
    int hasSilverKeys = 0;
    int hasGoldKeys = 0;
    int hasLights = 0;
    int hp = 0;
    public Text arrowText, SilverKeyText, GoldKeyText, lightText;
    public Image lifeImage;
    public Sprite life0Image, life1Image, life2Image, life3Image;
    public Sprite gameOverSpr, gameClearSpr;
    public GameObject retryButton, mainImage, inputPanel;
    public string retrySceneName = "";
    
    void Start()
    {
        arrowText.color = Color.white;
        SilverKeyText.color = Color.white;
        GoldKeyText.color = Color.white;
        lightText.color = Color.white;
        UpdateItemCount();
        UpdateHP();
        Invoke("InactiveImage", 1f);
        retryButton.GetComponent<Button>().onClick.AddListener(Retry);
        retryButton.SetActive(false);
    }

    void Update()
    {
        UpdateItemCount();
        UpdateHP();
    }

    void UpdateItemCount()
    {
        if (hasArrows != ItemKeeper.hasArrows)
        {
            arrowText.text = ItemKeeper.hasArrows.ToString();
            hasArrows = ItemKeeper.hasArrows;
        }

        if (hasSilverKeys != ItemKeeper.hasSilverKeys)
        {
            SilverKeyText.text = ItemKeeper.hasSilverKeys.ToString();
            hasSilverKeys = ItemKeeper.hasSilverKeys;
        }

        if (hasGoldKeys != ItemKeeper.hasGoldKeys)
        {
            GoldKeyText.text = ItemKeeper.hasGoldKeys.ToString();
            hasGoldKeys = ItemKeeper.hasGoldKeys;
        }

        if (hasLights != ItemKeeper.hasLights)
        {
            lightText.text = ItemKeeper.hasLights.ToString();
            hasLights = ItemKeeper.hasLights;
        }
    }

    void UpdateHP()
    {
        if (PlayerController.gameState != "gameend")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                if (PlayerController.hp != hp)
                {
                    hp = PlayerController.hp;

                    if (hp <= 0)
                    {
                        lifeImage.sprite = life0Image;
                        retryButton.SetActive(true);
                        mainImage.SetActive(true);
                        mainImage.GetComponent<Image>().sprite = gameOverSpr;
                        inputPanel.SetActive(false);
                        PlayerController.gameState = "gameend";
                    }
                    else if (hp == 1)
                    {
                        lifeImage.sprite = life1Image;
                    }
                    else if (hp == 2)
                    {
                        lifeImage.sprite = life2Image;
                    }
                    else
                    {
                        lifeImage.sprite = life3Image;
                    }
                }
            }
        }
    }

    public void Retry()
    {
        PlayerPrefs.SetInt("PlayerHP", 3);
        SoundManager.playingBGM = BGMType.None;
        SceneManager.LoadScene(retrySceneName);
    }

    void InactiveImage()
    {
        mainImage.SetActive(false);
    }

    public void GameClear()
    {
        mainImage.SetActive(true);
        mainImage.GetComponent<Image>().sprite = gameClearSpr;
        inputPanel.SetActive(false);
        PlayerController.gameState = "gameclear";
        Invoke("GoToTitle", 3);
    }

    void GoToTitle()
    {
        PlayerPrefs.DeleteKey("LastScene");
        SceneManager.LoadScene("Title");
    }
}
