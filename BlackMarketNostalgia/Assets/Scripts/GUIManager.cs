using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public Text text;
    public Text title;
    string outputText;
    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        outputText = gm.time.ToString();
        text.text = outputText;
        if (gm.GetSelectedNeighborhood() != null)
        {
            title.text = gm.GetSelectedNeighborhood().ToString();
        }
        else
        {
            title.text = "Select Neighborhood.";
        }

    }
}
