//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimationController : Character
{
    private const string ANIMATION_STATE_REFERENCE = "AnimationState";

    private Animator _animator;
    private CharacterMovement _movement;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        //TODO: if using anvil/wood do animation
        if (_movement.IsDashing)
        {
            SetAnimation(CharacterAnimationState.DASH);
            return; // return so no other animation is possible
        }
        else if (_movement.Velocity.magnitude > 0)
        {
            //TODO:if item held walk held item!
            SetAnimation(CharacterAnimationState.WALK);
        }
        else
        {
            //TODO:if item held, idle held item!
            SetAnimation(CharacterAnimationState.IDLE);
        }
    }

    /// <summary>
    /// Sets animation state of current character.
    /// </summary>
    /// <param name="iState"></param>
    public void SetAnimation(CharacterAnimationState iState)
    {
        _animator.SetInteger(ANIMATION_STATE_REFERENCE, (int)iState);
    }

}

public enum CharacterAnimationState
{
    IDLE = 0,
    WALK = 1,
    WALK_HELD_ITEM = 2,
    DASH = 3,
    HIT_ANVIL = 4,
    HIT_WOOD = 5,
}