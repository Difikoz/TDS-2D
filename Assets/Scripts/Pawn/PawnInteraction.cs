using System;
using UnityEngine;

namespace WinterUniverse
{
    public class PawnInteraction : MonoBehaviour
    {
        public Action<Interactable> OnInteractableChanged;

        private PawnController _pawn;
        private Interactable _interactable;
        private RaycastHit2D _hit;

        [SerializeField] private float _interactionDistance = 0.5f;
        [SerializeField] private LayerMask _interactableMask;

        public void Initialize()
        {
            _pawn = GetComponent<PawnController>();
        }

        public void Deinitialize()
        {

        }

        public void OnFixedUpdate()
        {
            _hit = Physics2D.Raycast(transform.position, transform.right, _interactionDistance, _interactableMask);
            if (_hit.collider != null && _hit.collider.TryGetComponent(out Interactable interactable))
            {
                if (interactable != _interactable)
                {
                    _interactable = interactable;
                    OnInteractableChanged?.Invoke(_interactable);
                }
            }
            else if (_interactable != null)
            {
                _interactable = null;
                OnInteractableChanged?.Invoke(null);
            }
        }

        public void PrimaryInteract()
        {
            if (_interactable != null)
            {
                _interactable.PrimaryInteraction(_pawn);
                _interactable = null;
                OnInteractableChanged?.Invoke(null);
            }
        }

        public void SecondaryInteract()
        {
            if (_interactable != null)
            {
                _interactable.SecondaryInteraction(_pawn);
                _interactable = null;
                OnInteractableChanged?.Invoke(null);
            }
        }
    }
}