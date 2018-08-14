using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowTo : MonoBehaviour {

    public GameObject howTo;

	public void OpenHowTo()
    {
        howTo.SetActive(true);
    }

    public void CloseHowTo()
    {
        howTo.SetActive(false);
    }
}
