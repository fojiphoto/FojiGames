using System.Collections;
using UnityEngine;
using SWS;

public class CustomPooling : MonoBehaviour {

    public GameObject[] Cars;
    public GameObject Parent;
    public int MaxOnRoad = 2;
    public float spawnAfterTime = 5,startSpawn=0;
    bool ischeck = false;
    public Transform SpawnPos;
    public PathManager pathmanger;
    public int StartHeathRangeOfCar = 10;
    public int EndHeathRangOfcar = 150;
    int AverageRang,nextCar;

    public Color[] CanvesColors;
    // Use this for initialization
    void Start () {
        StartCoroutine("ObjectPool", startSpawn);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Parent.transform.childCount <MaxOnRoad && ischeck)
        {
            StartCoroutine("ObjectPool", spawnAfterTime);
            ischeck = false;
        }
		
	}


    IEnumerator ObjectPool(float duration){
        yield return new WaitForSeconds(duration);
        int CarNo = nextCar;
        AverageRang = Random.Range(StartHeathRangeOfCar, EndHeathRangOfcar);
        Cars[CarNo].GetComponent<splineMove>().pathContainer = pathmanger;
        GameObject CarObj = Instantiate(Cars[CarNo], SpawnPos.position, Quaternion.identity) as GameObject;
        CarObj.transform.parent = Parent.transform;
        CarObj.GetComponent<MetalBarrel>().Health = AverageRang;
        ischeck = true;
        nextCar++;
    }
}
