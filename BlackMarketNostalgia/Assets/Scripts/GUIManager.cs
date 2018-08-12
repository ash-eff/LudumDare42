using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public Text text;
    public Text title;
    public Text influenceTotal;
    public Text nextUnlock;
    string outputText;
    string influenceText;
    GameManager gm;
    Player player;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
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

        influenceText = player.m_influence.ToString();
        influenceTotal.text = influenceText;
        nextUnlock.text = gm.amountToUnlockNextNeighborhood.ToString();
    }
}
