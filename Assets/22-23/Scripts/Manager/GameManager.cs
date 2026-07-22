using _22_23.Scripts.Application.Commands;
using _22_23.Scripts.Character;
using _22_23.Scripts.Controller;
using _22_23.Scripts.Controller.PointProviders;
using _22_23.Scripts.Controller.PointValidators;
using _22_23.Scripts.Interfaces.Click;
using _22_23.Scripts.Visuals;
using UnityEngine;

namespace _22_23.Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private InputHandler _inputHandler;
        
        [SerializeField] private FlagPlacer _flagPlacer;
        
        [SerializeField] private PlayerAgentCharacter _playerAgentCharacter;

        private void Awake()
        {
            IPointProvider pointProvider = new CameraRaycastPointProvider(Camera.main);
            IPointValidator pointValidator = new NavMeshValidator(_playerAgentCharacter.GetNavMeshQueryFilter());
            
            ClickProcessor clickProcessor = new ClickProcessor(pointProvider, pointValidator);
            
            TargetFollowController targetFollowController = new TargetFollowController(_playerAgentCharacter);
            
            MoveCommandHandler moveCommandHandler = new MoveCommandHandler(clickProcessor, targetFollowController, _flagPlacer);
            
            _inputHandler.Initialize(moveCommandHandler);
        }

        
    }
}