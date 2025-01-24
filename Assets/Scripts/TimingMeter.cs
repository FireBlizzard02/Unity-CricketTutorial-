using UnityEngine;

public class TimingMeter : MonoBehaviour
{
    public RectTransform movingBar;  //  moving bar
    public RectTransform meter;      // meter (background)
    public RectTransform RedZone;     //target zone 
    public RectTransform RedZone1;
    public RectTransform BlueZone;
    public RectTransform BlueZone1;
    public RectTransform OrangeZone;
    public RectTransform OrangeZone1;
    public RectTransform GreenZone;
    public float speed = 50f;        // Speed of the bar 
    private bool movingUp = true;
    private bool isStopped = false;
    // private float timer = 0f;
    // private float interval = 4.5f;

    public int redArea;
    public int orangeArea;
    public int blueArea;
    public int greenArea;
    [SerializeField] public BallHighlight script;
    void Start()
    {

        // int Line = script.ballLine; // Call the function to get the value
        // Debug.Log("The Line is: " + Line);

        // int ballLength = script.Length;
        // Debug.Log($"The Length is:{ballLength}");

        MeterSelection();

    }

    void Update()
    {

        // if (Input.GetKeyDown(KeyCode.T))
        // {

        //     Invoke("MeterSelection", 3f);

        // }
        // Invoke("MeterSelection", 3f);

        if (Input.GetKeyDown(KeyCode.L))
        {
            // timer += Time.deltaTime;
            // if (timer >= interval)
            // {
            //     MeterSelection();
            //     timer = 0f;
            // }
            Invoke("MeterSelection", 4f);
        }

        // timer += Time.deltaTime;
        // if (timer >= interval){
        //     MeterSelection();
        //     timer = 0f;
        // }



        if (isStopped || movingBar == null || meter == null) return;

        // boundaries of the meter
        float meterBottom = meter.rect.yMin + meter.anchoredPosition.y;
        float meterTop = meter.rect.yMax + meter.anchoredPosition.y;

        // Move the bar
        float barY = movingBar.anchoredPosition.y;
        if (movingUp)
        {
            barY += speed * Time.deltaTime;
            if (barY > meterTop)
            {
                barY = meterTop;
                movingUp = false;
            }
        }
        else
        {
            barY -= speed * Time.deltaTime;
            if (barY < meterBottom)
            {
                barY = meterBottom;
                movingUp = true;
            }
        }

        // Apply the new position
        movingBar.anchoredPosition = new Vector2(movingBar.anchoredPosition.x, barY);

        if (Input.GetKeyDown(KeyCode.L))
        {
            CheckTiming();
            isStopped = true;
            Invoke("resetValues",4f);
            // Debug.Log("Meter Stopped at Y Position: " + barY);
        }

    }

    public void resetValues()
    {
        redArea = 0;
        blueArea = 0;
        orangeArea = 0;
        greenArea = 0;
    }

    public void CheckTiming()
    {
        float barY = movingBar.anchoredPosition.y;

        float RedzoneBottom = RedZone.rect.yMin + RedZone.anchoredPosition.y;
        float RedzoneTop = RedZone.rect.yMax + RedZone.anchoredPosition.y;

        float BluezoneBottom = BlueZone.rect.yMin + BlueZone.anchoredPosition.y;
        float BluezoneTop = BlueZone.rect.yMax + BlueZone.anchoredPosition.y;

        float OrangezoneBottom = OrangeZone.rect.yMin + OrangeZone.anchoredPosition.y;
        float OrangezoneTop = OrangeZone.rect.yMax + OrangeZone.anchoredPosition.y;

        float Redzone1Bottom = RedZone1.rect.yMin + RedZone1.anchoredPosition.y;
        float Redzone1Top = RedZone1.rect.yMax + RedZone1.anchoredPosition.y;

        float Bluezone1Bottom = BlueZone1.rect.yMin + BlueZone1.anchoredPosition.y;
        float Bluezone1Top = BlueZone1.rect.yMax + BlueZone1.anchoredPosition.y;

        float Orangezone1Bottom = OrangeZone1.rect.yMin + OrangeZone1.anchoredPosition.y;
        float Orangezone1Top = OrangeZone1.rect.yMax + OrangeZone1.anchoredPosition.y;

        float GreenzoneBottom = GreenZone.rect.yMin + GreenZone.anchoredPosition.y;
        float GreenzoneTop = GreenZone.rect.yMax + GreenZone.anchoredPosition.y;

        if (barY >= RedzoneBottom && barY <= RedzoneTop)
        {
            Debug.Log("Red Zone");
            redArea = 1;
        }
        if (barY >= BluezoneBottom && barY <= BluezoneTop)
        {
            Debug.Log("Blue Zone");
            blueArea = 1;
        }
        if (barY >= OrangezoneBottom && barY <= OrangezoneTop)
        {
            Debug.Log("Orange Zone");
            orangeArea = 1;
        }
        if (barY >= Redzone1Bottom && barY <= Redzone1Top)
        {
            Debug.Log("Red Zone");
            redArea = 1;
        }
        if (barY >= Bluezone1Bottom && barY <= Bluezone1Top)
        {
            Debug.Log("Blue Zone");
            blueArea = 1;
        }
        if (barY >= Orangezone1Bottom && barY <= Orangezone1Top)
        {
            Debug.Log("Orange Zone");
            orangeArea = 1;
        }
        if (barY >= GreenzoneBottom && barY <= GreenzoneTop)
        {
            Debug.Log("Perfect Shot");
            greenArea = 1;
        }
    }

