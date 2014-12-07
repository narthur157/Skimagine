#pragma strict


var cam:GameObject;
var skiY:float;
var camY:float;
var turnSpeed:float;
var angle : float;
var push : float;

function Start () {
	
}
function Update() {
	//skiY=transform.eulerAngles.y;
	//camY=cam.transform.eulerAngles.y;
	//transform.eulerAngles.y = camY;
//	transform.eulerAngles.y = 
	
	
}
function FixedUpdate () {

	// go in the direction of the camera
	rigidbody.AddForce(cam.transform.forward * push );
}
