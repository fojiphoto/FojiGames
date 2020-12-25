using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public GameObject Loading;
    public GameObject Guns, BuyBtn, NoCoins,Selected;
    public GameObject Scope, Bullet,HoldBreathe;
    public Text PriceTxt, Cash, ScopeTxt,HoldTxt,Popup;
    public GameObject[] Gun,Bullets,Scopes;
    public Image[] Bars;
    public int[] GunPrice,ScopePrice, BulletPrice,HoldPrice;
    string btnName="Gun";
    string Name;
    int Price;
    int gunNo = 0, ScopeNum = 0, BulletNum = 0, HoldNum=0;
    int limit = 0,Add=1;

    
    private void Start()
    {
        AdsManager.instance.ShowInterstetial();
        PlayerPrefs.SetInt("Gun" + gunNo, 1);
        PlayerPrefs.SetInt("Scope" + ScopeNum, 1);
        PlayerPrefs.SetInt("Bullet" + BulletNum, 1);
        PlayerPrefs.SetInt("Hold" + HoldNum, 1);
        GetValues();
    }

    public void ShowRewardedVideo()
    {
        AdsManager.instance.ShowRewarded(this.RewardCoins);
    }
   
    void GetValues()
    {
        gunNo = PlayerPrefs.GetInt("CurrentGun");
        BulletNum = PlayerPrefs.GetInt("CurrentBullet");
        ScopeNum = PlayerPrefs.GetInt("CurrentScope");
        GameManager.GunNo = gunNo;
        GameManager.ScopeNum = ScopeNum;
        GameManager.BulletNum = BulletNum;

        Gun[gunNo].SetActive(true);
        Scopes[ScopeNum].SetActive(true);
        Bullets[BulletNum].SetActive(true);
        ScopeTxt.text = "" + (ScopeNum + 1) * 2 + "x";

        Bars[0].fillAmount = (BulletNum + 1) * 0.25f;
        Bars[1].fillAmount = (gunNo + 1) * 0.19f;
        Bars[3].fillAmount = (ScopeNum + 1) * 0.25f;
        Bars[4].fillAmount = (gunNo + 1) * 0.15f;
        Bars[5].fillAmount = (gunNo + 1) * 0.17f;
    }

    public void RewardCoins()
    {
        PlayerPrefs.SetInt("Cash", 100);
        Cash.text = "" + PlayerPrefs.GetInt("Cash");
    }

    private void Update()
    {
        Cash.text = "" + PlayerPrefs.GetInt("Cash");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Play()
    {
        Guns.SetActive(false);
        Bullet.SetActive(false);
        Loading.SetActive(true);
        SceneManager.LoadScene("Mode Selection");
    }
    public void GunSelection()
    {
        btnName = "Gun";
        Scope.SetActive(false);
        Guns.SetActive(true);
        Bullet.SetActive(false);
        if (PlayerPrefs.GetInt("Gun" + gunNo) == 0)
        {
            Selected.SetActive(false);
            BuyBtn.SetActive(true);
            Price = GunPrice[gunNo];
            PriceTxt.text = "" + Price;
        }
        else
        {
            BuyBtn.SetActive(false);
            Selected.SetActive(true);
        }
    }
    public void ScopeCustomization()
    {
        btnName = "Scope";
        Scope.SetActive(true);
        Guns.SetActive(false);
        Bullet.SetActive(false);
        if (PlayerPrefs.GetInt("Scope" + ScopeNum) == 0)
        {
            Selected.SetActive(false);
            BuyBtn.SetActive(true);
            Price = ScopePrice[ScopeNum];
            PriceTxt.text = "" + Price;
        }
        else
        {
            BuyBtn.SetActive(false);
            Selected.SetActive(true);
        }
    }
    public void BulletSelection()
    {
        btnName = "Bullet";
        Scope.SetActive(false);
        Guns.SetActive(false);
        Bullet.SetActive(true);
        if (PlayerPrefs.GetInt("Bullet" + BulletNum) == 0)
        {
            Selected.SetActive(false);
            BuyBtn.SetActive(true);
            Price = BulletPrice[BulletNum];
            PriceTxt.text = "" + Price;
        }
        else
        {
            BuyBtn.SetActive(false);
            Selected.SetActive(true);
        }
    }
    public void HoldBreatheSelection()
    {
        btnName = "Hold";
        HoldBreathe.SetActive(true);
        Scope.SetActive(false);
        Guns.SetActive(false);
        Bullet.SetActive(false);
        if (PlayerPrefs.GetInt("Hold" + HoldNum) == 0)
        {
            Selected.SetActive(false);
            BuyBtn.SetActive(true);
            Price = HoldPrice[HoldNum];
            PriceTxt.text = "" + Price;
        }
        else
        {
            BuyBtn.SetActive(false);
            Selected.SetActive(true);
        }
    }
    public void Selection(Button button)
    {
        Name = button.name;
        switch (btnName)
        {
            case ("Gun"):
                if (Name == "Next")
                {
                    limit = Gun.Length - 1;
                    Add = 1;
                }
                else
                {
                    limit = 0;
                    Add = -1;
                }
                if (gunNo != limit)
                {
                    gunNo += Add;
                    foreach (GameObject nextGun in Gun)
                    {
                        nextGun.SetActive(false);
                    }
                    Bars[1].fillAmount = (gunNo + 1) * 0.19f;
                    Bars[4].fillAmount = (gunNo + 1) * 0.15f;
                    Bars[5].fillAmount = (gunNo + 1) * 0.17f;

                    Gun[gunNo].SetActive(true);
                    Price = GunPrice[gunNo];
                    PriceTxt.text = "" + Price;
                }
                if (PlayerPrefs.GetInt("Gun" + gunNo) == 0)
                {
                    Selected.SetActive(false);
                    BuyBtn.SetActive(true);
                }
                else
                {
                    Selected.SetActive(true);
                    BuyBtn.SetActive(false);
                    GameManager.GunNo = gunNo;
                    PlayerPrefs.SetInt("CurrentGun", PlayerPrefs.GetInt("Gun", gunNo));
                }
                break;

            case ("Scope"):
                if (Name == "Next")
                {
                    limit = 3;
                    Add = 1;
                }
                else
                {
                    limit = 0;
                    Add = -1;
                }
                if (ScopeNum != limit)
                {
                    ScopeNum += Add;
                    foreach (GameObject nextScope in Scopes)
                    {
                        nextScope.SetActive(false);
                    }
                    Scopes[ScopeNum].SetActive(true);
                    Bars[3].fillAmount = (ScopeNum + 1) * 0.25f;
                    ScopeTxt.text = "" + (ScopeNum +1)*2+"X";
                    Price = ScopePrice[ScopeNum];
                    PriceTxt.text = "" + Price;
                }
                if (PlayerPrefs.GetInt("Scope" + ScopeNum) == 0)
                {
                    Selected.SetActive(false);
                    BuyBtn.SetActive(true);
                }
                else
                {
                    Selected.SetActive(true);
                    BuyBtn.SetActive(false);
                    GameManager.ScopeNum = ScopeNum;
                    PlayerPrefs.SetInt("CurrentScope", PlayerPrefs.GetInt("Scope", ScopeNum));
                }
                break;
            case ("Bullet"):
                if (Name == "Next")
                {
                    limit = 3;
                    Add = 1;
                }
                else
                {
                    limit = 0;
                    Add = -1;
                }
                if (BulletNum != limit)
                {
                    BulletNum += Add;
                    foreach (GameObject nextBullet in Bullets)
                    {
                        nextBullet.SetActive(false);
                    }
                    Bars[0].fillAmount = (BulletNum + 1) * 0.25f;
                    Bullets[BulletNum].SetActive(true);
                    Price = BulletPrice[BulletNum];
                    PriceTxt.text = "" + Price;
                }
                if (PlayerPrefs.GetInt("Bullet" + BulletNum) == 0)
                {
                    Selected.SetActive(false);
                    BuyBtn.SetActive(true);
                }
                else
                {
                    Selected.SetActive(true);
                    BuyBtn.SetActive(false);
                    GameManager.BulletNum = BulletNum;
                    PlayerPrefs.SetInt("CurrentBullet", PlayerPrefs.GetInt("Bullet", BulletNum));
                }
                break;
            case ("Hold"):
                if (Name == "Next")
                {
                    limit = 3;
                    Add = 1;
                }
                else
                {
                    limit = 0;
                    Add = -1;
                }
                if (HoldNum != limit)
                {
                    HoldNum += Add;
                    Bars[2].fillAmount = (HoldNum + 1) * 0.22f;
                    HoldTxt.text = "" + (HoldNum + 2) * 2 + " sec";
                    Price = HoldPrice[HoldNum];
                    PriceTxt.text = "" + Price;
                }
                if (PlayerPrefs.GetInt("Hold" + HoldNum) == 0)
                {
                    Selected.SetActive(false);
                    BuyBtn.SetActive(true);
                }
                else
                {
                    Selected.SetActive(true);
                    BuyBtn.SetActive(false);
                    GameManager.HoldNum = HoldNum;
                    PlayerPrefs.SetInt("CurrentHold", PlayerPrefs.GetInt("Hold", HoldNum));
                }
                break;
        }
    }

    public void Buy()
    {
        NoCoins.SetActive(false);
        switch (btnName)
        {
            case ("Gun"):
                if (Price <= PlayerPrefs.GetInt("Cash"))
                {
                    PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") - Price);
                    PlayerPrefs.SetInt("Gun" + gunNo, 1);
                    BuyBtn.SetActive(false);
                    GameManager.GunNo = gunNo;
                    NoCoins.SetActive(true);
                    Selected.SetActive(true);
                    Popup.text = "Item Unlocked";
                    StartCoroutine("Deactive");
                }
                else
                {
                    NoCoins.SetActive(true);
                    Popup.text = "Not Enough Cash";
                    StartCoroutine("Deactive");
                }
                break;
            case ("Scope"):
                if (Price <= PlayerPrefs.GetInt("Cash"))
                {
                    PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") - Price);
                    PlayerPrefs.SetInt("Scope" + ScopeNum, 1);
                    BuyBtn.SetActive(false);
                    GameManager.ScopeNum = ScopeNum;
                    NoCoins.SetActive(true);
                    Selected.SetActive(true);
                    Popup.text = "Item Unlocked";
                    StartCoroutine("Deactive");
                }
                else
                {
                    NoCoins.SetActive(true);
                    Popup.text = "Not Enough Cash";
                    StartCoroutine("Deactive");
                }
                break;
            case ("Bullet"):
                if (Price <= PlayerPrefs.GetInt("Cash"))
                {
                    PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") - Price);
                    PlayerPrefs.SetInt("Bullet" + BulletNum, 1);
                    BuyBtn.SetActive(false);
                    GameManager.BulletNum = BulletNum;
                    NoCoins.SetActive(true);
                    Selected.SetActive(true);
                    Popup.text = "Item Unlocked";
                    StartCoroutine("Deactive");
                }
                else
                {
                    NoCoins.SetActive(true);
                    Popup.text = "Not Enough Cash";
                    StartCoroutine("Deactive");
                }
                break;
            case ("Hold"):
                if (Price <= PlayerPrefs.GetInt("Cash"))
                {
                    PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") - Price);
                    PlayerPrefs.SetInt("Hold" + HoldNum, 1);
                    BuyBtn.SetActive(false);
                    GameManager.HoldNum = HoldNum;
                    NoCoins.SetActive(true);
                    Selected.SetActive(true);
                    Popup.text = "Item Unlocked";
                    StartCoroutine("Deactive");
                }
                else
                {
                    NoCoins.SetActive(true);
                    Popup.text = "Not Enough Cash";
                    StartCoroutine("Deactive");
                }
                break;
        }
        PlayerPrefs.SetInt("CurrentHold", PlayerPrefs.GetInt("Hold", HoldNum));
        PlayerPrefs.SetInt("CurrentBullet", PlayerPrefs.GetInt("Bullet", BulletNum));
        PlayerPrefs.SetInt("CurrentScope", PlayerPrefs.GetInt("Scope", ScopeNum));
        PlayerPrefs.SetInt("CurrentGun", PlayerPrefs.GetInt("Gun", gunNo));
    }

    IEnumerator Deactive()
    {
        yield return new WaitForSeconds(2f);
        NoCoins.SetActive(false);
    }

    public void Clear()
    {
        PlayerPrefs.DeleteAll();
    }
    public void Set()
    {
        PlayerPrefs.SetInt("Cash", 100000);
    }
}
