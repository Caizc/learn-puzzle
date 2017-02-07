using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionLaser : MonoBehaviour
{
	// 开光控制是否发射激光
	public bool Enable;

	// 激光发射点
	public GameObject pointer;
	public float thickness = 0.002f;
	Transform previousContact = null;

	void Start ()
	{
		// 创建激光发射点
		pointer = GameObject.CreatePrimitive (PrimitiveType.Cube);
		pointer.transform.parent = this.transform;
		pointer.transform.localScale = new Vector3 (thickness, thickness, 100f);
		pointer.transform.localPosition = new Vector3 (0f, 0f, 50f);
		pointer.transform.rotation = new Quaternion (0, 0, 0, 0);

		// 删除激光发射器的碰撞
		BoxCollider collider = pointer.GetComponent<BoxCollider> ();
		GameObject.Destroy (collider);

		if (Enable) {
			pointer.SetActive (true);
		} else {
			pointer.SetActive (false);
		}
	}

	// 开始发射激光
	public void StartEmission ()
	{
		pointer.SetActive (true);
		Enable = true;
	}

	// 停止发射激光
	public void EndEmission ()
	{
		pointer.SetActive (false);
		Enable = false;

		// 当前是否有下一个传递物体，如果有，将停止发射激光事件传递给它
		if (previousContact != null) {
			ReceiveLaser r = previousContact.GetComponent<ReceiveLaser> ();

			if (r != null) {
				r.PointerOut ();
			}

			previousContact = null;
		}
	}

	void Update ()
	{
		// 根据 Enable 来判断是否发射激光
		if (!Enable) {
			return;
		}

		Ray raycast = new Ray (transform.position, transform.forward);

		RaycastHit hit;
		bool bHit = Physics.Raycast (raycast, out hit);

		float dist = 100f;

		// 击中物体并且不等于当前击中物体
		if (bHit && previousContact != hit.transform) {
		
			ReceiveLaser r;

			// 如果原物体不为空，还需要触发原物体的 PointerOut();如果为新物体，则直接触发新物体的 PointerIn()
			if (previousContact != null) {
				r = previousContact.GetComponent<ReceiveLaser> ();
				if (r != null) {
					r.PointerOut ();
				}
			}

			previousContact = hit.transform;
			r = previousContact.GetComponent<ReceiveLaser> ();
			if (r != null) {
				r.PointerIn ();
			}
				
		}

		// 如果没有击中物体，且原来击中了物体，则触发原击中物体的 PointerOut() ，并将 previousContact 置为空
		if (!bHit) {
			
			if (previousContact != null) {
				
				ReceiveLaser r = previousContact.GetComponent<ReceiveLaser> ();
				if (r != null) {
					r.PointerOut ();
				}

				previousContact = null;
			}

		}

		if (bHit && hit.distance < 100f) {
			dist = hit.distance;
		}

		pointer.transform.localScale = new Vector3 (thickness, thickness, dist);
		pointer.transform.localPosition = new Vector3 (0f, 0f, dist / 2f);
	}
}
