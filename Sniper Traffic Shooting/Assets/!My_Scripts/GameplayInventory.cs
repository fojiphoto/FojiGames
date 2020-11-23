
using UnityEngine;
using UnityEngine.UI;
public class GameplayInventory : MonoBehaviour {
    public GameObject[] Guns,Scopes;
    public Text ScopeTimes;
    public Slider ZoomSlider;
    int gunNo, ScopeNum, BulletNum, HoldNum;
    private void Start()
    {
        Guns[GameManager.GunNo].SetActive(true);
        ScopeTimes.text=""+(GameManager.ScopeNum + 1) * 2 + "x";
        Scopes[GameManager.ScopeNum].SetActive(true);
        if (GameManager.ScopeNum == 0)
        {
            ZoomSlider.maxValue = 18;
        }else if (GameManager.ScopeNum == 1)
        {
            ZoomSlider.maxValue = 20;
        }
        else if (GameManager.ScopeNum == 2)
        {
            ZoomSlider.maxValue = 22;
        }
        else
        {
            ZoomSlider.maxValue = 24;
        }

    }


    


}
