﻿using UnityEngine;
using System.Collections;

public class Hit_Box : AS_BulletHiter
{
	public float DamageMult = 1;
	public DamageManager damageManage;

	void Start(){
		if (damageManage == null) {
			if (this.transform.root) {
				damageManage = this.transform.root.GetComponentInChildren<DamageManager> ();
			}
		} 
	}

	public override void OnHit (RaycastHit hit, AS_Bullet bullet)
	{
		float distance = Vector3.Distance (bullet.pointShoot, hit.point);
		if (damageManage) {
			int damage = (int)((float)bullet.Damage * DamageMult);
			damageManage.ApplyDamage (damage, bullet.transform.forward * bullet.HitForce,this.gameObject, distance, Suffix);
		}
		AddAudio (hit.point);
		base.OnHit (hit, bullet);
	}
}