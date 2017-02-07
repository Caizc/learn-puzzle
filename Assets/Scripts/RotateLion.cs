using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLion : MonoBehaviour
{

	SteamVR_LaserPointer SteamVR_LaserPointer;
	SteamVR_TrackedController SteamVR_TrackedController;
	Transform pointTransform;
	GameObject currentCatch;
	bool isTrigger;

	void Start ()
	{
		// 获取 SteamVR_LaserPointer 和 SteamVR_TrackedController 并监听属性
		SteamVR_LaserPointer = GetComponent<SteamVR_LaserPointer> ();
		SteamVR_LaserPointer.PointerIn += PointerIn;
		SteamVR_LaserPointer.PointerOut += PointerOut;

		SteamVR_TrackedController = GetComponent<SteamVR_TrackedController> ();
		SteamVR_TrackedController.TriggerClicked += TriggerClicked;
		SteamVR_TrackedController.TriggerUnclicked += TriggerUnclicked;
	}

	void FixedUpdate ()
	{
		if (pointTransform != null && isTrigger) {
			pointTransform.rotation = Quaternion.AngleAxis (pointTransform.rotation.eulerAngles.y + 0.8f, Vector3.up);
		}
	}

	void PointerIn (object sender, PointerEventArgs e)
	{
		// 判断是否 tag 为 Lion ，如果不是就不设置激光击中坐标
		if (e.target.gameObject.tag == "Lion") {
			pointTransform = e.target;
		}
	}

	void PointerOut (object sender, PointerEventArgs e)
	{
		pointTransform = null;
	}

	void TriggerClicked (object sender, ClickedEventArgs e)
	{
		isTrigger = true;
	}

	void TriggerUnclicked (object sender, ClickedEventArgs e)
	{
		isTrigger = false;
	}
}
