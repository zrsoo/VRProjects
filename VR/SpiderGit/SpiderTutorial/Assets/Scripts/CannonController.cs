using UnityEngine;

public class CannonController : MonoBehaviour
{
    // Speed with which you can rotate the cannon left-right, up-down.
    public float rotationSpeed = 1.0f;

    // Speed at which the canonball blasts out of the cannon.
    public float blastPower = 99.0f;

    // Prefab canonball.
    public GameObject canonball;

    public Transform shotPoint;

    public Transform shotTarget;
    public float Speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Fire canonball every tick.
        TickSystem.OnTick += delegate (object sender, TickSystem.OnTickEventArgs e) {
            GameObject createdCanonball = Instantiate(canonball, shotPoint.position, shotPoint.rotation);
            createdCanonball.GetComponent<Rigidbody>().velocity = shotPoint.transform.up * blastPower;
        };
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion lookRotation = Quaternion.LookRotation(transform.position - shotTarget.position);

        float time = 0;

        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);
            time += Time.deltaTime * Speed;
        }
    }
}
