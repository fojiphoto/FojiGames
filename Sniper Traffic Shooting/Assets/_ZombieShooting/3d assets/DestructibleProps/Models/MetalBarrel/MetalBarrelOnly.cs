using UnityEngine;

public class MetalBarrelOnly : MonoBehaviour {
	public GameObject[] Chunks; //parts of the broken object.
	[Range(0.0F, 30.0F)]
	public float BurningTime = 3;
	[Range(1,500)]
	public int Health = 100;
	public float ExplosionForce = 200; //force added to every chunk of the broken object.
	public float ChunksRotation = 20; //rotation force added to every chunk when it explodes.
	public bool BreakByClick = true;
	public bool DestroyAfterTime = true; //if true, then chunks will be destroyed after time.
	public float time = 5; //time before chunks will be destroyed from the scene.
	public GameObject ExpLight;
	public GameObject FireFX;
	public bool AutoDestroy = true; //if true, then object will be automatically break after after "AutoDestTime" since game start.
	public float AutoDestTime = 2; //Auto destruction time (counts from game start).
    float delay=3f;
    Transform explosive;
    void Start () {
        explosive = transform;

        if (AutoDestroy)
        {
            Invoke("Crushing", AutoDestTime);
        }   
        FireFX.SetActive(false);
		if(GetComponent<AudioSource>()){
			GetComponent<AudioSource>().pitch = Random.Range (1, 1.3f);
		}
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
            if (Health >= 0)
            {
                delay = 3f;
            }
            if(Health <= 0)
            {
                FireFX.SetActive(true);
                Invoke("Crushing", BurningTime);
            }
    }
	void Crushing(){
		FireFX.SetActive(false);
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
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
        foreach (GameObject chunk in Chunks){
			chunk.SetActive(true);
			chunk.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * -ExplosionForce);
			chunk.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.forward * -ChunksRotation*Random.Range(-5f, 5f));
			chunk.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.right * -ChunksRotation*Random.Range(-5f, 5f));
		}
		if(DestroyAfterTime){
			Invoke("DestructObject", time);
		}
	}
	public void DestructObject(){
		Destroy(gameObject);
	}
}
