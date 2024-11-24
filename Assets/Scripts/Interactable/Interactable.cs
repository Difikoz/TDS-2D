using UnityEngine;

namespace WinterUniverse
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] private Transform _interactionPoint;

        public Transform InteractionPoint => _interactionPoint;

        public abstract string GetText();
        public abstract void Interact(PawnController pawn);
    }
}