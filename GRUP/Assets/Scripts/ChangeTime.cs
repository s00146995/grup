using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTime : MonoBehaviour
{
    public DayNightCycle selectedTime;
    public float currentTime;

    public void SetToMorning()
    {

        if (selectedTime.timeOfDay >= 0.333f) // While the time is after morning
        {
            selectedTime.dayCount++; // Add day count
        }

        selectedTime.timeOfDay = 0.333f; // Set time
    }

    public void SetToNoon()
    {

        if (selectedTime.timeOfDay >= 0.5f)
        {
            selectedTime.dayCount++;
        }

        selectedTime.timeOfDay = 0.5f;
    }

    public void SetToEvening()
    {

        if (selectedTime.timeOfDay >= 0.75f)
        {
            selectedTime.dayCount++;
        }

        selectedTime.timeOfDay = 0.75f;
    }

    public void SetToMidnight()
    {      
        selectedTime.timeOfDay = 1f;
    }
}
