using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour {

    public AudioSource click;

    private void OnMouseDown()
    {
        click.Play();
    }
}
