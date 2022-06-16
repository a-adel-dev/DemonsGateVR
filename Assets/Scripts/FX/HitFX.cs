using DaemonsGate.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFX : MonoBehaviour , IFX
{

    [SerializeField]
    float blinkIntensity;
    [SerializeField]
    float blinkDuration;

    float blinkTimer;

    SkinnedMeshRenderer skinnedMeshRenderer;

    public void PlayEffect()
    {
        blinkTimer = blinkDuration;
    }

    // Start is called before the first frame update
    void Start()
    {
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        blinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(blinkTimer / blinkDuration);
        float intensity = (lerp * blinkIntensity) + 1.0f;
        skinnedMeshRenderer.material.color = Color.white * intensity;
    }
}
