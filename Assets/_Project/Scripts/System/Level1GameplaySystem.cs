using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.System
{
    public class Level1GameplaySystem : GameplaySystemBase
    {
        [SerializeField] private List<Crate> _crates = new List<Crate>();
        
        protected override void Start()
        {
            base.Start();
            
            foreach (Crate crate in _crates)
            {
                crate.OnStart();
            }
        }

        protected override void Update()
        {
            base.Update();

            foreach (Crate crate in _crates)
            {
                crate.OnUpdate();
            }
        }
    }
}
