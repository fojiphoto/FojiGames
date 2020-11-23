using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using SWS;

public class MetalBarrel : MonoBehaviour {
	public GameObject[] Chunks; //parts of the broken object.
	[Range(0.0F, 30.0F)]
	public float BurningTime = 3;
	[Range(1,500)]
	public int Health;
	public float ExplosionForce = 200; //force added to every chunk of the broken object.
	public float ChunksRotation = 20; //rotation force added to every chunk when it explodes.
	public bool BreakByClick = true;
	public bool DestroyAfterTime = true; //if true, then chunks will be destroyed after time.
	public float time = 5; //time before chunks will be destroyed from the scene.
	public GameObject ExpLight;
	public GameObject FireFX;
	public bool AutoDestroy = true; //if true, then object will be automatically break after after "AutoDestTime" since game start.
	public float AutoDestTime = 2; //Auto destruction time (counts from game start).
    public bool isCar = false, isbike = false;
    public GameObject Car, PointsCan;
    public GameObject NukeExplode,Arrow;
    GameObject HealthBar;
    float delay=3f;
    [HideInInspector]
    public bool killall;
    public bool isTarget,Jeep,Truck,containEnemy;
    Transform explosive;
    void Start () {
        explosive = transform;

        if (AutoDestroy)
        {
            Invoke("Crushing", AutoDestTime);
        }
        if (isTarget)
        {
            if(!killall && !containEnemy)
            Arrow.SetActive(true);
        }
            HealthBar = GetComponentInChildren<TargetLook>().gameObject;
        HealthBar.SetActive(false);
        FireFX.SetActive(false);
		if(GetComponent<AudioSource>()){
			GetComponent<AudioSource>().pitch = Random.Range (1, 1.3f);
		}
        if(!containEnemy)
        HealthBar.transform.GetChild(0).GetComponent<Slider>().maxValue = Health;
        //PointsCan.transform.position = new Vector3(0,0,0);
       // canvespos.position = PointsCan.transform.position;
       // temppos = new Vector3(0, PointsCan.transform.position.y+8, 0);
	}
    
        void OnCollisionEnter(Collision other)
    {
        
            if (Health <= 0 && !FireFX.activeInHierarchy)
            {
                FireFX.SetActive(true);
                Invoke("Crushing", BurningTime);
            }
         if (other.gameObject.tag == "BarrelChunk" && !FireFX.activeInHierarchy)
        {
            Health = 0;
            FireFX.SetActive(true);
            Invoke("Crushing", BurningTime);
        }
    }
    void FixedUpdate(){
		if(ExpLight && ExpLight.GetComponent<Light>().intensity >0  ){
			ExpLight.GetComponent<Light>().intensity -= 0.3f;
		}
	}

