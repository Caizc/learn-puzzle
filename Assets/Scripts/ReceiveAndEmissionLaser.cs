using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveAndEmissionLaser : ReceiveLaser
{

	public EmissionLaser[] EmissionLasers;

	public override void HighEnergy ()
	{
		foreach (EmissionLaser EmissionLaser in EmissionLasers) {
			EmissionLaser.StartEmission ();
		}
	}

	public override void LowEnergy ()
	{
		foreach (EmissionLaser EmissionLaser in EmissionLasers) {
			EmissionLaser.EndEmission ();
		}
	}
		
}
