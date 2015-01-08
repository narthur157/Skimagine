using UnityEngine;
using System.Collections;
using System;
using System.IO.Ports;


public class skiController : MonoBehaviour {
	// changes made in editor to this *will* be overridden
	public double tilt;
	// for the skis
	public double turnSpeed = 3;
	public float turnStrength = .86f;
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
	public Vector3 velocity;
	public Vector3 localVel;
	void Update () {
		float skiDeltaY = 0;

		tilt = Input.GetAxis("Horizontal");
		bool boost = Input.GetButtonDown("Boost");
		skiDeltaY += (float)(tilt * (turnSpeed));// / turnSpeedFactorReduction));
		Vector3 ang = transform.eulerAngles;
		ang.y += skiDeltaY;

		transform.eulerAngles = ang;

		Vector3 vel = rigidbody.velocity;
		float total = rigidbody.velocity.x + rigidbody.velocity.z;
		float zxMag = rigidbody.velocity.magnitude;
		if (zxMag >= maxZXVelocity) {
			vel = vel.normalized * maxZXVelocity;
		}
		velocity = rigidbody.velocity;
		// the further our skis are tilted away from our velocity, the faster we want to dampen that velocity
		// how to calculate rotational distance between a velocity 
		localVel = transform.InverseTransformDirection (vel);
		//rigidbody.drag = Math.Abs (transform.InverseTransformDirection(rigidbody.velocity).x) * (float)turnStrength;
		//transform.InverseTransformDirection(rigidbody.velocity)
		localVel.x -= localVel.x * turnStrength;

		if (boost) localVel.z += 4;

		rigidbody.velocity = transform.TransformDirection(localVel);
	}
	void FixedUpdate () {
		// go in the direction of the camera
		//rigidbody.AddForce(cam.transform.forward * speed );
		rigidbody.AddForce(transform.forward * speed);
	}
}
