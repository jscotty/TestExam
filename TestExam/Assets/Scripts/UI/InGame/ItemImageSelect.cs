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

    /// <summary>
    /// Sets the images for the recipe
    /// </summary>
    /// <param name="iRecipe"></param>
	public void SetImages(Recipe iRecipe) {
        int tCompleteItem;
        int tMaterial0;
        int tMaterial1;
        if (iRecipe.whatItemWillIBecome == Items.SWORD) {
            tCompleteItem = 0;
            tMaterial0 = 0;
            tMaterial1 = 0;
        }
        else if (iRecipe.whatItemWillIBecome == Items.SHIELD) {
            tCompleteItem = 1;
            tMaterial0 = 0;
            tMaterial1 = 1;
        }
        else {
            tCompleteItem = 2;
            tMaterial0 = 1;
            tMaterial1 = 1;
        }
        _completeItemImage.sprite = _completeItemSprites[tCompleteItem];
        _material0.sprite = _materialSprites[tMaterial0];
        _material1.sprite = _materialSprites[tMaterial1];

        Destroy(this);
    }
}
