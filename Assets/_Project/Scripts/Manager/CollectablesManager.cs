using System.Collections.Generic;
using _Project.Scripts.Collectables;
using UnityEngine;

namespace _Project.Scripts.Manager
{
	public class CollectablesManager : MonoBehaviour
	{
		[SerializeField] private List<Collectable> _collectables = new List<Collectable>();

		public void OnStart()
		{
			foreach (Collectable collectable in _collectables)
			{
				collectable.OnStart();
			}
		}
	}
}