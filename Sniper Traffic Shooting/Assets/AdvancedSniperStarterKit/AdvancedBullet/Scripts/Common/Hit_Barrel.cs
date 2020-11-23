using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CapsuleCollider))]

public class Hit_Car : AS_BulletHiter
{
	public float DamageMult = 3;
	public MetalBarrel damageManage;

	void Start(){
		
		if (damageManage == null) {
			if (this.transform.root) {
				damageManage = this.GetComponent<MetalBarrel> ();
			}
		} 
	}
	
	public override void OnHit (RaycastHit hit, AS_Bullet bullet)
	{
		float distance = Vector3.Distance (bullet.pointShoot, hit.point);

		if (damageManage) {
			int damage = (int)((float)bullet.Damage * DamageMult);
            damageManage.Health -= damage;
            Debug.Log("Damage is " + damage);
            damageManage.BarrelDestroy();
		}
		AddAudio (hit.point);
		base.OnHit (hit, bullet);
	}
}
