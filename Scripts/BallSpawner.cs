using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public GameObject sphere;

    [Header("1(Sağ) -1(Sol)")]
    public int direction = 1;

    [Header("1-4 arası değer")]
    public int value = 1;

    public float repeatTime = 1f;

    void Start()
    {
        InvokeRepeating("spawnAlgorithm", 0f, repeatTime);
    }

    private void spawnAlgorithm()
    {
        int randomValue = Random.Range(1, 5);

        if (value == randomValue)
        {
            GameObject Sphere = Instantiate(sphere, this.transform.position, Quaternion.identity);
            Sphere.GetComponent<Sphere>().direction = direction;
        }
    }
}
