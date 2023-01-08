using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image[] healthLevels;
    public Transform healthBarCanvas;
    public GameObject playerRef;

    public GameObject failPanel;

    public int health;

    void Start()
    {
        health = 2;
    }

    void Update()
    {
        if (health <= -1)
        {
            health = -1;
            failPanel.SetActive(true);
        }
        if (health >= 2)
        {
            health = 2;
        }

        for (int i = 0; i < healthLevels.Length; i++)
        {
            if (i > health)
            {
                healthLevels[i].enabled = false;
            }
            else
            {
                healthLevels[i].enabled = true;
            }
        }

        healthBarCanvas.LookAt(healthBarCanvas.transform.position + this.transform.rotation * Vector3.forward,
            this.transform.rotation * Vector3.up);
    }
}