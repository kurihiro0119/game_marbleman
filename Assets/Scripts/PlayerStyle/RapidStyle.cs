using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidStyle : Player
{
	GameObject marble;

	const float defaultShotCurve = 0;
	const float defaultShotSpeed = 10.0f;

	// 発射速度
	float shotSpeed = 0;
	// 発射回数
	int shotTimes = 0;

	protected override void Shot(){
		shotSpeed = defaultShotSpeed;
		if (base.ChargeLevel == 1){
			// 特殊技
			Charge1Shot();
		}
		else if (base.ChargeLevel == 2)
		{
			// 必殺技
			Charge2Shot();
		}
		else
		{
			// 通常技
			SingleShot();
		}

		// 発射後処理
		base.AfterShot();
	}

	/// <summary>
	/// 単発発射処理
	/// </summary>
	void SingleShot(){
		marble = Instantiate(modelMarble, this.transform.position, this.transform.rotation);
		PlayerShotManager shotmanager = marble.GetComponent<PlayerShotManager>();
		shotmanager.Create(defaultShotCurve, shotSpeed);
	}

	/// <summary>
	/// 特殊技　3連射
	/// </summary>
	void Charge1Shot(){
		shotSpeed = 7.0f;
		shotTimes = 3;
		RapidShot();
	}

	/// <summary>
	/// 必殺技　5連射
	/// </summary>
	void Charge2Shot(){
		shotSpeed = 7.0f;
		shotTimes = 5;
		RapidShot();
	}

	void RapidShot(){
		SingleShot();
		StartCoroutine(WaitTime(0.1f, () =>
		{
			shotTimes--;
			if(shotTimes > 0)
			{
				RapidShot();
			}
		}));
	}

	private IEnumerator WaitTime(float waitTime, Action action)
	{
		yield return new WaitForSeconds(waitTime);
		action();
	}
}
