using TMPro;
using UnityEngine;

namespace WinterUniverse
{
    public class InteractableBarUI : MonoBehaviour
    {
        [SerializeField] private GameObject _bar;
        [SerializeField] private TMP_Text _text;

        private void Start()
        {
            _bar.SetActive(false);
            _text.text = string.Empty;
            FindFirstObjectByType<PlayerController>().PawnInteraction.OnInteractableChanged += OnInteractableChanged;
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