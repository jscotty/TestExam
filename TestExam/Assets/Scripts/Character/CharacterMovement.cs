//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : Character
{

    [SerializeField]
    private float _speed = 200.0f;
    [SerializeField]
    private float _dashSpeed = 250.0f;
    [SerializeField]
    private float _dashCooldownInSeconds = 2.0f;
    [SerializeField]
    private float _dashLengthSeconds = 1.0f;
    [SerializeField]
    private ButtonType _dashButton;
    [SerializeField]
    private AudioClip _dashClip;

    public bool IsDashing { get; private set; }
    public Vector3 Velocity { get; private set; }

    private float _dashCooldown = 0.0f;
    private float _dashCount = 0.0f;
    private bool _isDashCooldown = false;

    private ParticleManager _particleManager;
    private Rigidbody _rigidbody;
    private CharacterAnimationController _animationController;
    private SoundController _soundController;

    void Start()
    {
        _animationController = GetComponent<CharacterAnimationController>();
        _rigidbody = GetComponent<Rigidbody>();
        _soundController = SoundController.Instance;

        _particleManager = ParticleManager.Instance;
    }

    #region Update
    void FixedUpdate()
    {
        if (pIsStunned)
        {
            IsDashing = false;

            _rigidbody.velocity = Vector3.zero;
            return;
        }
        float tSpeed = Time.deltaTime * _speed;
        Velocity = pXboxControllerManager.GetLeftStickAxis(base.pPlayerInformation) * tSpeed;

        if (pXboxControllerManager.GetButtonPressed(base.pPlayerInformation, _dashButton) && !_isDashCooldown && !IsDashing)
        {
            if (_dashClip != null)
            {
                if (_soundController == null) _soundController = SoundController.Instance;
                _soundController.PlaySound(_dashClip, false);
            }
            IsDashing = true;
        }
        if (IsDashing)
            Dash();

        _rigidbody.velocity = Velocity;

        if (Velocity.sqrMagnitude > 0.0f)
        {
            _particleManager.SpawnParticleAssignedToObject(ParticleType.WALK + pPlayerInformation.PlayerID, this.transform);
            transform.forward = Vector3.Normalize(Velocity);
        }
    }

    private void Dash()
    {

        _particleManager.SpawnParticleAssignedToObject(ParticleType.DASH + pPlayerInformation.PlayerID, this.transform);
        //Dash behaviour
        _dashCount += Time.deltaTime;
        if (_dashCount >= _dashLengthSeconds)
        {
            _dashCount = 0.0f;
            IsDashing = false;
            _isDashCooldown = true;
        }

        float tSpeed = Time.deltaTime * _dashSpeed;
        Velocity = transform.forward * tSpeed;
    }

    void Update()
    {
        if (_isDashCooldown)
        {
            base.pIsStunned = false;
            _dashCooldown += Time.deltaTime;
            if (_dashCooldown >= _dashCooldownInSeconds)
            {
                _dashCooldown = 0.0f;
                _isDashCooldown = false;
            }
        }
    }
    #endregion

    void OnCollisionEnter(Collision iCollision)
    {
       // Debug.Log(iCollision.impulse.magnitude);

        Vector3 tHitPosition = transform.position + (transform.forward);

        if (iCollision.impulse.magnitude > 4000)
            iCollision.gameObject.SendMessage("OnHit", tHitPosition, SendMessageOptions.DontRequireReceiver);
        if (!IsDashing)
            return;
        iCollision.gameObject.SendMessage("OnDashHit", iCollision.impulse.magnitude, SendMessageOptions.DontRequireReceiver);
        IsDashing = false;
        _isDashCooldown = true;
    }

    void OnCollisionStay(Collision iCollision)
    {
        if (iCollision.gameObject.GetComponent<Character>() != null)
        {
            if (!IsDashing)
                return;
            iCollision.gameObject.SendMessage("OnDashHit", iCollision.impulse.magnitude, SendMessageOptions.DontRequireReceiver);
            IsDashing = false;
            _isDashCooldown = true;
        }
    }
}
