#pragma strict

var cam:GameObject;
var camY:float;
var turnSpeed:float = 3;
var push : float;
var pushVec:Vector3;
var turn:float;
function Start () {
	turn = 0;
}
function Update() {
//	camY=cam.transform.eulerAngles.y;
//	transform.eulerAngles.y = camY;
	var turnDir:float = Input.GetAxis("Horizontal");
	transform.eulerAngles.y += turnDir*(turnSpeed/1000.0);
}
function FixedUpdate () {
	pushVec = transform.forward*push;
	pushVec.y=0;
	// go in the direction of the skis
	rigidbody.AddForce(pushVec);

}