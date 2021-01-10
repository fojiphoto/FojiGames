using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuZombie : MonoBehaviour {
    public Image sound;
    public GameObject sounds;
    public Sprite soundOn, soundOff;
    public Text CashText;
    public string MoreGames;
    bool exit;
    public GameObject ExiDG;
    //public AdCalls ads;
	// Use this for initialization

	void Start () {
        if (GameObject.FindGameObjectWithTag("sound") == null)
        {
            GameObject Sound = Instantiate(sounds) as GameObject;
        }
        Time.timeScale = 1;
    }
    private void Update()
    {
        CashText.text = "" + PlayerPrefs.GetInt("Cash");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (exit)
            {
                exit = false;
                ExiDG.SetActive(false);
            }
            else
            {
                exit = true;
                //ads.UnityInterstitial();
                ExiDG.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
                PlayerPrefs.SetInt("LevelNoSnow", 9);
                PlayerPrefs.SetInt("LevelNoForest", 9);
                PlayerPrefs.SetInt("LevelNoDesert", 9);
                PlayerPrefs.SetInt("LevelNoCity", 9);
        }
    }

    public void ShowRewardedVideo()
    {
        AdsManager.instance.ShowRewarded(this.RewardCoins);
        CashText.text = PlayerPrefs.GetInt("Cash").ToString();
    }

    public void RewardCoins()
    {

        PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 50);
        CashText.text = PlayerPrefs.GetInt("Cash").ToString();
    }

    public void ExitYes()
    {
        Application.Quit();
    }
    public void No()
    {
        exit = false;
        ExiDG.SetActive(false);
    }
    public void MoreGame()
    {
        Application.OpenURL(MoreGames);
    }
    public void Rate_Us()
    {
        Application.OpenURL("http://apps.samsung.com/appquery/appDetail.as?appId=" + Application.identifier);
    }
    public void Play()
    {
        SoundManager.Instant.ButtonClicked();
        Application.LoadLevel("Inventory");
    }
    public void Sound()
    {
        if (GameManager.soundChk)
        {
            AudioListener.pause = true;
            GameManager.soundChk = false;
            sound.overrideSprite = soundOff;
        }
        else
        {
            AudioListener.pause = false;
            GameManager.soundChk = true;
            sound.overrideSprite = soundOn;
        }
    }
    int count=0;
    public void freeCoins()
    {
        count++;
        if (count == 10)
        {
            PlayerPrefs.SetInt("Cash", 100200);
            PlayerPrefs.SetInt("LevelNoSnow", 9);
            PlayerPrefs.SetInt("LevelNoForest", 9);
            PlayerPrefs.SetInt("LevelNoDesert", 9);
            PlayerPrefs.SetInt("LevelNoCity", 9);
        }
        if (count == 20)
            PlayerPrefs.DeleteAll();
    }
}
