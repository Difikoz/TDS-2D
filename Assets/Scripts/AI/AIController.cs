using UnityEngine;

namespace WinterUniverse
{
    public class AIController : PawnController
    {
        public override void OnFixedUpdate()
        {
            _lookDirection = (WorldManager.StaticInstance.Player.transform.position - transform.position).normalized;
            base.OnFixedUpdate();
        }
    }
}