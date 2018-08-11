using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public Text text;
    string outputText;

    private void OnEnable()
    {
        GameManager.PlayerSuccess += PlayerSuccess;
        GameManager.CorporateSuccess += CorporateSuccess;
        GameManager.NoSuccess += NoSuccess;
    }

    private void OnDisable()
    {
        GameManager.PlayerSuccess -= PlayerSuccess;
        GameManager.CorporateSuccess -= CorporateSuccess;
        GameManager.NoSuccess -= NoSuccess;
    }

    private void Start()
    {
        outputText = "Select a neighborhood to influence.";
    }

    private void Update()
    {
        text.text = outputText;
    }

    void PlayerSuccess()
    {
        outputText = "The player spreads influence.";
    }

    void CorporateSuccess()
    {
        outputText = "The people resist the player's influence";
    }

    void NoSuccess()
    {
        outputText = "There is no change in influence";
    }
}
