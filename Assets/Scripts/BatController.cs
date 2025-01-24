using UnityEngine;

public class BatController : MonoBehaviour
{
    private Rigidbody ballrb;
    public BallContoller script;
    public float heightFactor = 0.2f;
    public float timeToTarget = 0.1f;
    // public Transform FieldHighlighter;
    public Transform ball;
    public Vector3 ballPosition;
    public AnimationController scriptA;
    public float ballSpeed = 1.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballrb = GetComponent<Rigidbody>();
        int layer1 = LayerMask.NameToLayer("Ball");
        int layer2 = LayerMask.NameToLayer("Crease");

        Physics.IgnoreLayerCollision(layer1, layer2, true);
    }

    // Update is called once per frame
    void Update()
    {
        ballPosition = ball.transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check for a collision with a specific object or tag
        Vector3 FieldPosition = scriptA.FieldPosition;
        if (collision.gameObject.CompareTag("Bat"))
        {
            Vector3 velocity = script.CalculateVelocity(FieldPosition, ballPosition, timeToTarget, heightFactor);
            ballrb.useGravity = true;
            ballrb.constraints = RigidbodyConstraints.None;
            ballrb.AddForce(velocity * ballSpeed, ForceMode.Impulse);

            Debug.Log("Wall Hit");
        }
        if (collision.gameObject.CompareTag("Crease"))
        {
            // Skip this collision
            return;
        }
    }
}
