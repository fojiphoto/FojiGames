using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour {
    public GameObject Desert, city, forest, snow, Loading;
    public GameObject[] LockImageCity;
    public GameObject[] LockImageDesert;
    public GameObject[] LockImageSnow;
    public GameObject[] LockImageForest;
    
	// Use this for initialization
	void Start () {

      // PlayerPrefs.DeleteAll();
        Desert.SetActive(false);
        city.SetActive(false);
        forest.SetActive(false);
        snow.SetActive(false);

        //if (!PlayerPrefs.HasKey("LevelNoCity"))
        //{
        //    PlayerPrefs.SetInt("LevelNoCity", 1);
        //}
        //if (!PlayerPrefs.HasKey("LevelNoDesert"))
        //{
        //    PlayerPrefs.SetInt("LevelNoDesert", 1);
        //}
        //if (!PlayerPrefs.HasKey("LevelNoForest"))
        //{
        //    PlayerPrefs.SetInt("LevelNoForest", 1);
        //}
        //if (!PlayerPrefs.HasKey("LevelNoSnow"))
        //{
        //    PlayerPrefs.SetInt("LevelNoSnow", 1);
        //}


        if (GameManager.Desert)
        {
            Desert.SetActive(true);
            for (int i = 0; i <= PlayerPrefs.GetInt("LevelNoDesert"); i++)
            {
                LockImageDesert[i].SetActive(false);
            }
            Debug.Log("desert unLocking " + PlayerPrefs.GetInt("LevelNoDesert"));
        }
        else
            if (GameManager.Forest)
        {
            forest.SetActive(true);
            for (int i = 0; i <= PlayerPrefs.GetInt("LevelNoForest"); i++)
            {
                LockImageForest[i].SetActive(false);
            }
            Debug.Log("Forest Unloacking "+ PlayerPrefs.GetInt("LevelNoForest"));
        }
        else
            if (GameManager.Snow)
        {
            snow.SetActive(true);
            for (int i = 0; i <= PlayerPrefs.GetInt("LevelNoSnow"); i++)
            {
                LockImageSnow[i].SetActive(false);
            }
            Debug.Log("Snow Unloacking " + PlayerPrefs.GetInt("LevelNoSnow"));
        }
        else if(GameManager.City)
        {
            city.SetActive(true);
            for (int i = 0; i <= PlayerPrefs.GetInt("LevelNoCity"); i++)
            {
                LockImageCity[i].SetActive(false);
            }
            Debug.Log("City Unloacking " + PlayerPrefs.GetInt("LevelNoCity"));
        }

       

    }
	

    public void BackButton()
    {
        Application.LoadLevel("Mode Selection");

    }

    public void SelectLevel(int levelNo) {
        

        if (GameManager.City)
        {
            if (levelNo <= PlayerPrefs.GetInt("LevelNoCity"))
            {
                PlayerPrefs.SetInt("SelectedCity", levelNo);
                Application.LoadLevel("City Shooting");
                Loading.SetActive(true);

            }
        }
        else if (GameManager.Desert)
        {
            if (levelNo <= PlayerPrefs.GetInt("LevelNoDesert"))
            {
                PlayerPrefs.SetInt("SelectedDesert", levelNo);
                Application.LoadLevel("Desert Shooting");
                Loading.SetActive(true);

            }
        }
        else if (GameManager.Snow)
        {
                if (levelNo <= PlayerPrefs.GetInt("LevelNoSnow"))
                {
                    PlayerPrefs.SetInt("SelectedSnow", levelNo);
                    Application.LoadLevel("Snow Shooting");
                Loading.SetActive(true);

            }
        }
        else if (GameManager.Forest)
        {
                    if (levelNo <= PlayerPrefs.GetInt("LevelNoForest"))
                    {
                        PlayerPrefs.SetInt("SelectedForest", levelNo);
                        Application.LoadLevel("Forest Shooting");
                Loading.SetActive(true);

            }
        }

    }

}
