using UnityEngine;

public class RotationSelf : MonoBehaviour
{
    public Vector3 rotation = new Vector3(0, 0, 90);
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        // Set the rotation of the object to (0, 0, 90)
        transform.rotation = Quaternion.Euler(rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * velocity * Time.deltaTime);
    }
}