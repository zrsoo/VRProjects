using UnityEngine;

public class CannonController : MonoBehaviour
{
    // Speed with which you can rotate the cannon left-right, up-down.
    public float rotationSpeed = 1.0f;

    // Speed at which the canonball blasts out of the cannon.
    public float blastPower = 9999999999.0f;

    // Prefab canonball.
    public GameObject canonball;

    public Transform shotPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Reads input from AD keys.
        float horizontalRotation = Input.GetAxis("Horizontal");

        // Reads input from WS keys.
        float verticalRotation = Input.GetAxis("Vertical");

        // Adjust rotation of cannon.
        // eulerAngles - current rotation -> Add horizontal and vertical rotation to it.
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles +
            new Vector3(verticalRotation * rotationSpeed, horizontalRotation * rotationSpeed, 0));

        // Space - shoot cannon.
        // Instantiate canonball at shotpoint position.
        // Set its velocity to *up vector of shotpoint* x blastPower.
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject createdCanonball = Instantiate(canonball, shotPoint.position, shotPoint.rotation);
            createdCanonball.GetComponent<Rigidbody>().velocity = shotPoint.transform.up * blastPower;
        }
    }
}
