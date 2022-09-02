using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public List<GameObject> screens = new List<GameObject>();

    public void ActivateScreen(string screenName)
    {
        foreach (GameObject screen in screens)
        {
            screen.SetActive(false);

            if (screen.name == screenName) {
                screen.SetActive(true);
            }
        }
    }
}
