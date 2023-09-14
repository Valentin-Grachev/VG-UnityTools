using System.Collections.Generic;
using UnityEngine;
using VG;

public class CheckAnalytics : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) 
            Analytics.Track(Key_Analytics.test.Name, new Dictionary<string, object> {
            { Key_Analytics.test.test_string, "string" },
            { Key_Analytics.test.test_float, 0.567f },
            { Key_Analytics.test.test_int, -56 },
        });
    }
}
