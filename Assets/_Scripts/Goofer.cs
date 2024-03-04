using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goofer : MonoBehaviour
{
    public static Vector3 crosshair;
    private Vector3 currentpos;
    private Vector3 tovector;
    private Vector3 anglevector;
    private float angle;
    private Vector3 withoutycrosshair;

    void Update()
    {
        currentpos = transform.position;
        //withoutycrosshair = Goober.crosshair * Vector3(1, 0, 1);
        tovector = currentpos - Goober.crosshair;
        angle = Mathf.Atan2(tovector.y, tovector.x) * Mathf.Rad2Deg;
        anglevector = new Vector3(0, 0, angle);
        //Debug.Log(tovector);

        tovector.Normalize();
        transform.position -= tovector * Time.deltaTime; //moves enemy towards player. 


        transform.LookAt(new Vector3(Goober.crosshair.x, 0, Goober.crosshair.z), Vector3.up);


        //transform.localEulerAngles = anglevector;

        //transform.Rotate(0, 0, .1f);
        //transform.rotation = (0, 0, angle);
        //stretch goal?

        //Quaternion lookatrotation = Quaternion.LookRotation(tovector);
        //Quaternion finalrotation = lookatrotation * new Quaternion(0, 0, 0, 0);
        //Quaternion finalRotation = Quaternion.Euler(angle, angle, angle);
        //transform.rotation = Quaternion.LookRotation(tovector, Vector3.back);
        //transform.rotation = finalRotation;
    }

}