    public void MeterSelection()
    {
        isStopped = false;
        int ballLength = script.Length;
        // Debug.Log(ballLength);
        if (ballLength == 0)
        {
            AdjustRedZone(43f, 35f);
            AdjustRedZone1(-208f, 35f);
            AdjustBlueZone(-42f, 57f);
            AdjustBlueZone1(-145f, 57f);
            AdjustOrangeZone(13f, 32f);
            AdjustOrangeZone1(-175f, 32f);
            AdjustGreenZone(-90f, 50f);
        }
        if (ballLength == 1)
        {
            AdjustRedZone(28f, 50f);
            AdjustRedZone1(-208f, 50f);
            AdjustBlueZone(-47f, 47f);
            AdjustBlueZone1(-130f, 47f);
            AdjustOrangeZone(-2f, 32f);
            AdjustOrangeZone1(-160f, 32f);
            AdjustGreenZone(-85f, 45f);
        }
        if (ballLength == 2)
        {
            AdjustRedZone(33f, 46f);
            AdjustRedZone1(-208f, 46f);
            AdjustBlueZone(-47f, 32f);
            AdjustBlueZone1(-115f, 32f);
            AdjustOrangeZone(-17f, 52f);
            AdjustOrangeZone1(-165f, 52f);
            AdjustGreenZone(-85f, 40f);
        }
        if (ballLength == 3)
        {
            AdjustRedZone(33f, 46f);
            AdjustRedZone1(-208f, 46f);
            AdjustBlueZone(-52f, 46f);
            AdjustBlueZone1(-125f, 46f);
            AdjustOrangeZone(-7f, 42f);
            AdjustOrangeZone1(-165f, 42f);
            AdjustGreenZone(-80f, 30f);
        }
        if (ballLength == 4)
        {
            AdjustRedZone(51f, 32f);
            AdjustRedZone1(-208f, 32f);
            AdjustBlueZone(-2f, 27f);
            AdjustBlueZone1(-150f, 27f);
            AdjustOrangeZone(23f, 30f);
            AdjustOrangeZone1(-178f, 30f);
            AdjustGreenZone(-125f, 125f);
        }
    }

    public void AdjustRedZone(float newPositionY, float newHeight)
    {

        // Adjust position
        Vector2 newPosition = RedZone.anchoredPosition;
        newPosition.y = newPositionY;
        RedZone.anchoredPosition = newPosition;

        // Adjust size
        Vector2 newSize = RedZone.sizeDelta;
        newSize.y = newHeight;
        RedZone.sizeDelta = newSize;

    }

    public void AdjustRedZone1(float newPositionY, float newHeight)
    {

        // Adjust position
        Vector2 newPosition = RedZone1.anchoredPosition;
        newPosition.y = newPositionY;
        RedZone1.anchoredPosition = newPosition;

        // Adjust size
        Vector2 newSize = RedZone1.sizeDelta;
        newSize.y = newHeight;
        RedZone1.sizeDelta = newSize;

    }

    public void AdjustOrangeZone(float newPositionY, float newHeight)
    {

        // Adjust position
        Vector2 newPosition = OrangeZone.anchoredPosition;
        newPosition.y = newPositionY;
        OrangeZone.anchoredPosition = newPosition;

        // Adjust size
        Vector2 newSize = OrangeZone.sizeDelta;
        newSize.y = newHeight;
        OrangeZone.sizeDelta = newSize;

    }

    public void AdjustOrangeZone1(float newPositionY, float newHeight)
    {

        // Adjust position
        Vector2 newPosition = OrangeZone1.anchoredPosition;
        newPosition.y = newPositionY;
        OrangeZone1.anchoredPosition = newPosition;

        // Adjust size
        Vector2 newSize = OrangeZone1.sizeDelta;
        newSize.y = newHeight;
        OrangeZone1.sizeDelta = newSize;

    }

    public void AdjustBlueZone(float newPositionY, float newHeight)
    {

        // Adjust position
        Vector2 newPosition = BlueZone.anchoredPosition;
        newPosition.y = newPositionY;
        BlueZone.anchoredPosition = newPosition;

        // Adjust size
        Vector2 newSize = BlueZone.sizeDelta;
        newSize.y = newHeight;
        BlueZone.sizeDelta = newSize;

    }

    public void AdjustBlueZone1(float newPositionY, float newHeight)
    {

        // Adjust position
        Vector2 newPosition = BlueZone1.anchoredPosition;
        newPosition.y = newPositionY;
        BlueZone1.anchoredPosition = newPosition;

        // Adjust size
        Vector2 newSize = BlueZone1.sizeDelta;
        newSize.y = newHeight;
        BlueZone1.sizeDelta = newSize;

    }

    public void AdjustGreenZone(float newPositionY, float newHeight)
    {

        // Adjust position
        Vector2 newPosition = GreenZone.anchoredPosition;
        newPosition.y = newPositionY;
        GreenZone.anchoredPosition = newPosition;

        // Adjust size
        Vector2 newSize = GreenZone.sizeDelta;
        newSize.y = newHeight;
        GreenZone.sizeDelta = newSize;

    }

}

