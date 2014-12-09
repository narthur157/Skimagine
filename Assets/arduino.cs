//using UnityEngine;
//using System.Collections;
//using System;
//using System.IO.Ports;
//
//
//public class arduino : MonoBehaviour {
//	public string tilt;
//	public SerialPort port;
//	public int modulus = 30;
//	public int count = 0;
//	public double turnSpeed = 3;
//	// Use this for initialization
//	void Start () {
//		port = new SerialPort("COM3", 9600);
//		port.Open ();
//		port.ReadTimeout = 200;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		count++;
//		count = count % modulus;
//		//if (count == 0) 
//		tilt = ReadData();
//		var tiltInt = Convert.ToInt32 (tilt);
//		var ang = transform.eulerAngles;
//		ang.y = transform.eulerAngles.y + (float)((double)tiltInt * (turnSpeed / 500.0));
//		transform.eulerAngles = ang;
//
//	}
//	public string  ReadData()
//	{
//		string tmpByte;
//		string rxString = "";
//		
//		tmpByte = (string) port.ReadLine();
//		return tmpByte;
//		//        while (tmpByte != 255) {
//		//            rxString += ((char) tmpByte);
//		//            tmpByte = (byte) mySerial.ReadByte();
//		//        }
//		// 
//		//        return rxString;
//	}
//}
