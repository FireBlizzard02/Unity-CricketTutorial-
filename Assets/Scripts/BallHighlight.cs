using UnityEngine;

public class BallHighlight : MonoBehaviour
{
    public GameObject ball;             // Reference to the ball
    public GameObject impactMarker;     // Marker prefab to show impact position
    public LayerMask groundLayer;       // Layer for detecting the ground
    public float predictionFrequency = 0.2f; // Update frequency for impact prediction

    private Vector3 predictedImpactPoint;
    private Rigidbody ballRigidbody;
    public Transform highlighter;
    private MeshRenderer meshRenderer;
    public int ballLine;
    public int Length;

    // private float timer = 0f;
    // private float interval = 4.5f;

    void Start()
    {
        meshRenderer = impactMarker.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;

        Vector3 newPosition = highlighter.transform.position;
        highlighterPosition();
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.T))
        // {

        //     Invoke("highlighterPosition", 2f);

        // }
        // Invoke("highlighterPosition", 2f);

        if (Input.GetKeyDown(KeyCode.L))
        {   
            Invoke("highlighterPosition", 4f);
        }

        // timer += Time.deltaTime;
        // if (timer >= interval){
        //     highlighterPosition();
        //     timer = 0f;
        // }

    }

    // void UpdateImpactPrediction()
    // {
    //     // Ensure the ball is moving
    //     if (ballRigidbody.linearVelocity.sqrMagnitude > 0.1f)
    //     {
    //         // Predict the ball's impact point
    //         if (Physics.Raycast(ball.transform.position, ballRigidbody.linearVelocity.normalized, out RaycastHit hit, Mathf.Infinity, groundLayer))
    //         {
    //             predictedImpactPoint = hit.point;

    //             // Update and show the marker
    //             impactMarker.transform.position = new Vector3(predictedImpactPoint.x, hit.point.y + 0.01f, predictedImpactPoint.z); // Slightly above ground
    //             impactMarker.SetActive(true);
    //         }
    //     }
    //     else
    //     {
    //         // Hide the marker if the ball stops moving
    //         impactMarker.SetActive(false);
    //     }
    //     Debug.DrawRay(ball.transform.position, ballRigidbody.linearVelocity.normalized * 10, Color.red, 0.5f);
    // }

    // public int BallLine(){
    //     int Line  = Random.Range(0, 3);
    //     return Line;
    // }
    // public int BallLength(){
    //     int Length = Random.Range(0,5);
    //     return Length;
    // }
    public void highlighterPosition()
    {
        ballLine = Random.Range(0, 3);
        if (ballLine == 0)
        {
            Debug.Log("Outside - Off");
        }
        if (ballLine == 1)
        {
            Debug.Log("At The Stumps");
        }
        if (ballLine == 2)
        {
            Debug.Log("Down The Leg");
        }
        Vector3 newPosition = highlighter.transform.position;
        Length = Random.Range(0, 5);
        if (Length == 0)
        {
            Debug.Log("Short Ball");
        }
        if (Length == 1)
        {
            Debug.Log("Full Length");
        }
        if (Length == 2)
        {
            Debug.Log("Good Length");
        }
        if (Length == 3)
        {
            Debug.Log("Yorker");
        }
        if (Length == 4)
        {
            Debug.Log("Full Toss");
        }


        if (ballLine == 0)
        {      //0.4
            if (Length == 0)
            {                     //SHORT BALL
                newPosition = new Vector3(1.2f, 1.169f, 0.4f);
                highlighter.transform.position = newPosition;
            }
            if (Length == 1)
            {                      // FULL LENGTH
                newPosition = new Vector3(2.5f, 1.169f, 0.4f);
                highlighter.transform.position = newPosition;
            }
            if (Length == 2)
            {                       // GOOD LENGTH
                newPosition = new Vector3(1.9f, 1.169f, 0.4f);
                highlighter.transform.position = newPosition;
            }
            if (Length == 3)
            {                       // YORKER
                newPosition = new Vector3(2.9f, 1.169f, 0.4f);
                highlighter.transform.position = newPosition;
            }
            if (Length == 4)
            {                       //FULL TOSS
                newPosition = new Vector3(3.1f, 1.169f, 0.4f);
                highlighter.transform.position = newPosition;
            }
        }
        if (ballLine == 1)
        {     //0.06
            if (Length == 0)
            {                      // SHORT BALL
                newPosition = new Vector3(1.2f, 1.169f, 0.06f);
                highlighter.transform.position = newPosition;
            }
            if (Length == 1)
            {                      // FULL LENGTH
                newPosition = new Vector3(2.5f, 1.169f, 0.06f);
                highlighter.transform.position = newPosition;
            }
            if (Length == 2)
            {                       // GOOD LENGTH
                newPosition = new Vector3(1.9f, 1.169f, 0.06f);
                highlighter.transform.position = newPosition;
            }
            if (Length == 3)
            {                       //YORKER
                newPosition = new Vector3(2.9f, 1.169f, 0.06f);
                highlighter.transform.position = newPosition;
            }
            if (Length == 4)
            {                       //FULL TOSS
                newPosition = new Vector3(3.1f, 1.169f, 0.06f);
                highlighter.transform.position = newPosition;
            }
        }
        if (ballLine == 2)
        {      //-0.05
            if (Length == 0)
            {                       // SHORT BALL
                newPosition = new Vector3(1.2f, 1.169f, -0.05f);
                highlighter.transform.position = newPosition;
            }
            if (Length == 1)
            {                        // FULL LENGTH
                newPosition = new Vector3(2.5f, 1.169f, -0.05f);
                highlighter.transform.position = newPosition;
            }
            if (Length == 2)
            {                         // GOOD LENGTH
                newPosition = new Vector3(1.9f, 1.169f, -0.05f);
                highlighter.transform.position = newPosition;
            }
            if (Length == 3)
            {                         // YORKER
                newPosition = new Vector3(2.9f, 1.169f, -0.05f);
                highlighter.transform.position = newPosition;
            }
            if (Length == 4)
            {                          // FULL TOSS
                newPosition = new Vector3(3.1f, 1.169f, -0.05f);
                highlighter.transform.position = newPosition;
            }
        }
        meshRenderer.enabled = true;
    }


    float GetRandomFloat(float min, float max)
    {
        float randomValue = Random.Range(min, max); // Random float between min and max
        return Mathf.Round(randomValue * 1000f) / 1000f; // Round to 3 decimal places
    }

}
