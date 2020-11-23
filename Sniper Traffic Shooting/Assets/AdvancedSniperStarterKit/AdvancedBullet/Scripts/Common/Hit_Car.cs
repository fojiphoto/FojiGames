using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CapsuleCollider))]

public class Hit_Barrel : AS_BulletHiter
{
	public float DamageMult = 3;
	public MetalBarrelOnly damageManage;

	void Start(){
		
		if (damageManage == null) {
			if (this.transform.root) {
				damageManage = this.GetComponent<MetalBarrelOnly> ();
			}
		} 
	}
	
	public override void OnHit (RaycastHit hit, AS_Bullet bullet)
	{
		float distance = Vector3.Distance (bullet.pointShoot, hit.point);

		if (damageManage) {
			int damage = (int)((float)bullet.Damage * DamageMult);
            damageManage.Health -= damage;
            damageManage.BarrelDestroy();
		}
		AddAudio (hit.point);
		base.OnHit (hit, bullet);
	}
}
