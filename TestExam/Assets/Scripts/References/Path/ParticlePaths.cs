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
            "Particles/Walk",
            "Particles/Walk",
            "Particles/Walk",
            "Particles/Walk",
            "Particles/Stunned",
            "Particles/Stunned",
            "Particles/Stunned",
            "Particles/Stunned",
            "Particles/ObjectFinished",
            "Particles/ObjectVanished",
            "Particles/ObjectCreated",
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
    WALK = 5,
    WALK1 = 6,
    WALK2 = 7,
    WALK3 = 8,
    STUNNED = 9,
    STUNNED1 = 10,
    STUNNED2 = 11,
    STUNNED3 = 12,
    OBJECT_FINISHED = 13,
    OBJECT_VANISHED = 14,
    OBJECT_CREATED = 15,
}