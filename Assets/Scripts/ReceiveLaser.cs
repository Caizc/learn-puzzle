using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveLaser : MonoBehaviour
{
	// 引用计数
	int ReferenceCount = 0;

	// Use this for initialization
	void Start ()
	{
		
	}

	// 有激光击中
	public void PointerIn ()
	{
		ReferenceCount++;
		if (ReferenceCount > 0) {
			HighEnergy ();
		}
	}

	// 激光离开
	public void PointerOut ()
	{
		ReferenceCount--;
		if (ReferenceCount <= 0) {
			LowEnergy ();
		}
	}

	// 进入低能量状态
	public virtual void LowEnergy ()
	{

	}

	// 进入高能量状态
	public virtual void HighEnergy ()
	{
		
	}

}
