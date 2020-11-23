using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class ObjectPooling : MonoBehaviour {
    public bool Custom;
    public int CustomCarAfterNum;
    public GameObject[] Cars,SpecialCars;
    public GameObject Parent;
    public int MaxOnRoad = 2;
    public float spawnAfterTime = 5, specialSpawnAfterTime = 0;
    bool ischeck = false;
    public Transform SpawnPos;
    public PathManager pathmanger;
    public int StartHealthCar = 10, StartHealthBike = 10, StartHealthJeep = 10, StartHealthTruck = 10;
    public int TotalSpecialSpawns;
    //public int EndHeathRangeOfcar = 150, EndHeathRangeOfBike = 150, EndHeathRangeOfJeep = 150, EndHeathRangeOfTruck = 150;
    int AverageRang,SpawnNumber, specialSpawns = 0;
    // Use this for initialization
    void Start () {
        StartCoroutine("ObjectPool", 0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Custom)
        {
            if (specialSpawns <= TotalSpecialSpawns-1)
            {
                if (ischeck)
                {
                    StartCoroutine("ObjectPool", specialSpawnAfterTime);
                    ischeck = false;
                }
            }
            else
            {
                Custom = false;
            }
        }
        else if (Parent.transform.childCount <MaxOnRoad && ischeck)
        {
            StartCoroutine("ObjectPool", spawnAfterTime);
            ischeck = false;
        }
		
	}

    IEnumerator ObjectPool(float duration){
        yield return new WaitForSeconds(duration);
        if (Custom)
        {
            int CarNo = specialSpawns;
            SpecialCars[CarNo].GetComponent<splineMove>().pathContainer = pathmanger;
            GameObject CarObj = Instantiate(SpecialCars[CarNo], SpawnPos.position, Quaternion.identity) as GameObject;
            CarObj.transform.parent = Parent.transform;
            if (CarObj.GetComponent<MetalBarrel>().isbike)
            {
                AverageRang = StartHealthBike;
            }else if (CarObj.GetComponent<MetalBarrel>().Truck)
            {
                AverageRang = StartHealthTruck;
            }
            else if(CarObj.GetComponent<MetalBarrel>().Jeep)
            {
                AverageRang = StartHealthJeep;
            }else if (CarObj.GetComponent<MetalBarrel>().isCar)
            {
                AverageRang = StartHealthCar;
            }
            else if (CarObj.GetComponent<MetalBarrel>().containEnemy)
            {
                AverageRang = StartHealthTruck;
            }
            if (Application.loadedLevelName == "Desert Shooting")
            {
                if (PlayerPrefs.GetInt("SelectedDesert") < 5)
                    CarObj.GetComponent<splineMove>().speed = 10;
                else CarObj.GetComponent<splineMove>().speed = 15;
            }
            if (Application.loadedLevelName == "Forest Shooting")
            {
                if (PlayerPrefs.GetInt("SelectedForest") < 5)
                    CarObj.GetComponent<splineMove>().speed = 10;
                else CarObj.GetComponent<splineMove>().speed = 15;
            }
            if (Application.loadedLevelName == "City Shooting")
            {
                if (PlayerPrefs.GetInt("SelectedCity") < 5)
                    CarObj.GetComponent<splineMove>().speed = 10;
                else CarObj.GetComponent<splineMove>().speed = 15;
            }
            if (Application.loadedLevelName == "Snow Shooting")
            {
                if (PlayerPrefs.GetInt("SelectedSnow") < 5)
                    CarObj.GetComponent<splineMove>().speed = 10;
                else CarObj.GetComponent<splineMove>().speed = 15;
            }
            CarObj.GetComponent<MetalBarrel>().Health = AverageRang;
            if (GameManager.TargetNum[CarNo])
                CarObj.GetComponent<MetalBarrel>().isTarget = true;
            ischeck = true;
            specialSpawns++;
        }
        else
        {
            int CarNo = Random.Range(0, Cars.Length);
            Cars[CarNo].GetComponent<splineMove>().pathContainer = pathmanger;
            GameObject CarObj = Instantiate(Cars[CarNo], SpawnPos.position, Quaternion.identity) as GameObject;
            CarObj.transform.parent = Parent.transform;
            if (CarObj.GetComponent<MetalBarrel>().isbike)
            {
                AverageRang = StartHealthBike;
            }
            else if (CarObj.GetComponent<MetalBarrel>().Truck)
            {
                AverageRang = StartHealthTruck;
            }
            else if (CarObj.GetComponent<MetalBarrel>().Jeep)
            {
                AverageRang = StartHealthJeep;
            }
            else if (CarObj.GetComponent<MetalBarrel>().isCar)
            {
                AverageRang = StartHealthCar;
            }
            if (Application.loadedLevelName == "Desert Shooting")
            {
                if (PlayerPrefs.GetInt("SelectedDesert") < 5)
                    CarObj.GetComponent<splineMove>().speed = 10;
                else CarObj.GetComponent<splineMove>().speed = 15;
            }
            if (Application.loadedLevelName == "Forest Shooting")
            {
                if (PlayerPrefs.GetInt("SelectedForest") < 5)
                    CarObj.GetComponent<splineMove>().speed = 10;
                else CarObj.GetComponent<splineMove>().speed = 15;
            }
            if (Application.loadedLevelName == "City Shooting")
            {
                if (PlayerPrefs.GetInt("SelectedCity") < 5)
                    CarObj.GetComponent<splineMove>().speed = 10;
                else CarObj.GetComponent<splineMove>().speed = 15;
            }
            if (Application.loadedLevelName == "Snow Shooting")
            {
                if (PlayerPrefs.GetInt("SelectedSnow") < 5)
                    CarObj.GetComponent<splineMove>().speed = 10;
                else CarObj.GetComponent<splineMove>().speed = 15;
            }
            CarObj.GetComponent<MetalBarrel>().Health = AverageRang;
            if (GameManager.KillAll)
            {
                CarObj.GetComponent<MetalBarrel>().isTarget = true;
                CarObj.GetComponent<MetalBarrel>().killall = true;

            }
                ischeck = true;
            if(GameManager.start)
            SpawnNumber++;
            if (SpawnNumber == CustomCarAfterNum)
                Custom = true;
        }

    }
}
