using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarCell : MonoBehaviour
{
    public Battery LinkToBattery;
    public GameObject directionalLight;
    public bool inShadow;

    // Start is called before the first frame update
    void Start()
    {
        LinkToBattery = GetComponentInParent<Battery>();
        StartCoroutine(energysystem());
    }

    // Update is called once per frame
    void Update()
    {
        Raytrace();
    }

    void Raytrace()
    {
        Vector3 Directiontowards = -directionalLight.transform.forward;
        Directiontowards = Directiontowards.normalized;
        Debug.DrawLine(transform.position, transform.position - Directiontowards);

        RaycastHit hit;
        //raycast after mesh
        inShadow = GraphicsRaycast.Raycast(transform.position, Directiontowards, out hit, 100, LayerMask.GetMask("Shadow"));
        Debug.DrawRay(transform.position, Directiontowards, Color.green);
        //raycast after collider
        //inShadow = Physics.Raycast(transform.position, Directiontowards);
    }



    IEnumerator energysystem()
    {
        if (!inShadow) LinkToBattery.AddEnergy();
        yield return new WaitForSeconds(LinkToBattery.energyChargeRate);
        StartCoroutine(energysystem());
    }

}
