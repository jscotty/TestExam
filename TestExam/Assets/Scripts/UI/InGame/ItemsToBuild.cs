using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsToBuild : MonoBehaviour {

    [SerializeField]
    private GameObject _itemUIPrefab;
    private List<GameObject> _currentRecipes = new List<GameObject>();
    private RecipeHolder _recipeHolder;
    private List<Items> _currentItems = new List<Items>();
    [SerializeField]
    private Scores _scores;

    private void Awake() {
        _recipeHolder = RecipeHolder.Instance;
    }

    private void Start() {
        CreateRecipe();
        StartCoroutine(WaitBeforeRecipe(16));
        StartCoroutine(WaitBeforeRecipe(61));
    }

    /// <summary>
    /// Creates a delay before creating a recipe
    /// </summary>
    /// <param name="iSecondsToWait"></param>
    /// <returns></returns>
    IEnumerator WaitBeforeRecipe(int iSecondsToWait) {
        yield return new WaitForSeconds(iSecondsToWait);
        CreateRecipe();
    }

#if UNITY_EDITOR
    private void Update() {
        if (Input.GetKeyDown(KeyCode.L)) {
            Debug.Log(CanHandInItem(Items.BOW));
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            Debug.Log(CanHandInItem(Items.SHIELD));
        }
        if (Input.GetKeyDown(KeyCode.J)) {
            Debug.Log(CanHandInItem(Items.SWORD));
        }
    }
#endif
    /// <summary>
    /// Creates a recipe and instantiates a prefab to show which item has to be made
    /// </summary>
    public void CreateRecipe() {
        if (_scores.CurrentScore < _scores.MaxScore - _currentRecipes.Count) {
            Recipe tRecipe = _recipeHolder.GetRandomRecipe();
            GameObject tItemUI = Instantiate(_itemUIPrefab, this.transform, false);

            tItemUI.GetComponent<ItemImageSelect>().SetImages(tRecipe);
            _currentRecipes.Add(tItemUI);
            _currentItems.Add(tRecipe.whatItemWillIBecome);
        }
    }

    /// <summary>
    /// Returns if an item can be handed in. If it can it will do background calculations and remove the prefab showing the recipe
    /// </summary>
    /// <param name="iItem"></param>
    /// <returns></returns>
    public bool CanHandInItem(Items iItem) {
        for (int i = 0; i < _currentItems.Count; i++) {
            if (_currentItems[i] == iItem) {
                GameObject tRecipe = _currentRecipes[i];
                _currentRecipes.RemoveAt(i);
                Destroy(tRecipe);
                _currentItems.RemoveAt(i);
                _scores.FinishedItem();
                StartCoroutine(WaitBeforeRecipe(5));
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Stops all coroutines when the object gets disabled
    /// </summary>
    private void OnDisable() {
        StopAllCoroutines();
    }
}
