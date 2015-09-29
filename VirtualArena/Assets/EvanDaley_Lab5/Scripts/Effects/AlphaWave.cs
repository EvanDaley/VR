using UnityEngine;
using System.Collections;

public class AlphaWave : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float StartDelay, FadeDelay;
    public float ColorTime, ColorFadeTime;

    public bool grow = true;

    float alpha;
    
    int alphaID;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        alphaID = Shader.PropertyToID("_Alpha");

        alpha = 0;

        //InvokeRepeating("RepeatingToggle", 1, .2F);
    }

    void RepeatingToggle()
    {
        ToggleGrow();
    }

    void ToggleGrow()
    {
        grow = !grow;
    }

    void Update()
    {
        if (grow)
        {
            alpha = Mathf.Lerp(alpha, 1, Time.deltaTime * ColorTime);
            meshRenderer.material.SetFloat(alphaID, alpha);
        }
        else
        {
            alpha = Mathf.Lerp(alpha, 0, Time.deltaTime * ColorFadeTime);
            meshRenderer.material.SetFloat(alphaID, alpha);
        }
    }
}
