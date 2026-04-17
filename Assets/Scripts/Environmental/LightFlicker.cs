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
    public int FramesPerFlicker;
    public float MinValue;
    public float MaxValue;
    int frames = 0;
  
    void Update()
    {
        //Trigger for intensity modulation
        frames++;
        if (frames % FramesPerFlicker == 0)
        {
            IntensityRandomizer();
        }
    }

    void IntensityRandomizer()
    {
        //Creating an instance of the Random class
        System.Random randomize = new System.Random();

        //Defining equation for modulation of the light intensity
        float randomValue = (float)(randomize.NextDouble() * (MaxValue - MinValue) + MinValue);
        Light2D.intensity = randomValue;
    }
}
