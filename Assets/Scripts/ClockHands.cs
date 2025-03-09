using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHands : MonoBehaviour
{
    public Transform hourHandPivot;   // Hour hand's pivot
    public Transform minuteHandPivot; // Minute hand's pivot
    public Transform secondHandPivot; // Second hand's pivot 
    void Start()
    {
        // Set the initial time
        SetClockHandsToPST();
    }

    void Update()
    {
        // Update clock hands
        UpdateClockHands();
    }

    private void SetClockHandsToPST()
    {
        DateTime currentTime = DateTime.UtcNow.AddHours(-8);

        float hourRotation = (currentTime.Hour % 12) * 30f + currentTime.Minute * 0.5f;
        hourHandPivot.localRotation = Quaternion.Euler(0, 0, -hourRotation);

        float minuteRotation = currentTime.Minute * 6f + currentTime.Second * 0.1f;
        minuteHandPivot.localRotation = Quaternion.Euler(0, 0, -minuteRotation);

        float secondRotation = currentTime.Second * 6f; 
        secondHandPivot.localRotation = Quaternion.Euler(0, 0, -secondRotation);
    }

    private void UpdateClockHands()
    {
        DateTime currentTime = DateTime.UtcNow.AddHours(-8); 

        float hourRotation = (currentTime.Hour % 12) * 30f + currentTime.Minute * 0.5f;
        hourHandPivot.localRotation = Quaternion.Euler(0, 0, -hourRotation);

        float minuteRotation = currentTime.Minute * 6f + currentTime.Second * 0.1f;
        minuteHandPivot.localRotation = Quaternion.Euler(0, 0, -minuteRotation);

        float secondRotation = currentTime.Second * 6f;
        secondHandPivot.localRotation = Quaternion.Euler(0, 0, -secondRotation);
    }
}