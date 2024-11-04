using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(Light2D))]
public class worldLight : MonoBehaviour
{
    public float duration = 1f; //scale 24h = 1s
    [SerializeField] private Gradient gradient;
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] TextMeshProUGUI Days;
    private Light2D sun_light;
    private float timeStart;
    private float dayPass = 0;

    public void Awake()
    {
        sun_light = GetComponent<Light2D>();
        timeStart = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        // Calculate time in-game
        var realElapsedTime = Time.time - timeStart;
        var timeOfDay = realElapsedTime % duration;

        // count day if a full day has passed
        if (timeOfDay < realElapsedTime - (dayPass * duration))
        {
            dayPass++;
        }

        var percentage = Mathf.PingPong(timeOfDay / duration, 1);
        // Set light color based on gradient
        sun_light.color = gradient.Evaluate(percentage);

        // Display formatted time of day
        var hours = Mathf.FloorToInt((timeOfDay / duration) * 24);
        var minutes = Mathf.FloorToInt(((timeOfDay / duration) * 1440) % 60);
        Days.text = $"Day: {dayPass}";
        time.text = $"{hours:00}:{minutes:00}";
    }
}
