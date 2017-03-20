//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

namespace Exam.Reference.Path
{
    using System.Collections.Generic;
    public class SpritePaths
    {
        public static readonly Dictionary<SpriteType, string> SpritePath = new Dictionary<SpriteType, string>() {
            { SpriteType.CHARACTER_UNSELECTED, "Sprites/UI_Portrait_CharacterUnselected" },
            { SpriteType.CHARACTER_SELECT_YELLOW, "Sprites/UI_Portrait_CharacterYellow" },
            { SpriteType.CHARACTER_SELECT_RED, "Sprites/UI_Portrait_CharacterRed" },
            { SpriteType.CHARACTER_SELECT_GREEN, "Sprites/UI_Portrait_CharacterGreen" },
            { SpriteType.CHARACTER_SELECT_BLUE, "Sprites/UI_Portrait_CharacterBlue" },
            { SpriteType.BUTTON_A_PRESSED, "Sprites/UI_ButtonContinue_Pressed" },
            { SpriteType.BUTTON_A_RELEASED, "Sprites/UI_ButtonContinue_Released" },
            { SpriteType.BUTTON_B_PRESSED, "Sprites/UI_ButtonBack_Pressed" },
            { SpriteType.BUTTON_B_RELEASED, "Sprites/UI_ButtonBack_Released" },
        };
    }
}

public enum SpriteType {
    CHARACTER_UNSELECTED = 0,
    CHARACTER_SELECT_YELLOW = 1,
    CHARACTER_SELECT_RED = 2,
    CHARACTER_SELECT_GREEN = 3,
    CHARACTER_SELECT_BLUE = 4,
    BUTTON_A_PRESSED = 5,
    BUTTON_A_RELEASED = 6,
    BUTTON_B_PRESSED = 7,
    BUTTON_B_RELEASED = 8,
}