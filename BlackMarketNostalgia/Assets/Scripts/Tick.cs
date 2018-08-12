using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tick : MonoBehaviour {

    public delegate void TickEvent();
    public static event TickEvent CallTick;

    void Start ()
    {
        StartCoroutine(TickEveryFourSeconds());
	}
	
	IEnumerator TickEveryFourSeconds()
    {
        while(true)
        {
            yield return new WaitForSeconds(4);

            if (CallTick != null)
            {
                CallTick();
            }

        }
    }
}
