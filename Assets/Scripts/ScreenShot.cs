using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    int count;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Capture", 0.1f, 0.3f);
        }
    }

    void Capture()
    {
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/ScreenShots" + count + ".png");
        count++;
    }
}
