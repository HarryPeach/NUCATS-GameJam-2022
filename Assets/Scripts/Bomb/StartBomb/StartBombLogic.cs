using System;
using Scene;
using UnityEngine;

namespace Bomb.StartBomb
{
	public class StartBombLogic : Explodable
	{
		private void Update()
		{
			// TODO (hpeach): Remove temporary way to detonate first bomb
			if (Input.GetMouseButtonUp(1) && !SceneLogic.UIShown)
			{
				Explode();
			}
		}
	}
}