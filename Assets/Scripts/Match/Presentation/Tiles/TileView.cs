using System;
using Commons.Runtime.Grid;
using Match.Application.Gameplay.Board;
using UnityEngine;

// ReSharper disable Unity.InefficientPropertyAccess

namespace Match.Presentation.Tiles
{
    public class TileView : MonoBehaviour, ITileView
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _dyingAnimationTime;

        private TileViewState _state = TileViewState.Inactive;
        private float _dyingTimePassed;
        private float _tileSize;
        
        public Tile Tile { get; set; }
        public GraphicView GraphicView { get; set; }
        public ITilePoolController PoolController { get; set; }

        public void SetActive(bool isActive)
            => gameObject.SetActive(isActive);

        public void SetState(TileViewState state)
            => _state = state;

        public void SetParent(Transform parent)
            => transform.parent = parent;
        
        public void SetTileSize(float tileSize)
            => _tileSize = tileSize;

        public void SetLocalPosition(GridPosition gridPosition)
        {
            var tilePosition = new Vector3(gridPosition.X, gridPosition.Y);
            var targetPosition = tilePosition * _tileSize;
            transform.localPosition = targetPosition;
        }

        public void Update()
        {
            switch (_state)
            {
                case TileViewState.Inactive:
                    break;
                case TileViewState.Alive:
                    Alive();
                    break;
                case TileViewState.Dying:
                    Dying();
                    break;
                case TileViewState.Dead:
                    Dead();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Alive()
        {
            if (Tile == null || Tile.Destroyed)
            {
                SetState(TileViewState.Dying);
                return;
            }

            _dyingTimePassed = 0;
            
            GraphicView.Fruit.SetActive(true);
            GraphicView.Splash.SetActive(false);
            
            var tilePosition = new Vector3(Tile.GridPosition.X, Tile.GridPosition.Y);
            var targetPosition = tilePosition * _tileSize;
            var currentPosition = transform.localPosition;
            var moveDirection = targetPosition - currentPosition;
            currentPosition += moveDirection * (_moveSpeed * Time.deltaTime);
            transform.localPosition = currentPosition;
        }

        private void Dying()
        {
            GraphicView.Fruit.SetActive(false);
            GraphicView.Splash.SetActive(true);
            _dyingTimePassed += Time.deltaTime;
            if (_dyingTimePassed >= _dyingAnimationTime) 
                SetState(TileViewState.Dead);
        }

        private void Dead()
        {
            SetActive(false);
            PoolController.Return(this);
            Tile = null;
            SetState(TileViewState.Inactive);
        }
    }
}