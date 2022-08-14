using UnityEngine;
using GuruCaseOne.Interfaces;
using GuruCaseOne.Utilities;
using GuruCaseOne.Entities.Tiles;
using GuruCaseOne.Entities.MatchSystem;

namespace GuruCaseOne.InputHandlers
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask _interactableLayer = 0;

        private MatchDetector _matchDetector;

        private void Awake()
        {
            _matchDetector = new MatchDetector();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                IInteractable tempInteract = PhysicUtility.GetInteractableOnRayPoint<IInteractable>(Input.mousePosition, _interactableLayer);
                TileMono tempTileMono = PhysicUtility.GetInteractableOnRayPoint<TileMono>(Input.mousePosition, _interactableLayer);
                if (tempInteract != null)
                {
                    tempInteract.Interact(tempTileMono, _matchDetector.CheckPossibleMatch);
                }
            }
        }
    }
}