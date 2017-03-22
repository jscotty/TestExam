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
    private CharacterItemController _itemController;
    private XboxControllerManager _xboxController;

    private int _animCount = 0;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<CharacterMovement>();
        _itemController = GetComponentInChildren<CharacterItemController>();
        _xboxController = XboxControllerManager.Instance;
    }

    void Update()
    {
        //TODO: if using anvil/wood do animation
        if (_xboxController.GetButtonPressed(pPlayerInformation, _itemController.InteractButton))
        {
            if (!_itemController.amIHoldingAnItem)
            {
                if (_animCount < 2)
                {
                    SetAnimation(CharacterAnimationState.GRAB);
                    _animCount++;
                    return;
                }
            }
        }
        else
        {
            _animCount = 0;
        }

        if (_movement.IsDashing)
        {
            SetAnimation(CharacterAnimationState.DASH);
            return; // return so no other animation is possible
        }
        else if (_movement.Velocity.magnitude > 0)
        {
            if (_itemController.amIHoldingAnItem)
                SetAnimation(CharacterAnimationState.WALK_HELD_ITEM);
            else
                SetAnimation(CharacterAnimationState.WALK);
        }
        else
        {
            if (_itemController.amIHoldingAnItem)
                SetAnimation(CharacterAnimationState.IDLE_HELD_ITEM);
            else
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
    IDLE_HELD_ITEM = 6,
    GRAB = 7,
}