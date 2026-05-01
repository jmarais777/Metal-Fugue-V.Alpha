using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;

public class LightFlicker : MonoBehaviour
{
    //Light Intensity Modulator
    //Title: Unity 2D Flickering Light (CODE PROVIDED)
    //Author: Steven Song
    //Date: 15/04/2026
    //Availiability: https://www.youtube.com/watch?v=zfrpRYZfO1w

    public Light2D Light2D;
    public float MinIntensity;
    public float MaxIntensity;
    public float MinFlickerTime;
    public float MaxFlickerTime;
    float flickerTimer = 0f;
    float currentFlickerTime;

    private void Start()
    {
        currentFlickerTime = Random.Range(MinFlickerTime, MaxFlickerTime);
    }
    void Update()
    {
        //Trigger for intensity modulation
        flickerTimer += Time.deltaTime;
        if (flickerTimer >= currentFlickerTime)
        {
            IntensityRandomizer();
            FlickerRateRandomizer();

            flickerTimer = 0.2f;
        }
    }

    void IntensityRandomizer()
    {
        //Defining equation for modulation of the light intensity
        Light2D.intensity = Random.Range(MinIntensity, MaxIntensity);
    }

    void FlickerRateRandomizer()
    {
        //Defining equation for modulation of the time per each flicker
       currentFlickerTime = Random.Range(MinFlickerTime, MaxFlickerTime);
    }
}
