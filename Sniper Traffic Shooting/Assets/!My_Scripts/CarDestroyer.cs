using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroyer : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (!GameManager.gameover)
        {
            if (collision.gameObject.GetComponent<MetalBarrel>().isTarget)
            {
                if (!collision.gameObject.GetComponent<MetalBarrel>().killall && !collision.gameObject.GetComponent<MetalBarrel>().containEnemy)
                {
                    
                        GamePlay.instant.StartCoroutine("LevelFail", 2f);
                        GamePlay.instant.FailReason.text = "Target Escaped";
                        GameManager.gameover = true;
                }
            }
            if (collision.gameObject.GetComponentInChildren<TargetAi>())
                {
               
                    GamePlay.instant.StartCoroutine("LevelFail", 2f);
                    GamePlay.instant.FailReason.text = "Target Escaped";
                    GameManager.gameover = true;
            }
            if (collision.gameObject.GetComponent<Hit_Body>())
            {
               
                    GamePlay.instant.StartCoroutine("LevelFail", 2f);
                    GamePlay.instant.FailReason.text = "Target Escaped";
                    GameManager.gameover = true;
            }
        }
        Destroy(collision.gameObject);
      
    }
}

 
