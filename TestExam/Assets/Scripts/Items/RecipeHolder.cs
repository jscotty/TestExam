using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeHolder : Singleton<RecipeHolder> {

    public List<Recipe> recipeList;

    public Recipe GetRandomRecipe()
    {
        return recipeList[Random.Range(0,recipeList.Count)];
    }
}
