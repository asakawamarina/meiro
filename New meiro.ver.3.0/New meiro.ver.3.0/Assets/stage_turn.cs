using UnityEngine;
using System.Collections;


public class stage_turn : MonoBehaviour {

	float rotateAngle;
	int rotateSpeed;
	static int kaiten = 0;//0だと止める、1だと左回転、2だと右回転

	void Start () {
		rotateAngle = 360.0f;
		rotateSpeed = 5;

	}

	void Update (){
		//左回転////////////////////////////////
		if (Input.GetKey (KeyCode.Z) && kaiten == 0) {
			kaiten = 1;
		}
		if (kaiten == 1) {
			rotateAngle += 0.5f * rotateSpeed;
			transform.rotation = Quaternion.Euler (0, 0, rotateAngle);
			if (rotateAngle % 90 == 0|| rotateAngle == 0) {
				kaiten = 0;
			}

		//右回転////////////////////////////////
		}if (Input.GetKey (KeyCode.X) && kaiten == 0) {
			kaiten = 2;
		}
		if (kaiten == 2) {
			rotateAngle -= 0.5f * rotateSpeed;
			transform.rotation = Quaternion.Euler (0, 0, rotateAngle);
			if (rotateAngle % 90 == 0 || rotateAngle == 0) {
				kaiten = 0;
			}
		}
	}
}