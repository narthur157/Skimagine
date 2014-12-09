using UnityEngine;
using System.Collections;
using System;
using System.IO.Ports;


public class skiController : MonoBehaviour {
	// changes made in editor to this *will* be overridden
	public double tilt;
	// for the skis
	public double turnSpeed = 3;
	// false, use keyboard, true use accelerometer
	public bool useArduino = false;
	// the arduino
	public SerialPort port;
	// how much does the direction the camera is facing contribute to where we go
	public int cameraVelocityContribution = 0;
	// how much the direction of skis contributes to where we go
	public int skiVelocityContribution = 100;
	// scale down the turnspeed. Just makes using the parameter nicer
	private double turnSpeedFactorReduction = 500.0;
	// doesn't affect gravity
	public float maxZXVelocity = 10;
	public int speed = 1000;
	public GameObject cam;
	void Start () {
		tilt = 0;
		if (useArduino) {
			int failCount = 0;
			for (int i = 1; i <= 4; i++) {
				try {
					port = new SerialPort("COM"+i.ToString(), 9600);
				}
				catch (System.IO.IOException e) {
					failCount++;
				}
			}
			if (failCount == 4) Debug.LogError("Failed to open arduino...crap");
			port.Open ();
			port.ReadTimeout = 200;
		}
	}
	void Update () {
		float skiDeltaY = 0;
		if (useArduino) {
			if (port.BytesToRead > 0) {
				tilt = ReadData ();		
			}
		}
		else {
			tilt = Input.GetAxis("Horizontal");
		}

		skiDeltaY += (float)(tilt * (turnSpeed / turnSpeedFactorReduction));
		Vector3 ang = transform.eulerAngles;
		ang.y += skiDeltaY;

		transform.eulerAngles = ang;

		Vector3 vel = rigidbody.velocity;
		float total = rigidbody.velocity.x + rigidbody.velocity.z;
		float zxMag = total / 2;
		if (zxMag >= maxZXVelocity) {
			// percent of the two original velocities
			float xPercent = rigidbody.velocity.x / total;
			float zPercent = rigidbody.velocity.z / total;
			// xPercent + zPercent should be 1. Therefore (xPercent+zPercent)*zxMag=zxMag and we'll be at the max velocity
			// log the output if it isn't 1
			if (xPercent + zPercent != 1.0) Debug.LogError("xPercent plus zPercent should be 1, it is " + (xPercent+zPercent).ToString ());
			vel.x = xPercent * zxMag;
			vel.z = zPercent * zxMag;
			rigidbody.velocity = vel;
		}
	}
	void FixedUpdate () {
		
		// go in the direction of the camera
		rigidbody.AddForce(cam.transform.forward * speed );
		rigidbody.AddForce (transform.forward * speed);
	}
	public float  ReadData()
	{
		string tmpByte;
		string rxString = "";
		
		tmpByte = (string) port.ReadLine();
		return (float) Convert.ToDouble (tmpByte);
		//        while (tmpByte != 255) {
		//            rxString += ((char) tmpByte);
		//            tmpByte = (byte) mySerial.ReadByte();
		//        }
		// 
		//        return rxString;
	}
}
