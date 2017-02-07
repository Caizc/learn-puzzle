using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveAndOpenDoor : ReceiveLaser
{

	public Transform[] doors;
	bool HasEnergy = false;

	void FixedUpdate ()
	{
	
		if (HasEnergy) {
			foreach (Transform tr in doors) {
				tr.position = Vector3.Lerp (tr.position, new Vector3 (tr.position.x, -10, tr.position.z), Time.fixedDeltaTime);
			}
		}
	}

	public override void HighEnergy ()
	{
		HasEnergy = true;
	}

}
