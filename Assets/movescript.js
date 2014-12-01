#pragma strict

var cam:GameObject;
var skiY:float;
var camY:float;
var turnSpeed:float;
var angle : float;
var push : float;
var pushVec:Vector3;
function Start () {
}
function Update() {
	skiY=transform.eulerAngles.y;
	camY=cam.transform.eulerAngles.y;
	transform.eulerAngles.y = camY;

//	transform.eulerAngles.y = 
}
function FixedUpdate () {
	pushVec = cam.transform.forward*push;
	pushVec.y=0;
	// go in the direction of the camera
	rigidbody.AddForce(pushVec);
	//rigidbody.AddTorque(cam.transform.forward * turnSpeed);
	
//
//	var calc = Mathf.MoveTowardsAngle(skiY, camY, turnSpeed * Time.deltaTime);
//	//if (calc - skiY < 0) calc *= -1;
//	var targetDir = cam.transform.position - transform.position;
//	var forward = transform.forward;
//	var localTarget = transform.InverseTransformPoint(cam.transform.position);
//	angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;
//
//	var eulerAngleVelocity : Vector3 = Vector3 (0, angle, 0);
//	var deltaRotation : Quaternion = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime * turnSpeed );
//	rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
}