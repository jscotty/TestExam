using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemImageSelect : MonoBehaviour {

    [SerializeField] private List<Sprite> _completeItemSprites = new List<Sprite>();
    [SerializeField] private List<Sprite> _materialSprites = new List<Sprite>();
    [SerializeField] private Image _completeItemImage;
    [SerializeField] private Image _material0;
    [SerializeField] private Image _material1;

	public void SetImages(Recipe iRecipe) {
        if (iRecipe.whatItemWillIBecome == Items.sword) {
            _completeItemImage.sprite = _completeItemSprites[0];
            _material0.sprite = _materialSprites[0];
            _material1.sprite = _materialSprites[0];
        }
        else if (iRecipe.whatItemWillIBecome == Items.shield) {
            _completeItemImage.sprite = _completeItemSprites[1];
            _material0.sprite = _materialSprites[0];
            _material1.sprite = _materialSprites[1];
        }
        else if (iRecipe.whatItemWillIBecome == Items.bow) {
            _completeItemImage.sprite = _completeItemSprites[2];
            _material0.sprite = _materialSprites[1];
            _material1.sprite = _materialSprites[1];
        }
    }
}
