using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool KillAll;
    public static int TotalTargets;
    public static bool[] TargetNum=new bool[10];
    public static bool start,gameover;
    public static int HoldNum=2,NoOfTargets, BulletNum,GunNo,ScopeNum;
    public static bool City, Desert, Forest, Snow,FalseKill;
    public static float GameTime = 90f;
    public static int CarCount = 0, HumanCount=0,JeepCount=0, BikeCount = 0,TruckCount=0;
    public static int TotalCarToShoot = 0,TotalBikeToShoot=0,TotalJeepTarget=1,TotalHumanTarget = 0,TotalTruckTarget=0;
    public static bool soundChk=true;

    public static void AllModeFalse() {
        City = false;
        Desert = false;
        Forest = false;
        Snow = false;

    }

}
