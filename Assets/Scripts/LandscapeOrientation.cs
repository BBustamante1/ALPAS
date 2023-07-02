using UnityEngine;

public class LandscapeOrientation : MonoBehaviour
{
    // Start in landscape mode
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
