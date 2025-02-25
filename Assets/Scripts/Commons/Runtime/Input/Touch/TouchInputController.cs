using System;
using Commons.Runtime.Camera;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Commons.Runtime.Input.Touch
{
    public class TouchInputController : ITouchInputController
    {
        public event Action<TouchInputInfo> TouchStart;
        public event Action<TouchInputInfo> TouchMove;
        public event Action<TouchInputInfo> TouchEnd;

        private readonly ICameraAdapter _cameraAdapter;
        private readonly TouchInputActions _actions;
        private readonly InputAction _contact;
        private readonly InputAction _position;

        public TouchInputController(ICameraAdapter cameraAdapter)
        {
            _cameraAdapter = cameraAdapter;
            _actions = new TouchInputActions();
            _contact = _actions.Touch.Contact;
            _position = _actions.Touch.Position;
        }

        public void Enable()
        {
            _actions.Enable();
            _contact.started += ContactStarted;
            _contact.canceled += ContactCanceled;
            _position.performed += PositionPerformed;
        }

        public void Disable()
        {
            _actions.Disable();
            _contact.started -= ContactStarted;
            _contact.canceled -= ContactCanceled;
            _position.performed += PositionPerformed;
        }

        private void PositionPerformed(InputAction.CallbackContext context)
        {
            var screenPosition = _position.ReadValue<Vector2>();
            var touchInputInfo = CreateTouchInputInfo(screenPosition, context.time);
            TouchMove?.Invoke(touchInputInfo);
        }

        private void ContactStarted(InputAction.CallbackContext context)
        {
            var screenPosition = _position.ReadValue<Vector2>();
            var touchInputInfo = CreateTouchInputInfo(screenPosition, context.time);
            TouchStart?.Invoke(touchInputInfo);
        }

        private void ContactCanceled(InputAction.CallbackContext context)
        {
            var screenPosition = _position.ReadValue<Vector2>();
            var touchInputInfo = CreateTouchInputInfo(screenPosition, context.time);
            TouchEnd?.Invoke(touchInputInfo);
        }

        private TouchInputInfo CreateTouchInputInfo(Vector2 screenPosition, double time)
        {
            var screenPositionVector3 = new Vector3(
                screenPosition.x, 
                screenPosition.y,
                _cameraAdapter.NearClipPlane);
            var worldPosition = _cameraAdapter.ScreenToWorldPoint(screenPositionVector3);
            return new TouchInputInfo
            {
                Time = time,
                ScreenPosition = screenPositionVector3,
                WorldPosition = worldPosition
            };
        }
    }
}