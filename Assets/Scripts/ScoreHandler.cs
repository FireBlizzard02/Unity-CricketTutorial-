using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public BallHighlight script;
    public Button myButton1;
    public Button myButton2;
    public int buttonState;
    public int length;
    public TimingMeter Script;
    public int score = 0;
    public int wickets = 0;
    public int target = 100;
    public int ballsLeft = 36;
    public TMP_Text Runs;
    public TMP_Text Wicket;
    public TMP_Text Target;
    public TMP_Text RemainingBalls;
    private bool isDragging = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Lofted.onClick.AddListener(() => LoftedButtonClick());
        // Normal.onClick.AddListener(() => NormalButtonClick());
    }

    // Update is called once per frame
    void Update()
    {
        myButton1.onClick.AddListener(() => LoftedButtonClick());
        myButton2.onClick.AddListener(() => NormalButtonClick());

        // if (Input.GetKeyDown(KeyCode.L))
        // {
        //     Invoke("ScoreDecider", 3f);
        // }
        HandleInput();
    }
    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0)) // Touch or mouse click start
        {
            // startTouchPosition = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0) && isDragging) // Touch or mouse release
        {
            // endTouchPosition = Input.mousePosition;
            isDragging = false;
            Invoke("ScoreDecider", 3f);
        }
    }

    public void LoftedButtonClick()
    {
        buttonState = 2;
    }

    public void NormalButtonClick()
    {
        buttonState = 1;
    }

    void ScoreDecider()
    {
        int redArea = Script.redArea;
        int blueArea = Script.blueArea;
        int greenArea = Script.greenArea;
        int orangeArea = Script.orangeArea;

        switch (buttonState)
        {
            case 0:

                if (greenArea == 1)
                {
                    score += 4;
                    UpdateScoreUI();
                    target = target - 4;
                    target = Mathf.Abs(target);
                    UpdateTargetUI();
                    ballsLeft -= 1;
                    UpdateRemainingBallsUI();
                }
                if (blueArea == 1)
                {
                    score += 2;
                    UpdateScoreUI();
                    target = target - 2;
                    target = Mathf.Abs(target);
                    UpdateTargetUI();
                    ballsLeft -= 1;
                    UpdateRemainingBallsUI();
                }
                if (orangeArea == 1)
                {
                    score += 1;
                    UpdateScoreUI();
                    target = target - 1;
                    target = Mathf.Abs(target);
                    UpdateTargetUI();
                    ballsLeft -= 1;
                    UpdateRemainingBallsUI();
                }
                if (redArea == 1)
                {
                    wickets += 1;
                    UpdateWicketUI();
                    ballsLeft -= 1;
                    UpdateRemainingBallsUI();
                }
                buttonState = 0;
                break;

            case 1:
                if (greenArea == 1)
                {
                    score += 4;
                    UpdateScoreUI();
                    target = target - 4;
                    target = Mathf.Abs(target);
                    UpdateTargetUI();
                    ballsLeft -= 1;
                    UpdateRemainingBallsUI();
                }
                if (blueArea == 1)
                {
                    score += 2;
                    UpdateScoreUI();
                    target = target - 2;
                    target = Mathf.Abs(target);
                    UpdateTargetUI();
                    ballsLeft -= 1;
                    UpdateRemainingBallsUI();
                }
                if (orangeArea == 1)
                {
                    score += 1;
                    UpdateScoreUI();
                    target = target - 1;
                    target = Mathf.Abs(target);
                    UpdateTargetUI();
                    ballsLeft -= 1;
                    UpdateRemainingBallsUI();
                }
                if (redArea == 1)
                {
                    wickets += 1;
                    UpdateWicketUI();
                    ballsLeft -= 1;
                    UpdateRemainingBallsUI();
                }
                buttonState = 0;
                break;

            case 2:
                if (greenArea == 1)
                {
                    score += 6;
                    UpdateScoreUI();
                    target = target - 6;
                    target = Mathf.Abs(target);
                    UpdateTargetUI();
                    ballsLeft -= 1;
                    UpdateRemainingBallsUI();
                }
                if (blueArea == 1)
                {
                    score += 2;
                    UpdateScoreUI();
                    target = target - 2;
                    target = Mathf.Abs(target);
                    UpdateTargetUI();
                    ballsLeft -= 1;
                    UpdateRemainingBallsUI();
                }
                if (orangeArea == 1)
                {
                    score += 1;
                    UpdateScoreUI();
                    target = target - 1;
                    target = Mathf.Abs(target);
                    UpdateTargetUI();
                    ballsLeft -= 1;
                    UpdateRemainingBallsUI();
                }
                if (redArea == 1)
                {
                    wickets += 1;
                    UpdateWicketUI();
                    ballsLeft -= 1;
                    UpdateRemainingBallsUI();
                }
                buttonState = 0;
                break;

        }
    }
    public void UpdateScoreUI()
    {

        Runs.text = $"{score}";

    }

    public void UpdateWicketUI()
    {
        Wicket.text = $"{wickets}";
    }

    public void UpdateTargetUI()
    {
        Target.text = $"{target}";
    }

    public void UpdateRemainingBallsUI()
    {
        RemainingBalls.text = $"{ballsLeft}";
    }
}
