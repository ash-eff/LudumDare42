using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour {

    public GameObject window;

    public Text upgradeName;
    public Text flavorText;
    public Text chitCost;
    public Text notification;

    public Upgrade currentUpgrade;

    public bool shopOpen;

    public void SetCurrentUpgrade(Upgrade x) { currentUpgrade = x; }

    float timer;

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            notification.text = "";
        }
    }

    public void OpenWindow()
    {
        if (window.activeSelf == false)
        {
            window.SetActive(true);
            shopOpen = true;
            //Time.timeScale = 0;
        }
    }

    public void CloseWindow()
    {
        if(window.activeSelf == true)
        {           
            window.SetActive(false);
            shopOpen = false;
            //Time.timeScale = 1;
        }
    }

    public void LoadUpgrade()
    {
        currentUpgrade = EventSystem.current.currentSelectedGameObject.GetComponent<Upgrade>();
        upgradeName.text = currentUpgrade.name;
        flavorText.text = currentUpgrade.flavorText.text;
        
        chitCost.text = "Chits: " + currentUpgrade.chitCost.ToString();
    }

    public void BuyUpgrade()
    {
        if (player.m_chits >= currentUpgrade.chitCost && !currentUpgrade.purchased)
        {
            player.m_chits -= currentUpgrade.chitCost;
            player.m_voiceBoost += currentUpgrade.upgradeAmount;
            currentUpgrade.purchased = true;
            timer = 2f;
            notification.text = "Purchased!";
        }
        else if (currentUpgrade.purchased)
        {
            timer = 2f;
            notification.text = "Already purchased!";
        }
        else
        {
            timer = 2f;
            notification.text = "Not enough chits!";
        }
    }

    
}
