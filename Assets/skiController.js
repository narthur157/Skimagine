#pragma strict

function Update () {
	var skiEdge:float = Input.GetAxis("Horizontal");
	if (skiEdge == 1) transform.localEulerAngles.x=20;
	else if (skiEdge == -1) transform.localEulerAngles.x=-20;
	else transform.localEulerAngles.x=0;
}