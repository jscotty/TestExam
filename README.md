# TestExam
Test exam project <br>

Team <br>
<b>Programmers:</b>:<br>
Justin Scott Bieshaar - Lead <br>
Rocky Tempelaars<br>
Nick van Dokkum <br>
<br>
<b>Artists:</b><br>
Noel Karremans - Lead <br>
Mitch Rijkse <br>
Noa van Bentem <br>
Nick Schaatsbergen <br>
Bram Nijland  <br>
<br><br>
<b>Commit conventions</b><br>
Every day commit ( end of the day ) <br>
Commit whenever finished backlog assets <br>
Push finish backlog <br>
Never commit errors! <br>
Merge conflicts, check togetter <br>
(In case of emergency. commit -> push -> leave building) <br> 
<br><br>
<b>Code conventions</b><br>
<br>
<b>Language:</b> English<br>
<b>Code Language:</b> C#<br>
<br>
Class naming using PascalCasing<br>
<br>
<b>Functions/Methods</b><br>	
- Start Uppercased/  PascalCasing.			Example: void MyCoolMethod()<br>
- Group in Region.					Example: #region Calculations #endregion<br>
- Temp variables 					Example tVarname <br>	
- input variables					Examples void Method ( iVarname )<br>
- Readable summaries 					Example triple / generates summary<br>
<br><br>
<b>Variables</b> <br>	
- Private vars	with a _					Example _varname <br>	
- Public vars no extra						Example varname <br>
- Constants uppercase						Example VARNAME / CONST_VARNAME <br>
- Getter declare private set					Example public var {get;private set;} <br>
- Setter declare private get					Example public var {private get; set;} <br>
- Inspector items declared SerializeField			Example [SerializeField] private var; <br>
- Public non serializable variables with HideInInspector	Example [HideInInspector] public var; <br>
- Serializable variables with ToolBox				Example: [Tooltip("Explanation.")] <br>
- camelCasing 							Example: thisIsAVariable; <br>
- Shader properties start With _PascalCasing			Example: _Propertie;<br>
 <br><br>
<b>Namespaces and Regions</b> <br>
- <b>Region names:</b> // all methods with given region name have to be sorted inside the region-endregion <br>
- Calculations // Math <br>
- Update // Update methods <br>
- Location // Uniform shader locations <br>
- Constructor // If more than one constructor <br>
- properties // In data structures group all get/set properties.  <br>
 <br>
- <b>Namespaces:</b> <br>
- Exam.Type.Sub.Sub.Sub.etc <br>
	Example: Exam.References.Tags <br>
	Example: Exam.References.Names <br>
<br><br><br>
Do not forget to auto format your code with 	Monodevelop: http://stackoverflow.com/questions/20915666/shortcut-for-formatting-code-in-monodevelop <br>
Visual Studio: CRTL+ K + D <br>
<br>
Format to <br>
Void Method() <br>
{ <br>
	//code <br>
} <br>
 <br><br>
//@Author name to define you have worked in this class. <br>
 <br>
Use singleton for single use components Example Managers. <br>
http://wiki.unity3d.com/index.php/Singleton <br>
<br><br>
<b>Pipeline:</b><br>
<b>Artists:</b><br>
Textures in standard sizes<br>
2d art in power of 2<br>
Google drive for artists individually.<br>
Commit push art assets for programmers.<br>
<br>
<b>Naming conventions</b><br>
Everything in english<br>
Art naming convention: MainMenu_ButtonStart_Unclicked <br>
<br>
Communication through whatsapp and face-to-face conversations<br>
Communicate if working in same scene's<br>
<br>
<b>texturers en modelers: </b>
Models in .FBX<br>
Textures in .PSD<br>
<br><br>
<b>Programmers</b><br>
Share code through git.<br>
