using UnityEngine;

public class DayNightSwitch : MonoBehaviour
{
    public GameObject dayMap;  // Assign the Day version of the map
    public GameObject nightMap; // Assign the Night version of the map
    public Light directionalLight; // Assign the main directional light

    private bool isNight = false;

    void Start()
    {
        // Start with the day map active
        SetDayMode();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) // Press 'T' to switch
        {
            isNight = !isNight;
            SwitchMode();
        }
    }

    void SwitchMode()
    {
        if (isNight)
            SetNightMode();
        else
            SetDayMode();
    }

    void SetDayMode()
    {
        dayMap.SetActive(true);
        nightMap.SetActive(false);
        if (directionalLight != null)
            directionalLight.intensity = 1.0f; // Bright sunlight
    }

    void SetNightMode()
    {
        dayMap.SetActive(false);
        nightMap.SetActive(true);
        if (directionalLight != null)
            directionalLight.intensity = 0.3f; // Dim moonlight
    }
}