	void OnMouseDown(){
		if(BreakByClick){
			Health = 0;
			FireFX.SetActive(true);
			Invoke("Crushing", BurningTime);
			BreakByClick = false;
		}
		}
    public void BarrelDestroy(){
        //if (isCar )
        //{
            if (Health >= 0)
            {
                delay = 3f;
            if(!containEnemy)
                HealthBar.SetActive(true);
                Invoke("Deactive", 3.1f);

            }
            if(Health <= 0)
            {
                FireFX.SetActive(true);
            if (!containEnemy)
                HealthBar.SetActive(false);
                Invoke("Crushing", BurningTime);
            }
        if (!containEnemy)
            HealthBar.transform.GetChild(0).GetComponent<Slider>().value = Health;

        //}
    }
    private void Update()
    {
        delay -= Time.deltaTime;
    }
    void Deactive()
    {
        if (delay <= 0)
            HealthBar.SetActive(false);
    }
    bool destroyed;
	void Crushing(){
		FireFX.SetActive(false);
        //GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        foreach (GameObject chunk in Chunks){
			chunk.SetActive(true);
			chunk.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * -ExplosionForce);
			chunk.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.forward * -ChunksRotation*Random.Range(-5f, 5f));
			chunk.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.right * -ChunksRotation*Random.Range(-5f, 5f));
		}
        if (!containEnemy)
        {
            if (HealthBar.transform.GetChild(0).GetComponent<Slider>().maxValue > 70 && HealthBar.transform.GetChild(0).GetComponent<Slider>().maxValue < 150)
            {
                GetComponentInChildren<CFX_AutoDestructShuriken>().gameObject.GetComponent<ParticleSystem>().Play();
            }
            else if (HealthBar.transform.GetChild(0).GetComponent<Slider>().maxValue > 150)
                NukeExplode.SetActive(true);
        }
        else
        {
            NukeExplode.SetActive(true);
        }
        if (!destroyed)
        {
            if (isbike)
            {
                if (isTarget)
                {
                    PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 50);
                PointsCan.SetActive(true);
                }
                destroyed = true;
                Car.GetComponentInChildren<Renderer>().material.color = Color.black;
                Invoke("splinemove", 1);
            }else if (Truck || Jeep)
            {
                if (isTarget && !containEnemy)
                {
                    PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 200);
                PointsCan.SetActive(true);
                }
                destroyed = true;
                Car.GetComponentInChildren<Renderer>().material.color = Color.black;
                Invoke("splinemove", 1);
            }
            else if (isCar)
            {
                if (isTarget)
                {
                    PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 100);
                    PointsCan.SetActive(true);
                }
                    destroyed = true;
                Car.GetComponentInChildren<Renderer>().material.color = Color.black;
                Invoke("splinemove", 1);
            }
            if (containEnemy)
            {
                Car.GetComponentInChildren<Renderer>().material.color = Color.black;
                Collider[] colls = Physics.OverlapSphere(explosive.position, 10);
                foreach (Collider col in colls)
                {
                    if (col.CompareTag("Enemy"))
                    {
                        float distance = Vector3.Distance(col.transform.position, explosive.position);
                        float magnitude = 200;
                        Vector3 force = transform.position - col.transform.position;
                        force.Normalize();
                        col.GetComponent<Hit_Body>().BlastKill(200, force * -magnitude);
                    }
                }
            }

        }
		if(DestroyAfterTime){
			Invoke("DestructObject", time);
		}
	}



	public void DestructObject(){
		Destroy(gameObject);
	}


    void splinemove()
    {
        // gameObject.GetComponent<splineMove>().Pause();
        if (GameManager.KillAll)
        {
            GameManager.TotalTargets -= 1;
        }
        else
        {
            if (Jeep)
            {
                if (GameManager.TotalJeepTarget == 0 || !isTarget)
                {
                    GamePlay.instant.StartCoroutine("LevelFail");
                    GamePlay.instant.FailReason.text = "You Hit the Wrong Target";
                }
                GameManager.JeepCount++;

            }
            else
            if (Truck)
            {
                if (GameManager.TotalTruckTarget == 0 || !isTarget)
                {
                    GamePlay.instant.StartCoroutine("LevelFail");
                    GamePlay.instant.FailReason.text = "You Hit the Wrong Target";
                }
                GameManager.TruckCount++;

            }
            else
            if (isbike)
            {
                if (GameManager.TotalBikeToShoot == 0 || !isTarget)
                {
                    GamePlay.instant.StartCoroutine("LevelFail");
                    GamePlay.instant.FailReason.text = "You Hit the Wrong Target";
                }
                GameManager.BikeCount++;

            }
            else
            if (containEnemy)
            {
            }
            else
            {
                if (GameManager.TotalCarToShoot == 0 || !isTarget)
                {
                    GamePlay.instant.StartCoroutine("LevelFail");
                    GamePlay.instant.FailReason.text = "You Hit the Wrong Target";
                }
                GameManager.CarCount++;
            }
        }
    }
}
