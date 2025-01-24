using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public Animator animator;     // Reference to the Animator component
    public string PullCharacter; // Name of the animation trigger or state
    public string SweepCharacter;
    public string CoverDriveCharacter;
    public string StraightDriveCharacter;
    public string LegGlanceCharacter;
    public float delay = 1.0f;   // Delay in seconds
    public BallHighlight scriptA;
    public BallContoller scriptB;
    // public Transform FieldHighlighter;
    public Vector3 FieldPosition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            // StartCoroutine(PullShot());
            animationSelector();
        }
    }

    void animationSelector()
    {
        // FieldPosition = new Vector3(0f,0f,0f);
        int ballLength = scriptA.Length;
        int ballLine = scriptA.ballLine;
        int spinBall = scriptB.SpinBallVariation;
        int fastBall = scriptB.FastBallVariation;

        switch (ballLine)
        {
            case 0:                   //  Outside OFF

                //Short

                if (ballLength == 0 && spinBall == 0)
                {              //Off Spin
                    FieldPosition = new Vector3(-3.0f, 0f, -7f);
                    StartCoroutine(PullShot());
                }
                if (ballLength == 0 && spinBall == 1)
                {              //Leg Spin
                    FieldPosition = new Vector3(0f, 0f, 8f);
                    StartCoroutine(CoverDrive());                      // CUT SHOT
                }
                if (ballLength == 0 && fastBall == 0)
                {              //Out Swing
                    FieldPosition = new Vector3(0f, 0f, 8f);
                    StartCoroutine(CoverDrive());                      // CUT SHOT
                }
                if (ballLength == 0 && fastBall == 1)
                {              //In Swing
                    FieldPosition = new Vector3(-3.0f, 0f, -7f);
                    StartCoroutine(PullShot());
                }
                if (ballLength == 0 && fastBall == 2)
                {              //Fast
                    FieldPosition = new Vector3(0f, 0f, 8f);
                    StartCoroutine(CoverDrive());                      // CUT SHOT
                }

                // Full Length

                if (ballLength == 1 && spinBall == 0)
                {              // Off Spin
                    FieldPosition = new Vector3(-5f, 0f, 5f);
                    StartCoroutine(CoverDrive());
                }
                if (ballLength == 1 && spinBall == 1)
                {              //Leg Spin
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 1 && fastBall == 0)
                {              //Out Swing
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 1 && fastBall == 1)
                {              //In Swing
                    FieldPosition = new Vector3(-5f, 0f, 5f);
                    StartCoroutine(CoverDrive());
                }
                if (ballLength == 1 && fastBall == 2)
                {              //Fast
                    FieldPosition = new Vector3(-5f, 0f, 5f);
                    StartCoroutine(CoverDrive());
                }

                // Good Length

                if (ballLength == 2 && spinBall == 0)
                {              //Off Spin
                    FieldPosition = new Vector3(-5f, 0f, 5f);
                    StartCoroutine(CoverDrive());
                }
                if (ballLength == 2 && spinBall == 1)
                {              //Leg Spin
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 2 && fastBall == 0)
                {              //Out Swing
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 2 && fastBall == 1)
                {              //In Swing
                    FieldPosition = new Vector3(-5f, 0f, 5f);
                    StartCoroutine(CoverDrive());
                }
                if (ballLength == 2 && fastBall == 2)
                {              //Fast
                    FieldPosition = new Vector3(-5f, 0f, 5f);
                    StartCoroutine(CoverDrive());
                }

                //Yorker

                if (ballLength == 3 && spinBall == 0)
                {              //Off Spin
                    FieldPosition = new Vector3(-5f, 0f, 5f);
                    StartCoroutine(CoverDrive());
                }
                if (ballLength == 3 && spinBall == 1)
                {              //Leg Spin
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 3 && fastBall == 0)
                {              //Out Swing
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 3 && fastBall == 1)
                {              //In Swing
                    FieldPosition = new Vector3(-5f, 0f, 5f);
                    StartCoroutine(CoverDrive());
                }
                if (ballLength == 3 && fastBall == 2)
                {              //Fast
                    FieldPosition = new Vector3(-5f, 0f, 5f);
                    StartCoroutine(CoverDrive());
                }

                // Full Toss

                if (ballLength == 4 && spinBall == 0)
                {              //Off Spin
                    FieldPosition = new Vector3(-3.0f, 0f, -7f);
                    StartCoroutine(PullShot());
                }
                if (ballLength == 4 && spinBall == 1)
                {              // Leg Spin
                    FieldPosition = new Vector3(-3.0f, 0f, -7f);
                    StartCoroutine(PullShot());
                }
                if (ballLength == 4 && fastBall == 0)
                {              //Out Swing
                    FieldPosition = new Vector3(-3.0f, 0f, -7f);
                    StartCoroutine(PullShot());
                }
                if (ballLength == 4 && fastBall == 1)
                {              //In Swing
                    FieldPosition = new Vector3(-3.0f, 0f, -7f);
                    StartCoroutine(PullShot());
                }
                if (ballLength == 4 && fastBall == 2)
                {              //Fast
                    FieldPosition = new Vector3(-3.0f, 0f, -7f);
                    StartCoroutine(PullShot());
                }
                break;
            case 1:                   //  At the Stumps
                //Short

                if (ballLength == 0 && spinBall == 0)
                {              //Off Spin
                    FieldPosition = new Vector3(5f, 0f, -6f);
                    StartCoroutine(SweepShot());
                }
                if (ballLength == 0 && spinBall == 1)
                {              //Leg Spin
                    FieldPosition = new Vector3(0f, 0f, 8f);
                    StartCoroutine(PullShot());                              //   CUT SHOT
                }
                if (ballLength == 0 && fastBall == 0)
                {              //Out Swing
                    FieldPosition = new Vector3(0f, 0f, 8f);
                    StartCoroutine(PullShot());                                  // CUT SHOT
                }
                if (ballLength == 0 && fastBall == 1)
                {              //In Swing
                    FieldPosition = new Vector3(5f, 0f, -6f);
                    StartCoroutine(SweepShot());
                }
                if (ballLength == 0 && fastBall == 2)
                {              //Fast
                    FieldPosition = new Vector3(-3.0f, 0f, -7f);
                    StartCoroutine(PullShot());
                }

                // Full Length

                if (ballLength == 1 && spinBall == 0)
                {              // Off Spin
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 1 && spinBall == 1)
                {              //Leg Spin
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 1 && fastBall == 0)
                {              //Out Swing
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 1 && fastBall == 1)
                {              //In Swing
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 1 && fastBall == 2)
                {              //Fast
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }

                // Good Length

                if (ballLength == 2 && spinBall == 0)
                {              //Off Spin
                    FieldPosition = new Vector3(7f, 0f, -4f);
                    StartCoroutine(LegGlance());
                }
                if (ballLength == 2 && spinBall == 1)
                {              //Leg Spin
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 2 && fastBall == 0)
                {              //Out Swing
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 2 && fastBall == 1)
                {              //In Swing
                    FieldPosition = new Vector3(7f, 0f, -4f);
                    StartCoroutine(LegGlance());
                }
                if (ballLength == 2 && fastBall == 2)
                {              //Fast
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }

                //Yorker

                if (ballLength == 3 && spinBall == 0)
                {              //Off Spin
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 3 && spinBall == 1)
                {              //Leg Spin
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 3 && fastBall == 0)
                {              //Out Swing
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 3 && fastBall == 1)
                {              //In Swing
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 3 && fastBall == 2)
                {              //Fast
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }

                // Full Toss

                if (ballLength == 4 && spinBall == 0)
                {              //Off Spin
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 4 && spinBall == 1)
                {              // Leg Spin
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 4 && fastBall == 0)
                {              //Out Swing
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 4 && fastBall == 1)
                {              //In Swing
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                if (ballLength == 4 && fastBall == 2)
                {              //Fast
                    FieldPosition = new Vector3(-7f, 0f, 0.4f);
                    StartCoroutine(StraightDrive());
                }
                break;

            case 2:                   //  Down the Leg

                // Short 

                if (ballLength == 0 && spinBall == 0)
                {              //Short and Off Spin
                    FieldPosition = new Vector3(5f, 0f, -6f);
                    StartCoroutine(SweepShot());
                }
                if (ballLength == 0 && spinBall == 1)
                {              //Short and Leg Spin
                    FieldPosition = new Vector3(5f, 0f, -6f);
                    StartCoroutine(SweepShot());
                }
                if (ballLength == 0 && fastBall == 0)
                {              //Short and Out Swing
                    FieldPosition = new Vector3(5f, 0f, -6f);
                    StartCoroutine(SweepShot());
                }
                if (ballLength == 0 && fastBall == 1)
                {              //Short and In Swing
                    FieldPosition = new Vector3(5f, 0f, -6f);
                    StartCoroutine(SweepShot());
                }
                if (ballLength == 0 && fastBall == 2)
                {              //Short and Fast
                    FieldPosition = new Vector3(-3.0f, 0f, -7f);
                    StartCoroutine(PullShot());
                }
                if (ballLength == 1)       // Full Length
                {
                    FieldPosition = new Vector3(7f, 0f, -4f);
                    StartCoroutine(LegGlance());
                }
                if (ballLength == 2)          // Good Length
                {
                    FieldPosition = new Vector3(7f, 0f, -4f);
                    StartCoroutine(LegGlance());
                }
                if (ballLength == 3)          //  Yorker
                {
                    FieldPosition = new Vector3(7f, 0f, -4f);
                    StartCoroutine(LegGlance());
                }
                if (ballLength == 4)          // Full Toss
                {
                    FieldPosition = new Vector3(7f, 0f, -4f);
                    StartCoroutine(LegGlance());
                }
                break;
        }
    }

    private IEnumerator PullShot()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Trigger the animation
        animator.Play(PullCharacter);
    }

    private IEnumerator SweepShot()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Trigger the animation
        animator.Play(SweepCharacter);
    }

    private IEnumerator CoverDrive()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Trigger the animation
        animator.Play(CoverDriveCharacter);
    }

    private IEnumerator StraightDrive()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Trigger the animation
        animator.Play(StraightDriveCharacter);
    }

    private IEnumerator LegGlance()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Trigger the animation
        animator.Play(LegGlanceCharacter);
    }
}
