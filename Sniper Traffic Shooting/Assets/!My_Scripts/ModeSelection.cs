using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ModeSelection : MonoBehaviour {
    public GameObject LOADING;
    public Text Cash;
    //public GameObject[] Selected;
    int modeNo;
    // Use this for initialization
    void Start()
    {
        Cash.text = PlayerPrefs.GetInt("Cash").ToString();
        GameManager.AllModeFalse();
        if (PlayerPrefs.HasKey("Mode"))
        {
            if (PlayerPrefs.GetInt("Mode") == 1)
            {
                modeNo = PlayerPrefs.GetInt("Mode");
                GameManager.City = true;
            }
            else if (PlayerPrefs.GetInt("Mode") == 2)
            {
                modeNo = PlayerPrefs.GetInt("Mode");
                GameManager.Forest = true;
            }
            else if (PlayerPrefs.GetInt("Mode") == 3)
            {
                modeNo = PlayerPrefs.GetInt("Mode");
                GameManager.Snow = true;
            }
            else if (PlayerPrefs.GetInt("Mode") == 4)
            {
                modeNo = PlayerPrefs.GetInt("Mode");
                GameManager.Desert = true;
            }
            //foreach (GameObject item in Selected)
            //{
            //    item.SetActive(false);
            //}
            //Selected[modeNo - 1].SetActive(true);
        }
        else
        {
            modeNo = 1;
            GameManager.City = true;
            //foreach (GameObject item in Selected)
            //{
            //    item.SetActive(false);
            //}
            //Selected[modeNo - 1].SetActive(true);
        }
    }
    public void CityMode() {
        GameManager.AllModeFalse();
        GameManager.City = true;
        modeNo = 1;
        //foreach (GameObject item in Selected)
        //{
        //    item.SetActive(false);
        //}
        //Selected[modeNo-1].SetActive(true);
        PlayerPrefs.SetInt("Mode", modeNo);
        NextButton();
    }
    public void ForestMode()
    {
        GameManager.AllModeFalse();
        GameManager.Forest = true;
        modeNo = 2;
        //foreach (GameObject item in Selected)
        //{
        //    item.SetActive(false);
        //}
        //Selected[modeNo - 1].SetActive(true);
        PlayerPrefs.SetInt("Mode", modeNo);
        NextButton();
    }
    public void SnowMOde()
    {
        GameManager.AllModeFalse();
        GameManager.Snow = true;
        modeNo = 3;
        //foreach (GameObject item in Selected)
        //{
        //    item.SetActive(false);
        //}
        //Selected[modeNo - 1].SetActive(true);
        PlayerPrefs.SetInt("Mode", modeNo);
        NextButton();
    }
    public void DesertMode()
    {
        GameManager.AllModeFalse();
        GameManager.Desert = true;
        modeNo = 4;
        //foreach (GameObject item in Selected)
        //{
        //    item.SetActive(false);
        //}
        //Selected[modeNo - 1].SetActive(true);
        //PlayerPrefs.SetInt("Mode", modeNo);
        NextButton();
    }

    public void NextButton() {
        PlayerPrefs.SetInt("Mode", modeNo);
        LOADING.SetActive(true);
        Application.LoadLevel("LevelSelection");

    }

    public void BackButton() {
        Application.LoadLevel("Inventory");

    }

}
