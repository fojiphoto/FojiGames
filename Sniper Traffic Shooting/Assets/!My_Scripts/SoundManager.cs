using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	
    public AudioClip ButtonClick, MainMenuSound,GamePlaySound;

    public static SoundManager Instant;
    AudioSource AS;
	void Start () {

        Instant = this;
		DontDestroyOnLoad (this.gameObject);
        AS = GetComponent<AudioSource>();
        AS.clip = MainMenuSound;
        AS.Play();
	}

    public void ButtonClicked() 
    {
        AS.PlayOneShot(ButtonClick,1);
    }

    public void GamePlaySoundPlay() 
    {
        AS.Stop();
        AS.clip = GamePlaySound;
        AS.Play();
    }

	

}
