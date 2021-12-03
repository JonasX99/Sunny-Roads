using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public WheelCollider FrontWheelL;
    public WheelCollider FrontWheelR;
    public WheelCollider BackWheelL;
    public WheelCollider BackWheelR;

    public float speed;
    public float steer;
    public float dispSpeed;

    private Battery LinkToBattery;

    private float Horizontal;
    private float Vertical;

    public Image paddel;
    public Sprite paddelDown;
    public Sprite paddelUp;

    public bool CanDrive = true;

    //wheelupgrade
    public WheelsModels[] WheelsUpgradeModel;

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
        loadWheelsUpgrade();
        LinkToBattery = GetComponent<Battery>();
        StartCoroutine(UseEnergySystem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (!Application.isMobilePlatform)
        {
            Horizontal = Input.GetAxis("Horizontal"); //steering
            Vertical = Input.GetAxis("Vertical"); //speed
            Vertical = Mathf.Clamp(Vertical, 0, 1);
            //Disable paddel if on PC/Editor
            paddel.enabled = false;
        }
        else
        {
            //Mobile Controls
            Horizontal = Input.acceleration.x * 3; //steerings
            Horizontal = Mathf.Clamp(Horizontal, -1, 1);
            //Enable paddel if on mobile
            paddel.enabled = true;
        }

        if (CanDrive)
        {
            if (BackWheelL.isGrounded || BackWheelR.isGrounded)
            {
                if (LinkToBattery.batteryPower >= 1)
                {
                    DriveWheels();
                }
                else
                {
                    StopWheels();
                }
            }

            FrontWheelL.steerAngle = Horizontal * steer;
            FrontWheelR.steerAngle = Horizontal * steer;
        }
        //Calculate the speed of the car
        dispSpeed = GetComponent<Rigidbody>().velocity.magnitude;
    }

    IEnumerator UseEnergySystem()
    {
        LinkToBattery.UseEnergy(Vertical);
        yield return new WaitForSeconds(LinkToBattery.energyUseRate);
        StartCoroutine(UseEnergySystem());
    }
    public void Accelerate()
    {
        Vertical = 1;
        paddel.sprite = paddelDown;
    }

    public void Deccelerate()
    {
        Vertical = 0;
        paddel.sprite = paddelUp;
    }

    public void DriveWheels()
    {
        BackWheelL.motorTorque = Vertical * speed;
        BackWheelR.motorTorque = Vertical * speed;
        BackWheelL.brakeTorque = 0;
        BackWheelR.brakeTorque = 0;
        FrontWheelL.brakeTorque = 0;
        FrontWheelR.brakeTorque = 0;
        GetComponent<Rigidbody>().drag = 0;
    }
    public void StopWheels()
    {
        BackWheelL.motorTorque = 0;
        BackWheelR.motorTorque = 0;
        BackWheelL.brakeTorque = 10000;
        BackWheelR.brakeTorque = 10000;
        FrontWheelL.brakeTorque = 10000;
        FrontWheelR.brakeTorque = 10000;
        GetComponent<Rigidbody>().drag = 5;
    }

    void loadWheelsUpgrade()
    {
        WheelFrictionCurve Curve;
        Curve = BackWheelL.forwardFriction;
        Curve.asymptoteSlip = (PlayerPrefs.GetFloat("WheelsUpgradeAmount") / 10) - 1;
        BackWheelL.forwardFriction = Curve;
        BackWheelR.forwardFriction = Curve;
        FrontWheelL.forwardFriction = Curve;
        FrontWheelR.forwardFriction = Curve;
        WheelsUpgradeModel[Mathf.RoundToInt(PlayerPrefs.GetFloat("WheelsAmount"))].Wheel1.SetActive(true);
        WheelsUpgradeModel[Mathf.RoundToInt(PlayerPrefs.GetFloat("WheelsAmount"))].Wheel2.SetActive(true);
        WheelsUpgradeModel[Mathf.RoundToInt(PlayerPrefs.GetFloat("WheelsAmount"))].Wheel3.SetActive(true);
        WheelsUpgradeModel[Mathf.RoundToInt(PlayerPrefs.GetFloat("WheelsAmount"))].Wheel4.SetActive(true);
    }
}
