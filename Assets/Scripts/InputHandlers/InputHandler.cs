using UnityEngine;
using GuruCaseOne.Interfaces;
using GuruCaseOne.Utilities;

namespace GuruCaseOne.InputHandlers
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask _interactableLayer = 0;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                IInteractable tempInteract = PhysicUtility.GetInteractableOnRayPoint<IInteractable>(Input.mousePosition, _interactableLayer);
                if (tempInteract != null)
                {
                    tempInteract.Interact();
                }
            }
        }
    }
}