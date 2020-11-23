using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public GameObject[] Levels;
    public GameObject ObjectivePanel;
    public Text Objective_Text,PauseObjective;
    private int LevelNo;
    bool start;
    // Use this for initialization
    void Start () {
        GameManager.KillAll = false;


        if (Application.loadedLevelName == "Desert Shooting")
        {
            Levels[PlayerPrefs.GetInt("SelectedDesert")].SetActive(true);
            LevelNo = PlayerPrefs.GetInt("SelectedDesert");
        }
        if (Application.loadedLevelName == "Forest Shooting")
        {
            Levels[PlayerPrefs.GetInt("SelectedForest")].SetActive(true);
            LevelNo = PlayerPrefs.GetInt("SelectedForest");
        }
        if (Application.loadedLevelName == "City Shooting")
        {
            Levels[PlayerPrefs.GetInt("SelectedCity")].SetActive(true);
            LevelNo = PlayerPrefs.GetInt("SelectedCity");
        }
        if (Application.loadedLevelName == "Snow Shooting")
        {
            Levels[PlayerPrefs.GetInt("SelectedSnow")].SetActive(true);
            LevelNo = PlayerPrefs.GetInt("SelectedSnow");
        }


        if (Application.loadedLevelName == "Desert Shooting")
        {
            if (LevelNo == 0)
            {
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 2;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 150;
                Objective_Text.text = "kill 2 gang member.";

            }else
            if (LevelNo == 1)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 4;
                GameManager.TotalJeepTarget = 1;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 150;
                Objective_Text.text = "Kill 4 gangsters and destroy 1 Jeep.\n HINT: Destroy moving targets first";

            }else
            if (LevelNo == 2)
            {
                GameManager.TargetNum[0] = true ;
                GameManager.TotalCarToShoot =0;
                GameManager.TotalHumanTarget = 4;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 2;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 90;
                Objective_Text.text = " Destroy 2 truck and kill 4 goons.\n HINT: Destroy moving targets first.";

            }
            else if (LevelNo == 3)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 3;
                GameManager.TotalJeepTarget = 1;
                GameManager.TotalTruckTarget = 2;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 90;
                Objective_Text.text = "Destroy 1 jeep, 2 trucks and 3 gangsters.";

            }
            else if (LevelNo == 4)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TargetNum[2] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 1;
                GameManager.TotalJeepTarget = 2;
                GameManager.TotalTruckTarget = 3;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 180;
                Objective_Text.text = "Destroy 3 truck, 2 jeeps and 1 gangster ";
            }
            else if (LevelNo == 5)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TargetNum[2] = true;
                GameManager.TargetNum[3] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 2;
                GameManager.TotalJeepTarget = 2;
                GameManager.TotalTruckTarget = 5;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 150;
                Objective_Text.text = "Destroy 2 Jeeps, 5 trucks and 2 goons.";
            }
            else if (LevelNo == 6)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TargetNum[2] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 4;
                GameManager.TotalJeepTarget = 1;
                GameManager.TotalTruckTarget = 4;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 120;
                Objective_Text.text = "Destroy 1 jeep, 4 trucks and 4 goons ";
            }
            else if (LevelNo == 7)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TargetNum[2] = true;
                GameManager.TargetNum[3] = true;
                GameManager.TargetNum[4] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 2;
                GameManager.TotalJeepTarget = 5;
                GameManager.TotalTruckTarget = 1;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 130;
                Objective_Text.text = "Destroy 5 jeeps, 1 truck and 2 goons ";
            }
            else if (LevelNo == 8)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 7;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 140;
                Objective_Text.text = "Kill 7 gangsters";
            }
            else if (LevelNo == 9)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TargetNum[2] = true;
                GameManager.TargetNum[3] = true;
                GameManager.TargetNum[4] = true;
                GameManager.TotalCarToShoot = 1;
                GameManager.TotalHumanTarget = 5;
                GameManager.TotalJeepTarget = 3;
                GameManager.TotalTruckTarget = 2;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 150;
                Objective_Text.text = "Kill boss in Blue car and his convoy.";
            }
        }
        if (Application.loadedLevelName == "Forest Shooting")
        {
            if (LevelNo == 0)
            {
                GameManager.KillAll = true;
                GameManager.TotalTargets = 5;
                GameManager.TotalCarToShoot = 3;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 1;
                GameManager.GameTime = 90;
                Objective_Text.text = "Destroy any 5 vehicles.";

            }
            else
            if (LevelNo == 1)
            {
                GameManager.KillAll = true;
                GameManager.TotalTargets = 6;
                GameManager.TotalCarToShoot = 4;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 1;
                GameManager.GameTime = 90;
                Objective_Text.text = "Destroy any 6 vehicles.";

            }
            else
            if (LevelNo == 2)
            {
                GameManager.KillAll = true;
                GameManager.TotalTargets = 7;
                GameManager.TotalCarToShoot = 4;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 2;
                GameManager.GameTime = 90;
                Objective_Text.text = "Destroy any 7 vehicles.";

            }
            else if (LevelNo == 3)
            {
                GameManager.KillAll = true;
                GameManager.TotalTargets = 9;
                GameManager.TotalCarToShoot = 5;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 1;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 1;
                GameManager.GameTime = 90;
                Objective_Text.text = "Destroy any 9 vehicles.";

            }
            else if (LevelNo == 4)
            {
                GameManager.KillAll = true;
                GameManager.TotalTargets = 10;
                GameManager.TotalCarToShoot = 5;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 2;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 90;
                Objective_Text.text = "Destroy any 10 vehicles.";
            }
            else if (LevelNo == 5)
            {
                GameManager.KillAll = true;
                GameManager.TotalTargets = 3;
                GameManager.TotalCarToShoot = 4;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 1;
                GameManager.TotalTruckTarget = 1;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 30; 
                Objective_Text.text = "Destroy any 3 vehicles.";
            }
            else if (LevelNo == 6)
            {
                GameManager.KillAll = true;
                GameManager.TotalTargets = 5;
                GameManager.TotalCarToShoot = 3;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 3;
                GameManager.TotalTruckTarget = 1;
                GameManager.TotalBikeToShoot = 2;
                GameManager.GameTime = 30;
                Objective_Text.text = "Destroy any 5 vehicles.";
            }
            else if (LevelNo == 7)
            {
                GameManager.KillAll = true;
                GameManager.TotalTargets = 7;
                GameManager.TotalCarToShoot =0;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 2;
                GameManager.TotalTruckTarget = 3;
                GameManager.TotalBikeToShoot = 1;
                GameManager.GameTime = 45;
                Objective_Text.text = "Destroy any 7 vehicles.";
            }
            else if (LevelNo == 8)
            {
                GameManager.KillAll = true;
                GameManager.TotalTargets = 10;
                GameManager.TotalCarToShoot = 3;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 3;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 60;
                Objective_Text.text = "Destroy any 10 vehicles.";
            }
            else if (LevelNo == 9)
            {
                GameManager.KillAll = true;
                GameManager.TotalTargets = 15;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 1;
                GameManager.TotalJeepTarget = 3;
                GameManager.TotalTruckTarget = 5;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 90;
                Objective_Text.text = "Destroy any 15 vehicles.";
            }
        }
        if (Application.loadedLevelName == "City Shooting")
        {
            if (LevelNo == 0)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 2;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 180;
                Objective_Text.text = "Kill 2 gangsters.\n Hint: Try to Kill Moving in jeep first.";

            }
            else
            if (LevelNo == 1)
            {
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 4;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 180;
                Objective_Text.text = "Kill 4 goons.\n Hint: Try to Kill enemy Moving in vehicles first";

            }
            else
            if (LevelNo == 2)
            {
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 5;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 180;
                Objective_Text.text = "Kill 5 gangsters.\n Hint: Try to Kill enemy Moving in vehicles first";

            }
            else if (LevelNo == 3)
            {
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 4;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 180;
                Objective_Text.text = "Kill 4 enemies.\n Hint: Try to Kill enemy Moving in vehicles first";

            }
            else if (LevelNo == 4)
            {
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 6;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 180;
                Objective_Text.text = "Kill 6 gangsters.\n Hint: Try to Kill enemy Moving in vehicles first";
            }
            else if (LevelNo == 5)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 5;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 180;
                Objective_Text.text = "Kill 5 goons.\n Hint: Try to Kill enemy Moving in vehicles first";
            }
            else if (LevelNo == 6)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 6;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 180;
                Objective_Text.text = "Kill 6 gang members";
            }
            else if (LevelNo == 7)
            {
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 7;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 240;
                Objective_Text.text = "Kill 7 gang members";
            }
            else if (LevelNo == 8)
            {
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 8;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 240;
                Objective_Text.text = "Kill 8 gang members";
            }
            else if (LevelNo == 9)
            {
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 10;
                GameManager.TotalJeepTarget = 0;
                GameManager.TotalTruckTarget = 0;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 240;
                Objective_Text.text = "Kill 10 gang members";
            }
        }
        if (Application.loadedLevelName == "Snow Shooting")
        {
            if (LevelNo == 0)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 2;
                GameManager.TotalTruckTarget = 1;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 90;
                Objective_Text.text = "Destroy 1 truck and 2 jeeps. They are transporting weapons.";
            }
            else
            if (LevelNo == 1)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 1;
                GameManager.TotalTruckTarget = 2;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 110;
                Objective_Text.text = "Destroy 1 jeep and 2 truck before they leave.";

            }
            else
            if (LevelNo == 2)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 2;
                GameManager.TotalTruckTarget = 2;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 120;
                Objective_Text.text = "Destroy 2 trucks and 2 jeeps They are transporting missiles";

            }
            else if (LevelNo == 3)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TargetNum[2] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 3;
                GameManager.TotalTruckTarget = 2;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 120;
                Objective_Text.text = "Destroy 2 trucks and 3 jeeps. They are transporting drugs.";

            }
            else if (LevelNo == 4)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TargetNum[2] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 2;
                GameManager.TotalTruckTarget = 4;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 130;
                Objective_Text.text = "Destroy 2 jeeps and 4 trucks. They are transporting RDX.";
            }
            else if (LevelNo == 5)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TargetNum[2] = true;
                GameManager.TargetNum[3] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 3;
                GameManager.TotalTruckTarget = 4;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 130;
                Objective_Text.text = "Destroy 3 jeeps and 4 trucks. They are transporting guns.";
            }
            else if (LevelNo == 6)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TargetNum[2] = true;
                GameManager.TargetNum[3] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 1;
                GameManager.TotalTruckTarget = 6;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 150;
                Objective_Text.text = "Destroy 1 jeep and 6 trucks. They are moving explosive.";
            }
            else if (LevelNo == 7)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TargetNum[2] = true;
                GameManager.TargetNum[3] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 2;
                GameManager.TotalTruckTarget = 5;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 150;
                Objective_Text.text = "Destroy 2 Jeeps, 5 Trucks. They have lethal camicals.";
            }
            else if (LevelNo == 8)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TargetNum[2] = true;
                GameManager.TargetNum[3] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 3;
                GameManager.TotalTruckTarget = 4;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 120;
                Objective_Text.text = "Destroy 3 jeeps, 4 trucks. They are transporting weapons";
            }
            else if (LevelNo == 9)
            {
                GameManager.TargetNum[0] = true;
                GameManager.TargetNum[1] = true;
                GameManager.TargetNum[2] = true;
                GameManager.TargetNum[3] = true;
                GameManager.TargetNum[4] = true;
                GameManager.TargetNum[5] = true;
                GameManager.TargetNum[6] = true;
                GameManager.TargetNum[7] = true;
                GameManager.TargetNum[8] = true;
                GameManager.TargetNum[9] = true;
                GameManager.TotalCarToShoot = 0;
                GameManager.TotalHumanTarget = 0;
                GameManager.TotalJeepTarget = 5;
                GameManager.TotalTruckTarget = 5;
                GameManager.TotalBikeToShoot = 0;
                GameManager.GameTime = 120;
                Objective_Text.text = "Destroy 5 jeeps and 5 trucks. This is a Boss Convoy.";
            }
        }
        ObjectivePanel.SetActive(true);
        PauseObjective.text = Objective_Text.text;
    }
    
}
