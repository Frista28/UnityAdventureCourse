using _22_23.Scripts.Controller;
using _22_23.Scripts.Visuals;
using UnityEngine;

namespace _22_23.Scripts.Application.Commands
{
    public class MoveCommandHandler
    {
        private readonly ClickProcessor _clickProcessor;
        private readonly TargetFollowController _targetFollowController;
        private readonly FlagPlacer _flagPlacer;

        public MoveCommandHandler(ClickProcessor clickProcessor, TargetFollowController targetFollowController, FlagPlacer flagPlacer)
        {
            _clickProcessor = clickProcessor;
            _targetFollowController = targetFollowController;
            _flagPlacer = flagPlacer;
        }

        public void Execute()
        {
            if (_clickProcessor.TryProcessClick(out Vector3 position))
            {
                _targetFollowController.SetTarget(position);
                
                _flagPlacer.PlaceFlag(position);
            }
        }
    }
}