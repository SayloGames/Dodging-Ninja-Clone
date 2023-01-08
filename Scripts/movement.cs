using UnityEngine;

public class movement : MonoBehaviour
{

    public float speed = 8f;

    private bool isJumped = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Animator>().SetBool("run", true);
            this.GetComponent<Animator>().SetBool("jump", false);
            this.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Animator>().SetBool("run", true);
            this.GetComponent<Animator>().SetBool("jump", false);
            this.transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, -270f, 0f));
        }
        else if (Input.GetKey(KeyCode.Space) && !isJumped)
        {
            this.GetComponent<Animator>().SetBool("run", false);
            this.GetComponent<Animator>().SetBool("jump", true);
            this.transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));

            if (this.transform.position.y == -0.99f)
            {
                isJumped = true;
            }
        }
        else if (!Input.anyKey)
        {
            this.GetComponent<Animator>().SetBool("run", false);
            this.GetComponent<Animator>().SetBool("jump", false);
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }

        this.transform.Translate(Vector3.down * speed / 3f * Time.deltaTime, Space.World);

        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -4f, 4f),
                     Mathf.Clamp(this.transform.position.y, -3.38f, -0.99f),
                     this.transform.position.z);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isJumped = false;
        }
    }
}
