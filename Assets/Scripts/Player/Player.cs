using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _leftXBorderCoordinate, _rightXBorderCoordinate;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private CubeHolder _cubeHolder;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private EffectPlayer _effectPlayer;
    [SerializeField] private CubeIncrementDisplayer _cubeIncrementDisplayer;

    private PlayerInput _playerInput;
    private float _slideDirection;

    public event UnityAction GameOver;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void Update()
    {
        _slideDirection = _playerInput.Player.Move.ReadValue<float>();

        Move(_slideDirection, _moveSpeed);
    }

    private void OnEnable()
    {
        _playerInput.Enable();

        _cubeHolder.StickmanDied += Die;
        _cubeHolder.AmountOfCubesChanged += _playerAnimator.StartJumpAnimation;
        _cubeHolder.AmountOfCubesChanged += _effectPlayer.StartCubeAddedParticlesl;
        _cubeHolder.AmountOfCubesChanged += _cubeIncrementDisplayer.DisplayIncrement;
    }

    private void OnDisable()
    {
        _playerInput.Disable();

        _cubeHolder.StickmanDied -= Die;
        _cubeHolder.AmountOfCubesChanged -= _playerAnimator.StartJumpAnimation;
        _cubeHolder.AmountOfCubesChanged -= _effectPlayer.StartCubeAddedParticlesl;
        _cubeHolder.AmountOfCubesChanged -= _cubeIncrementDisplayer.DisplayIncrement;
    }

    public void Die() => GameOver?.Invoke();

    public void ResetPosition() => transform.position = Vector3.zero;

    private void Move(float direction, float moveSpeed)
    {
        Vector3 move = new Vector3(direction,0, moveSpeed);

        if (TryMoveHorizontally(move,_leftXBorderCoordinate,_rightXBorderCoordinate))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
            return;
        }

        transform.position += move * Time.deltaTime;
    }

    private bool TryMoveHorizontally(Vector3 move, float leftBorderXCoordinate, float rightBorderXCoordinate)
    {
        float currentXCoordinate = transform.position.x;
        float targetPostion = currentXCoordinate += (move.x * Time.deltaTime);
        return targetPostion < leftBorderXCoordinate || targetPostion > rightBorderXCoordinate;
    }
}
