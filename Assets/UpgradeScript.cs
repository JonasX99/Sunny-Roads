using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeScript : MonoBehaviour
{
    private int Money;

    [Header("Battery")]
    public int[] BatteryUpgradeCost;
    public int[] BatteryUpgradeAmount;
    public GameObject[] BatteryUpgradeModel;

    public Slider BatterySlider;
    public TextMeshProUGUI BatteryCostText;
    public Image BatteryCoinImage;
    private int BatteryAmount;

    [Header("Wheels")]
    public int[] WheelsUpgradeCost;
    public int[] WheelsUpgradeAmount;
    public WheelsModels[] WheelsUpgradeModel;

    public Slider WheelsSlider;
    public TextMeshProUGUI WheelsCostText;
    public Image WheelsCoinImage;
    private int WheelsAmount;

    [System.Serializable]
    public class WheelsModels
    {
        public GameObject Wheel1;
        public GameObject Wheel2;
        public GameObject Wheel3;
        public GameObject Wheel4;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadBatteryUpgrade();
        LoadWheelsUpgrade();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            PlayerPrefs.SetInt("Money", 200);
        }
    }
    void LoadBatteryUpgrade()
    {
        BatteryAmount = Mathf.RoundToInt(PlayerPrefs.GetFloat("BatteryAmount"));
        if (BatteryAmount == 5)
        {
            BatteryCostText.text = "MAX";
            BatteryCoinImage.enabled = false;
        }
        else BatteryCostText.text = BatteryUpgradeCost[BatteryAmount].ToString();
        BatterySlider.value = BatteryAmount;
        if(BatteryAmount != 0) BatteryUpgradeModel[BatteryAmount].SetActive(true);
        PlayerPrefs.SetFloat("BatteryUpgradeAmount", BatteryUpgradeAmount[BatteryAmount]);
    }
    public void BatteryUpgrade()
    {
        Money = PlayerPrefs.GetInt("Money");
        BatteryAmount = Mathf.RoundToInt(PlayerPrefs.GetFloat("BatteryAmount"));
        if (Money >= BatteryUpgradeCost[BatteryAmount])
        {
            Money -= BatteryUpgradeCost[BatteryAmount];
            if (BatteryAmount != 0) BatteryUpgradeModel[BatteryAmount].SetActive(false);
            PlayerPrefs.SetInt("Money", Money);
            BatterySlider.value += 1;
            PlayerPrefs.SetFloat("BatteryAmount", BatterySlider.value);
            BatteryAmount = Mathf.RoundToInt(PlayerPrefs.GetFloat("BatteryAmount"));
            if (BatteryAmount == 5)
            {
                BatteryCostText.text = "MAX";
                BatteryCoinImage.enabled = false;
            }
            else BatteryCostText.text = BatteryUpgradeCost[BatteryAmount].ToString();
            BatteryUpgradeModel[BatteryAmount].SetActive(true);
            PlayerPrefs.SetFloat("BatteryUpgradeAmount", BatteryUpgradeAmount[BatteryAmount]);
        }
    }
    void LoadWheelsUpgrade()
    {
        WheelsAmount = Mathf.RoundToInt(PlayerPrefs.GetFloat("WheelsAmount"));
        if (WheelsAmount == 5)
        {
            WheelsCostText.text = "MAX";
            WheelsCoinImage.enabled = false;
        }
        else WheelsCostText.text = WheelsUpgradeCost[WheelsAmount].ToString();
        WheelsSlider.value = WheelsAmount;
        WheelsUpgradeModel[WheelsAmount].Wheel1.SetActive(true);
        WheelsUpgradeModel[WheelsAmount].Wheel2.SetActive(true);
        WheelsUpgradeModel[WheelsAmount].Wheel3.SetActive(true);
        WheelsUpgradeModel[WheelsAmount].Wheel4.SetActive(true);
        PlayerPrefs.SetFloat("WheelsUpgradeAmount", WheelsUpgradeAmount[WheelsAmount]);
    }
    public void WheelsUpgrade()
    {
        Money = PlayerPrefs.GetInt("Money");
        WheelsAmount = Mathf.RoundToInt(PlayerPrefs.GetFloat("WheelsAmount"));
        if (Money >= WheelsUpgradeCost[WheelsAmount])
        {
            Money -= WheelsUpgradeCost[WheelsAmount];
            WheelsUpgradeModel[WheelsAmount].Wheel1.SetActive(false);
            WheelsUpgradeModel[WheelsAmount].Wheel2.SetActive(false);
            WheelsUpgradeModel[WheelsAmount].Wheel3.SetActive(false);
            WheelsUpgradeModel[WheelsAmount].Wheel4.SetActive(false);
            PlayerPrefs.SetInt("Money", Money);
            WheelsSlider.value += 1;
            PlayerPrefs.SetFloat("WheelsAmount", WheelsSlider.value);
            WheelsAmount = Mathf.RoundToInt(PlayerPrefs.GetFloat("WheelsAmount"));
            if (WheelsAmount == 5)
            {
                WheelsCostText.text = "MAX";
                WheelsCoinImage.enabled = false;
            }
            else WheelsCostText.text = WheelsUpgradeCost[WheelsAmount].ToString();
            WheelsUpgradeModel[WheelsAmount].Wheel1.SetActive(true);
            WheelsUpgradeModel[WheelsAmount].Wheel2.SetActive(true);
            WheelsUpgradeModel[WheelsAmount].Wheel3.SetActive(true);
            WheelsUpgradeModel[WheelsAmount].Wheel4.SetActive(true);
            PlayerPrefs.SetFloat("WheelsUpgradeAmount", WheelsUpgradeAmount[WheelsAmount]);
        }
    }
}
