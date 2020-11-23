using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class textanim : MonoBehaviour {
    Color[] ColorsForText;
    public float xValue=0, yValue=0;
    int temp;
	// Use this for initialization
	void Start () {
    
   
        iTween.MoveBy(this.gameObject,iTween.Hash("y", yValue, "x", xValue, "time",6f,"oncomplete","onComplete"));
        
	}
	
	// Update is called once per frame
			void onComplete(){
		Destroy(gameObject);
			}
}
