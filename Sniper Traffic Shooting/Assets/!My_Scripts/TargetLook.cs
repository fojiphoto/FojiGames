using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLook : MonoBehaviour {

    Transform Player;
    public bool Arrow;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Start()
    {
        if (Arrow)
            iTween.MoveBy(this.gameObject, iTween.Hash("y", 3, "time", 0.5f, "islocal", true,"easetype","linear","oncomplete","Again"));
    }
     void Again()
    {
        iTween.MoveBy(this.gameObject, iTween.Hash("y", -3,"time", 0.5f, "islocal", true,"easetype", "linear", "oncomplete", "Start"));
    }
    private void Update()
    {
        Vector3 targetPostition = new Vector3(Player.position.x,
                                        this.transform.position.y,
                                        Player.position.z);
        this.transform.LookAt(targetPostition);
    }
}
