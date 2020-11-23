using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatCanves : MonoBehaviour {

    Transform Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update () {
        gameObject.transform.LookAt(Player);
	}
}
