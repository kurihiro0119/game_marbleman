using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerStyle : Player
{
	GameObject marble;

	const float defaultShotCurve = 0;
	const float defaultShotSpeed = 10.0f;

	float shotSpeed = 0;

	protected override void Shot()
	{
		marble = Instantiate(modelMarble, this.transform.position, this.transform.rotation);
		PlayerShotManager shotmanager = marble.GetComponent<PlayerShotManager>();

		shotSpeed = defaultShotSpeed;

		if (base.ChargeLevel == 1)
		{
			// 特殊技
			Charge1Shot();
		}
		else if (base.ChargeLevel == 2)
		{
			// 必殺技
			Charge2Shot();
		}

		shotmanager.Create(defaultShotCurve, shotSpeed);

		// 発射後処理
		base.AfterShot();
	}

	/// <summary>
	/// 特殊技　締め打ち
	/// </summary>
	void Charge1Shot()
	{
		shotSpeed = defaultShotSpeed * 2;
	}

	/// <summary>
	/// 必殺技　締め打ち2
	/// </summary>
	void Charge2Shot()
	{
		shotSpeed = defaultShotSpeed * 3;
	}
}
