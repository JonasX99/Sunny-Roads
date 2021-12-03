using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Battery : MonoBehaviour
{
    public float batteryPower;

    [SerializeField]
    private float maxBatteryCapacity;

    [Header("Lower the value to increse Use or Charge rate")]
    public float energyUseRate;
    public float energyChargeRate;

    public GameObject[] BatteryUpgradeModel;

    public Slider BatteryBar;
    public GameObject DeathUI;
    public GameObject GameUI;
    public TextMeshProUGUI DeathText;
    public string[] randomBatteryText;
    public string[] randomCrashText;
    // Start is called before the first frame update
    void Start()
    {
        loadBatteryUpgrade();
        BatteryBar.maxValue = maxBatteryCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        if (maxBatteryCapacity <= 2) BatteryBar.gameObject.SetActive(false);
        if (batteryPower <= 0) EmptyBattery();
    }

    public void AddEnergy()
    {
        batteryPower++;
        batteryPower = Mathf.Clamp(batteryPower, 0, maxBatteryCapacity);
        BatteryBar.value = batteryPower;
    }

    public void UseEnergy(float energyUsage)
    {
        batteryPower -= energyUsage;
        batteryPower = Mathf.Clamp(batteryPower, 0, maxBatteryCapacity);
        BatteryBar.value = batteryPower;
    }

    public void EmptyBattery()
    {
        //Make it run only one time
        if(DeathUI.activeInHierarchy == false) DeathText.text = randomBatteryText[Random.Range(0, randomBatteryText.Length)];
        DeathUI.SetActive(true);
        GameUI.SetActive(false);
    }
    public void Crash()
    {
        //Make it run only one time if he hit tree twice
        if(DeathUI.activeInHierarchy == false) DeathText.text = randomCrashText[Random.Range(0, randomCrashText.Length)];
        DeathUI.SetActive(true);
        GameUI.SetActive(false);
    }
    private void OnCollisionEnter(Collision col)
    {
        Crash();
    }

    void loadBatteryUpgrade()
    {
        maxBatteryCapacity = PlayerPrefs.GetFloat("BatteryUpgradeAmount");
        if(Mathf.RoundToInt(PlayerPrefs.GetFloat("BatteryAmount")) != 0) BatteryUpgradeModel[Mathf.RoundToInt(PlayerPrefs.GetFloat("BatteryAmount"))].SetActive(true);
    }
}
