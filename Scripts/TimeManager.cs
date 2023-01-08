using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI timeText;

    public int time_seconds;
    private int minute;

    public bool time_over;
    private bool taking_away;

    public GameObject winPanel;

    void Update()
    {
        if (!taking_away && time_seconds > 0)
        {
            StartCoroutine(timeTicker());
        }
        if (time_seconds <= 0)
        {
            time_over = true;
            winPanel.SetActive(true);
        }
    }

    IEnumerator timeTicker()
    {
        taking_away = true;
        yield return new WaitForSeconds(1);
        time_seconds -= 1;
        if (time_seconds < 10)
        {
            timeText.text = "00:0" + time_seconds;
        }
        else
        {
            minute = (time_seconds - (time_seconds % 60)) / 60;
            if (minute < 10)
            {
                if ((time_seconds % 60) < 10)
                {
                    timeText.text = "0" + minute + ":" + "0" + (time_seconds % 60);
                }
                else
                {
                    timeText.text = "0" + minute + ":" + (time_seconds % 60);
                }
            }
            else
            {
                timeText.text = minute + ":" + (time_seconds % 60);
            }
        }
        taking_away = false;
    }
}
