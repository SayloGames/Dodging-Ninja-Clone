using UnityEngine;

public class Sphere : MonoBehaviour
{

    [Header("1(Sağ) -1(Sol)")]
    public int direction = 1;

    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    void Update()
    {
        this.transform.Translate(direction * Vector3.right * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.GetChild(2).GetComponent<HealthBar>().health -= 1;
            Destroy(this.gameObject);
        }
    }
}
