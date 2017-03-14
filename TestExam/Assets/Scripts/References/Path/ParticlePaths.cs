//@Author Justin Scott Bieshaar.
                                                                                            //For further questions please read comments or reach me via mail contact@justinbieshaar.com

namespace Exam.Reference.Path{
	public class ParticlePaths {
		/// <summary>
		/// Particle paths stored in ./Resources/ 
		/// </summary>
		public static readonly string[] PARTICLES = { //initialize particle paths
			"Particles/Dash",
			"Particles/Dash",
			"Particles/Dash",
			"Particles/Dash",
			"Particles/Dash_Hit_Wall",
		};
	}
}
/// <summary>
/// Particle type stored for reference and readability.
/// </summary>
public enum ParticleType
{
    DASH = 0,
    DASH1 = 1,
    DASH2 = 2,
    DASH3 = 3,
    DASH_HIT_WALL = 4,
}