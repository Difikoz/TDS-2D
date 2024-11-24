using TMPro;
using UnityEngine;

namespace WinterUniverse
{
    public class InteractableBarUI : MonoBehaviour
    {
        [SerializeField] private GameObject _bar;
        [SerializeField] private TMP_Text _text;

        public void Initialize()
        {
            _bar.SetActive(false);
            _text.text = string.Empty;
            WorldManager.StaticInstance.Player.PawnInteraction.OnInteractableChanged += OnInteractableChanged;
        }

        public void Deinitialize()
        {
            WorldManager.StaticInstance.Player.PawnInteraction.OnInteractableChanged -= OnInteractableChanged;
        }

        private void OnInteractableChanged(Interactable interactable)
        {
            if (interactable != null)
            {
                _bar.SetActive(true);
                _text.text = interactable.GetText();
            }
            else
            {
                _bar.SetActive(false);
                _text.text = string.Empty;
            }
        }
    }
}