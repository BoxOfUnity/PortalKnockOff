using UnityEngine;

public class Yeeter : MonoBehaviour
{
    public bool yeeter;
    private float yeeterSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Yeetable>())
        {
            if (yeeter)
            {
                yeeterSpeed = 1000;
            }
            else
            {
                yeeterSpeed = -1000;
            }
            Vector3 v3 = other.gameObject.transform.forward.normalized * yeeterSpeed;
            other.gameObject.GetComponent<Rigidbody>().AddForce(v3);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
