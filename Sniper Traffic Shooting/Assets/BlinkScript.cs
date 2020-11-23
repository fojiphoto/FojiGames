using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkScript : MonoBehaviour {

   public Renderer renderers;
   public Material mat;
        private void Start()
    {
        renderers = GetComponent<Renderer>();
    }
    void Update()
    {
        if (mat.GetColor("_EmissionColor") != new Color32(1, 0, 0, 0)) 
        {
            float emission = Mathf.PingPong(Time.time, 1.0f);
            Color baseColor = Color.red; //Replace this with whatever you want for your base color at emission level '1'

            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

            mat.SetColor("_EmissionColor", finalColor);
        }
        else if (mat.GetColor("_EmissionColor") != new Color32(0, 0, 0, 0))
        {
            float emission = Mathf.PingPong(Time.time, 1.0f);
            Color baseColor = Color.black; //Replace this with whatever you want for your base color at emission level '1'

            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

            mat.SetColor("_EmissionColor", finalColor);
        }
    }
}
