using UnityEngine;
using Lncodes.Module.Unity.Helper;

namespace Edu.Golf.View
{
    public sealed class CameraTouchController : MonoBehaviour
    {
        [SerializeField]
        private float _speed = default;

        [SerializeField]
        private float _zoomFactor = default;

        [SerializeField]
        private Boundary<float> _zoomBoundary = default;

        [SerializeField]
        private Boundary<float> _horizontalMoveBoundary = default;

        [SerializeField]
        private Boundary<float> _verticalMoveBoundary = default;

        private Camera _camera = default;

        private Vector3 _touchBeganWorldPos = default;

        private Vector3 _cameraBeganWorldPos = default;

        private float _distance = default;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _distance = transform.position.y;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.touchCount == 0)
                return;

            var touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _touchBeganWorldPos = _camera.ScreenToWorldPoint(
                        new Vector3(touch.position.x, touch.position.y, _distance));
                    _cameraBeganWorldPos = transform.position;
                    break;
                case TouchPhase.Moved:
                    var touchMoveWorldPos = _camera.ScreenToWorldPoint(
                        new Vector3(touch.position.x, touch.position.y, _distance));
                    var delta = touchMoveWorldPos - _touchBeganWorldPos;
                    var targetPos = _cameraBeganWorldPos - delta;
                    targetPos = new Vector3(
                        Mathf.Clamp(targetPos.x, _horizontalMoveBoundary.Min, _horizontalMoveBoundary.Max),
                        _distance,
                        Mathf.Clamp(targetPos.z, _verticalMoveBoundary.Min, _verticalMoveBoundary.Max)
                        );
                    transform.position = Vector3.Lerp(
                        transform.position,
                        targetPos,
                        Time.deltaTime * _speed
                        );
                    break;
            }

            if (Input.touchCount < 2)
                return;

            var touch1 = Input.GetTouch(1);

            if (touch.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
            {
                var touchPrevPos = touch.position - touch.deltaPosition;
                var touch1PrevPos = touch1.position - touch1.deltaPosition;
                var prevDistance = Vector3.Distance(touchPrevPos, touch1PrevPos);
                var currDistance = Vector3.Distance(touch.position, touch1.position);
                var delta = currDistance - prevDistance;
                transform.position -= new Vector3(default, delta * _zoomFactor * Time.deltaTime, default);
                transform.position = new Vector3(
                    transform.position.x,
                    Mathf.Clamp(transform.position.y, _zoomBoundary.Min, _zoomBoundary.Max),
                    transform.position.z
                    );
                _distance = transform.position.y;
            }

        }
    }
}