using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveAndWin : ReceiveLaser
{

	public GameObject Win;

	public override void HighEnergy ()
	{
		Win.SetActive (true);
	}

}
