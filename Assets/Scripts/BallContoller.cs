using UnityEngine;

public class BallContoller : MonoBehaviour
{
    public Transform ball;
    // public GameObject currentBall;
    public Vector3 spawnPosition;
    public Transform Stumps;
    public Transform highlighter;
    public float BallSpeed = 7f;
    public float BallSwing = 2f;
    public float BallSpin = 3f;
    private Rigidbody ballrb;
    private bool taskScheduled = false;
    public float heightFactor = 0.5f;
    public float timeToTarget = 0.1f;
    public int ballCount = 0;
    public int ballType = 0;       // 0=Fast bowler     1=Spin bowler
    public int SpinBallVariation;
    public int FastBallVariation;
    // private float timer = 0f;
    // private float interval = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)){
            Invoke("AutoBall", 1.5f);
        }

        // Invoke("AutoBall", 5f);
        // if (!taskScheduled && Input.GetKeyDown(KeyCode.T))
        // {
        //     if (ballType == 0)
        //     {
        //         FastBowler();
        //         Invoke("Spawn", 5f);
        //         taskScheduled = true;
        //         if (ballCount == 6)
        //         {
        //             Debug.Log("Over Finished!");
        //             ballCount = 0;
        //             ballType = 1;
        //         }
        //     }

        //     else if (ballType == 1)
        //     {
        //         SpinBowler();
        //         Invoke("Spawn", 5f);
        //         taskScheduled = true;
        //         if (ballCount == 6)
        //         {
        //             Debug.Log("Over Finished!");
        //             ballCount = 0;
        //             ballType = 0;
        //         }
        //     }
        // }
    }

    private void AutoBall(){
        if (!taskScheduled )
        {
            if (ballType == 0)
            {
                FastBowler();
                Invoke("Spawn", 4f);
                taskScheduled = true;
                if (ballCount == 6)
                {
                    Debug.Log("Over Finished!");
                    ballCount = 0;
                    ballType = 1;
                }
            }

            else if (ballType == 1)
            {
                SpinBowler();
                Invoke("Spawn", 5f);
                taskScheduled = true;
                if (ballCount == 6)
                {
                    Debug.Log("Over Finished!");
                    ballCount = 0;
                    ballType = 0;
                }
            }
        }
    }

    public void FastBowler()
    {
        Vector3 velocity = CalculateVelocity(highlighter.position, ball.position, timeToTarget, heightFactor);
        FastBallVariation = Random.Range(0, 3);
        switch (FastBallVariation)
        {
            case 0:                // OUT - SWING
                Debug.Log("OUT-SWING");
                ballrb.useGravity = true;
                ballrb.constraints = RigidbodyConstraints.None;
                // Vector3 direcToStumps = (Stumps.position - ball.position).normalized;
                // balrb.AddFlorce(direcToStumps * BallSpeed, ForceMode.Impulse);
                ballrb.AddForce(velocity * BallSpeed * 0.87f, ForceMode.Impulse);
                ballrb.AddForce(Vector3.right * BallSwing, ForceMode.Impulse);
                break;

            case 1:                // IN - SWING
                Debug.Log("IN-SWING");
                ballrb.useGravity = true;
                ballrb.constraints = RigidbodyConstraints.None;
                // Vector3 direcToStumps = (Stumps.position - ball.position).normalized;
                // ballrb.AddForce(((Stumps.position - ball.position).normalized) * BallSpeed*1.3f, ForceMode.Impulse);
                ballrb.linearVelocity = velocity;
                ballrb.AddForce(velocity * BallSpeed * 0.52f, ForceMode.Impulse);
                ballrb.AddForce(Vector3.left * BallSwing * 1.1f, ForceMode.Impulse);
                break;

            case 2:                // FAST
                Debug.Log("FAST");
                ballrb.useGravity = true;
                ballrb.constraints = RigidbodyConstraints.None;
                // Vector3 direcToStumps = (Stumps.position - ball.position).normalized;
                // ballrb.AddForce(((Stumps.position - ball.position).normalized) * (BallSpeed*1.7f), ForceMode.Impulse);
                ballrb.AddForce(velocity * BallSpeed * 1.075f, ForceMode.Impulse);
                break;
        }
        ballCount += 1;
    }

    public void SpinBowler()
    {
        Vector3 velocity = CalculateVelocity(highlighter.position, ball.position, timeToTarget, heightFactor);
        SpinBallVariation = Random.Range(0, 2);
        switch (SpinBallVariation)
        {
            case 0:               // OFF - SPIN
                Debug.Log("OFF-SPIN");
                ballrb.useGravity = true;
                ballrb.constraints = RigidbodyConstraints.None;
                // Vector3 direcToStumps = (Stumps.position - ball.position).normalized;
                // ballrb.AddForce(((Stumps.position - ball.position).normalized) * BallSpeed, ForceMode.Impulse);
                ballrb.AddForce(velocity * BallSpeed, ForceMode.Impulse);
                ballrb.AddTorque(Vector3.right * BallSpin, ForceMode.Impulse);
                break;

            case 1:                // LEG - SPIN
                Debug.Log("LEG-SPIN");
                ballrb.useGravity = true;
                ballrb.constraints = RigidbodyConstraints.None;
                // Vector3 direcToStumps = (Stumps.position - ball.position).normalized;
                // ballrb.AddForce(((Stumps.position - ball.position).normalized) * BallSpeed, ForceMode.Impulse);
                ballrb.AddForce(velocity * BallSpeed, ForceMode.Impulse);
                ballrb.AddTorque(Vector3.left * BallSpin, ForceMode.Impulse);
                break;
        }
        ballCount += 1;
    }

    public Vector3 CalculateVelocity(Vector3 targetPosition, Vector3 startPosition, float time, float height)
    {
        // Calculate the differences in position
        Vector3 direction = targetPosition - startPosition;
        Vector3 horizontalDirection = new Vector3(direction.x, 0, direction.z);

        // Calculate horizontal speed
        float horizontalSpeed = horizontalDirection.magnitude / time;

        // Calculate vertical speed
        float verticalSpeed = (direction.y - 0.5f * Physics.gravity.y * time * time) / time;

        verticalSpeed *= height;

        // Combine horizontal and vertical speeds into velocity vector
        Vector3 velocity = horizontalDirection.normalized * horizontalSpeed;
        velocity.y = verticalSpeed;

        return velocity;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Stumps"))
        {
            Debug.Log("Stumps Hit!");
        }
    }

    public void spawnBall()
    {

        spawnPosition = ball.position;
        ballrb = ball.GetComponent<Rigidbody>();
        if (ballrb == null)
        {
            ballrb = ballrb.gameObject.AddComponent<Rigidbody>();
        }
        ballrb.useGravity = false;
        ballrb.constraints = RigidbodyConstraints.FreezePosition;
        ballrb.constraints = RigidbodyConstraints.FreezeRotation;

    }

    public void Spawn()
    {

        ballrb.useGravity = false;
        ballrb.constraints = RigidbodyConstraints.FreezePosition;
        ballrb.constraints = RigidbodyConstraints.FreezeRotation;
        ball.position = spawnPosition;
        taskScheduled = false;
    }
}