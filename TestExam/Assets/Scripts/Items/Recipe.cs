using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Recipe
{
    public Items ItemOne;
    public Items ItemTwo;
    public Items whatItemWillIBecome;

    public bool CheckIfItemsMakeRecipe(ItemBase iItemOne, ItemBase iItemTwo)
    {
        if (iItemOne.whatItemAmI == ItemOne && iItemTwo.whatItemAmI == ItemTwo)
        {
            return true;
        }
        else if (iItemOne.whatItemAmI == ItemTwo && iItemTwo.whatItemAmI == ItemOne)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
