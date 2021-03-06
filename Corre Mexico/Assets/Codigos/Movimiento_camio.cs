﻿using UnityEngine;
using System.Collections;

public class Movimiento_camio : MonoBehaviour {

    public WheelCollider Llanta1;
    public WheelCollider Llanta2;
    public WheelCollider Llanta3;
    public WheelCollider Llanta4;
    public int Vel = 1000000000*2;
    public Transform Neumatico1;
    public Transform Neumatico2;
    public Transform Neumatico3;
    public Transform Neumatico4;
    public ChecadorBoton BotonIzq;
    public ChecadorBoton BotonDer;
    public ChecadorBoton PoderDer;
    public ChecadorBoton PoderIzq;
    public Rigidbody Camioneta;
    public float VelAct;
    public GameObject Bola;
    
    //public string VueltaDer;
    //public float horizontalSpeed = 2.0F;


    //private object centerOfMass; 
    // Use this for initialization
    // public float rotationSpeed = 100.0F;
    void Start ()
    {
        //if (centerOfMass != null)
        // Camioneta.position =Vector3 ;
        Camioneta.centerOfMass = new Vector3(0, -1, 0);
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        Llanta3.motorTorque = Vel;
        Llanta4.motorTorque = Vel;

        Neumatico1.localEulerAngles = new Vector3(0, Llanta1.steerAngle *.25f, 0);
        Neumatico2.localEulerAngles = new Vector3(0, Llanta2.steerAngle *.25f, 0);
        
        //GIRO DE LLANTAS
        /*
        Neumatico1.Rotate(new Vector3(Llanta1.rpm / 60 * 360 * Time.deltaTime,0,0));
        Neumatico2.Rotate(new Vector3(Llanta1.rpm / 60 * 360 * Time.deltaTime, 0, 0));
        Neumatico3.Rotate(new Vector3(Llanta1.rpm / 60 * 360 * Time.deltaTime, 0, 0));
        Neumatico4.Rotate(new Vector3(Llanta1.rpm / 60 * 360 * Time.deltaTime, 0, 0));
        */
        if (BotonDer.pulsado==true)
        {
            Camioneta.transform.Rotate(0,1.2f,0);
            //Llanta1.steerAngle = -10 * Input.IpointerUpHandler();
            // Llanta1.steerAngle =10* Input.GetAxis("Mouse X");
            Llanta2.steerAngle = 15;
            Llanta1.steerAngle = 15;
            //Camioneta.mass = 2500;
            Camioneta.angularDrag = 25;
            Camioneta.drag = 0.1f;
            Llanta1.suspensionDistance = 0;
            Llanta2.suspensionDistance = 0;
            
           // Llanta1.forceAppPointDistance = -1;
            //Llanta2.forceAppPointDistance = -1;
            //Llanta3.motorTorque = Vel*10;
            //Llanta4.motorTorque = Vel*10;
            //Llanta3.brakeTorque = 10;
            // Llanta4.brakeTorque = 10;
            //Llanta1.steerAngle = Input.GetAxis("Horizontal") ;
            // transform.Rotate(0, rotation, 0);
            // transform.Rotate(-.1f,0, 0);
        }
       else
        {
            Llanta2.steerAngle = 0;
            Llanta1.steerAngle = 0;
           // Camioneta.mass = 2000;
            Llanta3.motorTorque = Vel;
            Llanta4.motorTorque = Vel;
            Camioneta.angularDrag = 5;
           // Camioneta.drag = 0.05f;
            Llanta1.suspensionDistance = .3f;
            Llanta2.suspensionDistance = .3f;
        }
        if (BotonIzq.pulsado==true)
        {
            Camioneta.transform.Rotate(0, -1.2f, 0);
            //Llanta1.steerAngle = Input.GetAxis("Horizontal");
            Llanta1.steerAngle = -15;
            Llanta2.steerAngle = -15;
            //Camioneta.mass = 2500;
            Camioneta.angularDrag = 25;
            //Camioneta.drag =0.1f;
            Llanta1.suspensionDistance = 0;
            Llanta2.suspensionDistance = 0;
            //Llanta1.forceAppPointDistance = -1;
            //Llanta2.forceAppPointDistance = -1;
            // Llanta3.motorTorque = Vel*10;
            //Llanta4.motorTorque = Vel*10;
            //transform.Rotate(.1f,0, 0);
            // Llanta3.brakeTorque = 100;
            //Llanta4.brakeTorque = 100;
            // transform.Rotate(0, rotation, 0);
        }
        /* else
         {
             Llanta2.steerAngle = 0;
             Llanta1.steerAngle = 0;
             Camioneta.mass = 1500;
         }*/
        /*if(BotonDer.pulsado==false)
         {
             Llanta2.steerAngle = 0;
             Llanta1.steerAngle = 0;
         }
         if (BotonIzq.pulsado == false)
         {
             Llanta2.steerAngle = 0;
             Llanta1.steerAngle = 0;
         }*/

        VelAct = (2 * Mathf.PI * Llanta1.radius) * Llanta1.rpm * 60 / 1000;
        VelAct = Mathf.Round(VelAct);

        if(PoderDer.pulsado==true)
        {
            Instantiate(Bola,Camioneta.position,Camioneta.rotation);
        }
        if (PoderIzq.pulsado == true)
        {
            Instantiate(Bola, Camioneta.position, Camioneta.rotation);
        }


        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Vector3 forward135 = transform.TransformDirection(10,0,-10) ;
        Vector3 forward135Contra = transform.TransformDirection(-10, 0, -10);
        Debug.DrawRay(Camioneta.position, forward, Color.green);
        Debug.DrawRay(Camioneta.position,forward135 , Color.green);
        Debug.DrawRay(Camioneta.position, forward135Contra, Color.red);
    }
}
