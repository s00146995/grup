using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{

    #region Variables
    public float _dayLength = 13f;
    public float dayLength
    {
        get
        {
            return _dayLength;
        }
    }

    [Range(0f, 1f)]
    public float timeOfDay;
    public int dayCount = 1;
    public float _timeScale = 100f;
    public bool pause = false;
    public Text clockText;
    public Text dayText;

    public Transform dailyRotation;
    public Light sun;
    public float intensity;
    public float sunBaseIntensity = 1f;
    public float sunVariation = 1.5f;
    public Gradient sunColor;

    #endregion



    public void Update()
    {
        if (!pause)
        {
            UpdateTimeScale();
            UpdateTime();
            UpdateClock();
        }
        SunRotation();
        SunIntensity();
        AdjustSunColor();
    }

    public void Start()
    {
        timeOfDay = 0.3333f;
    }

    private void UpdateTimeScale()
    {
        _timeScale = 24 / (_dayLength / 30);
    }

    public void UpdateTime()
    {
        timeOfDay += Time.deltaTime * _timeScale / 86400; // Seconds in a day

        if(timeOfDay > 1) // New Day start
        {
            dayCount ++;
            timeOfDay -= 1;
        }
    }

    private void UpdateClock() // Creates clock which follows the sun position in real time
    {
        float time = timeOfDay;
        float hour = Mathf.FloorToInt(time * 24);
        float minute = Mathf.FloorToInt(((time * 24) - hour) * 60);

        string hourString;
        string minuteString;

        if (hour < 10)
            hourString = "0" + hour.ToString();
        else
            hourString = hour.ToString();

        if (minute < 10)
            minuteString = "0" + minute.ToString();
        else
            minuteString = minute.ToString();

        clockText.text = "Time : " + hourString + " : " + minuteString;
        dayText.text = "Day : " + dayCount;
    }

    public void SunRotation()
    {
        float sunAngle = timeOfDay * 360f;
        dailyRotation.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, sunAngle));
    }

    public void SunIntensity()
    {
        intensity = Vector3.Dot(sun.transform.forward, Vector3.down);
        intensity = Mathf.Clamp01(intensity);

        sun.intensity = intensity * sunVariation * sunBaseIntensity;
    }

    public void AdjustSunColor()
    {
        sun.color = sunColor.Evaluate(intensity);
    }

}
