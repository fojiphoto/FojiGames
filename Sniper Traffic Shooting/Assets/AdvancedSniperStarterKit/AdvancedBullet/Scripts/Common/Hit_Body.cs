using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CapsuleCollider))]

public class Hit_Body : AS_BulletHiter
{
	public float DamageMult = 1;
	public DamageManager damageManage;
	
	void Start(){
		if (damageManage == null) {
			if (this.transform.root) {
				damageManage = this.transform.GetComponentInParent<DamageManager> ();
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
            Scare();
            AddAudio(hit.point);
        base.OnHit(hit, bullet);
    }
    public void Scare()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, 15);
        foreach (Collider col in colls)
        {
            if (col.CompareTag("Enemy"))
            {
                col.GetComponentInParent<TargetAi>().Scared();
            }
        }
    }
    public void BlastKill(float damage,Vector3 velosity)
    {
        damageManage.ApplyDamage(200, velosity, this.gameObject, 150, Suffix);
}
}
