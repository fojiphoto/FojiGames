using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SWS;
public class GamePlay : MonoBehaviour {
    public static GamePlay instant;
    public Transform[] PlayerPos;
    public Transform Player;
    public GameObject PausePanel, LevelCompeltePanel, LevelFailpanel;
    public Text CarCount, BikeCount, HumanCount, JeepCount, TruckCount;
    public Text TotalTargets;
    public Text TotalCarsToShoot, TotalBikesToShoot,TotalHumanToShoot,TotalJeepToShoot,TotalTruckToShoot;
    public Text FailReason,PauseObjective,Timer;
    bool onetime;
    public AudioSource audios;
    public AudioClip levelfailsound, levelcompletesound;
   // public AdCalls ads;
    GameObject ActionCam;
    // Use this for initialization
    private void Awake()
    {
        ActionCam = GameObject.FindObjectOfType<AS_ActionCamera>().gameObject;
        ActionCam.SetActive(false);
        GameManager.start = false;
        int rnd = Random.Range(0, 2);
        Player.position = PlayerPos[rnd].transform.position;
        Player.rotation = PlayerPos[rnd].transform.rotation;
    }

    void Start() {
        if (GameObject.FindGameObjectWithTag("sound") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("sound"));
        }
        AdsManager.instance.LoadInterstetial();
        GameManager.CarCount = 0;
        GameManager.BikeCount = 0;
        GameManager.JeepCount = 0;
        GameManager.TruckCount = 0;
        GameManager.HumanCount = 0;
        GameManager.gameover = false;
        instant = this;
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.KillAll)
        {
            TotalTargets.text = ("" + GameManager.TotalTargets);
            if (GameManager.TotalTargets == 0 && !onetime)
            {
                onetime = true;
                StartCoroutine("LevelComplete");
            }

        }
        else
        {
            CarCount.text = GameManager.CarCount.ToString();
            BikeCount.text = GameManager.BikeCount.ToString();
            JeepCount.text = GameManager.JeepCount.ToString();
            TruckCount.text = GameManager.TruckCount.ToString();
            HumanCount.text = GameManager.HumanCount.ToString();
            TotalCarsToShoot.text = GameManager.TotalCarToShoot.ToString();
            TotalBikesToShoot.text = GameManager.TotalBikeToShoot.ToString();
            TotalJeepToShoot.text = GameManager.TotalJeepTarget.ToString();
            TotalTruckToShoot.text = GameManager.TotalTruckTarget.ToString();
            TotalHumanToShoot.text = GameManager.TotalHumanTarget.ToString();
            if (GameManager.CarCount == GameManager.TotalCarToShoot && GameManager.TotalBikeToShoot == GameManager.BikeCount && GameManager.JeepCount == GameManager.TotalJeepTarget && GameManager.TruckCount == GameManager.TotalTruckTarget && GameManager.HumanCount == GameManager.TotalHumanTarget && !onetime)
            {
                onetime = true;
                StartCoroutine("LevelComplete");
            }
            if (!GameManager.gameover)
            {
                if (GameManager.CarCount > GameManager.TotalCarToShoot)
                {
                    StartCoroutine("LevelFail");
                    GameManager.gameover = true;
                    FailReason.text = "You Hit the Wrong Target";
                }
                if (GameManager.BikeCount > GameManager.TotalBikeToShoot)
                {
                    GameManager.gameover = true;
                    StartCoroutine("LevelFail");
                    FailReason.text = "You Hit the Wrong Target";
                }
                if (GameManager.JeepCount > GameManager.TotalJeepTarget)
                {
                    GameManager.gameover = true;
                    StartCoroutine("LevelFail");
                    FailReason.text = "You Hit the Wrong Target";
                }
                if (GameManager.TruckCount > GameManager.TotalTruckTarget)
                {
                    GameManager.gameover = true;
                    StartCoroutine("LevelFail");
                    FailReason.text = "You Hit the Wrong Target";
                }
                if (GameManager.HumanCount > GameManager.TotalHumanTarget)
                {
                    GameManager.gameover = true;
                    StartCoroutine("LevelFail");
                    FailReason.text = "You Hit the Wrong Target";
                }
            }
        }
        if (GameManager.GameTime > 0f && GameManager.start)
        {
            GameManager.GameTime -= Time.deltaTime;
            UpdateTimer(GameManager.GameTime);

        }

        if (GameManager.GameTime <= 0 && !GameManager.gameover)
        {
            GameManager.gameover = true;
            Time_Over();
        }

    }
    void Time_Over()
    {
        GamePlay.instant.FailedReason();
        Debug.Log("Time is Over here");
        GamePlay.instant.StartCoroutine("LevelFail");
    }
    public void StartGame()
    {
        ActionCam.SetActive(true);
        GameManager.start = true;
    }

    void UpdateTimer(float secs)
    {
        int minutes = Mathf.FloorToInt(secs / 60f);
        int seconds = Mathf.RoundToInt(secs % 60f);

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }
        Timer.text = minutes.ToString("00") + " : " + seconds.ToString("00");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Resume()
    {
        ActionCam.SetActive(true);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Pause() {
        ActionCam.SetActive(false);
        Time.timeScale = 0;
    }
    public void Next_Level()
    {
            if (Application.loadedLevelName == "Desert Shooting")
            {
                if (PlayerPrefs.GetInt("SelectedDesert") == 9)
                {
                    Application.LoadLevel("Mode Selection");
                }
                else
                {
                    PlayerPrefs.SetInt("SelectedDesert", PlayerPrefs.GetInt("SelectedDesert") + 1);
                    Application.LoadLevel("Desert Shooting");
                }
            }
            else if (Application.loadedLevelName == "City Shooting")
            {
                if (PlayerPrefs.GetInt("SelectedCity") == 9)
                {
                    Application.LoadLevel("Mode Selection");
                }
                else
                {
                    PlayerPrefs.SetInt("SelectedCity", PlayerPrefs.GetInt("SelectedCity") + 1);
                    Application.LoadLevel("City Shooting");
                }
            }
            else if (Application.loadedLevelName == "Snow Shooting")
            {
                if (PlayerPrefs.GetInt("SelectedSnow") == 9)
                {
                    Application.LoadLevel("Mode Selection");
                }
                else
                {
                    PlayerPrefs.SetInt("SelectedSnow", PlayerPrefs.GetInt("SelectedSnow") + 1);
                    Application.LoadLevel("Snow Shooting");
                }
            }
            else if (Application.loadedLevelName == "Forest Shooting")
            {
                if (PlayerPrefs.GetInt("SelectedForest") == 9)
                {
                    Application.LoadLevel("Mode Selection");
                }
                else
                {
                    PlayerPrefs.SetInt("SelectedForest", PlayerPrefs.GetInt("SelectedForest") + 1);
                    Application.LoadLevel("Forest Shooting");
                }
            }
        
    }
    public IEnumerator LevelComplete() {
        yield return new WaitForSeconds(2.5f);
        Debug.Log("loaded Level is " + Application.loadedLevelName);
        audios.PlayOneShot(levelcompletesound);

        if (Application.loadedLevelName == "Forest Shooting")
        {
            if(PlayerPrefs.GetInt("SelectedForest") < 9 && PlayerPrefs.GetInt("SelectedForest") == PlayerPrefs.GetInt("LevelNoForest"))
            {
                PlayerPrefs.SetInt("LevelNoForest", PlayerPrefs.GetInt("LevelNoForest") + 1);
            }
        }else if (Application.loadedLevelName == "City Shooting")
        {
            if (PlayerPrefs.GetInt("SelectedCity") < 9 && PlayerPrefs.GetInt("SelectedCity") == PlayerPrefs.GetInt("LevelNoCity"))
            {
                PlayerPrefs.SetInt("LevelNoCity", PlayerPrefs.GetInt("LevelNoCity") + 1);
            }
        }
        else if (Application.loadedLevelName == "Desert Shooting")
        {
            if (PlayerPrefs.GetInt("SelectedDesert") < 9 && PlayerPrefs.GetInt("SelectedDesert") == PlayerPrefs.GetInt("LevelNoDesert"))
            {
                PlayerPrefs.SetInt("LevelNoDesert", PlayerPrefs.GetInt("LevelNoDesert") + 1);
            }
        }
        else if (Application.loadedLevelName == "Snow Shooting")
        {
            if (PlayerPrefs.GetInt("SelectedSnow") < 9 && PlayerPrefs.GetInt("SelectedSnow") == PlayerPrefs.GetInt("LevelNoSnow"))
            {
                PlayerPrefs.SetInt("LevelNoSnow", PlayerPrefs.GetInt("LevelNoSnow") + 1);
            }
        }
        LevelCompeltePanel.SetActive(true);
        GameManager.start = false;
        AdsManager.instance.ShowInterstetial();
        Debug.Log("Level Is Complete");
    }
    public void FailedReason()
    {
        FailReason.text = "You Ran out of time";
    }
    public IEnumerator LevelFail() {
        yield return new WaitForSeconds(2f);
        audios.PlayOneShot(levelfailsound);
        LevelFailpanel.SetActive(true);
        Time.timeScale = 0;
        AdsManager.instance.ShowInterstetial();
        Debug.Log("Level Is Failed");
    }
}
