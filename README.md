# TestExam
Test exam project by<br>

<b>Code conventions</b>

<b>Language:</b> English<br>
<b>Code Language:</b> C#<br>
<br>
<b>Functions</b> <br>	
<b>/Methods</b>	- Start Hoofdletter/<br>
  PascalCasing.		Example: void MyCoolMethod()<br>
	- Group in Region.		Example: #region Calculations #endregion<br>
		- Temp variables 		Example tVarname <br>	
		- input variables		Examples void Method ( iVarname )<br>
		- Readable summaries 	Example triple / generates summary<br>

Variables 	
- Private vars	with a _	Example _varname <br>	
		- Public vars no extra		Example varname <br>
		- Constants uppercase	Example VARNAME / CONST_VARNAME <br>
- Getter declare private set	Example public var {get;private set;} <br>
- Setter declare private get	Example public var {private get; set;} <br>
- Inspector items declared <br>
  SerializeField		Example [SerializeField] private var; <br>
- Public non serializable <br>
  Variables with  <br>
  HideInInspector		Example [HideInInspector] public var; <br>
- Serializable variables <br>
  With ToolBox			Example: [Tooltip("Explanation.")] <br>
- camelCasing 		Example: thisIsAVariable; <br>
 <br>
Namespaces and Regions <br>
		- Region names: // all methods with given region name have to be  <br>
sorted inside the region-endregion <br>
			- Calculations // Math <br>
			- Update // Update methods <br>
- Location // Uniform shader locations <br>
- Constructor // If more than one constructor <br>
- properties // In data structures group all get/set properties.  <br>
 <br>
		- Namespaces <br>
			- Exam.Type.Sub.Sub.Sub.etc <br>
				Example: Exam.References.Tags <br>
				Example: Exam.References.Names <br>

Do not forget to auto format your code with 	Monodevelop: http://stackoverflow.com/questions/20915666/shortcut-for-formatting-code-in-monodevelop <br>
							Visual Studio: CRTL+ K + D <br>
Format to <br>
Void Method() <br>
{ <br>
	//code <br>
} <br>
 <br>
//@Author name to define you have worked in this class. <br>
 <br>
Use singleton for single use components Example Managers. <br>
http://wiki.unity3d.com/index.php/Singleton <br>
