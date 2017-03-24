//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Exam.Reference.Path;
using UnityEngine.SceneManagement;

public class ParticleManager : Singleton<ParticleManager>
{

    private Dictionary<ParticleType, ParticleInformation> _particleReference = new Dictionary<ParticleType, ParticleInformation>();
    private int[] _ticks;
    private List<ParticleInformation> _particles = new List<ParticleInformation>();

    /// <summary>
    /// Start Initialization
    /// </summary>
    private void Start()
    {
        Init();
        SceneManager.sceneLoaded += SceneSwitched;
    }

    void SceneSwitched(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("EEEEEE WHAHAHAHAHAH");
        Init();
    }

    /// <summary>
    /// Initialization
    /// </summary>
    private void Init()
    {
        _particles.Clear();
        _particleReference.Clear();

        string[] tParticlePaths = ParticlePaths.PARTICLES;
        for (int i = 0; i < tParticlePaths.Length; i++)
        {
            GameObject tParticle = (GameObject)Resources.Load(tParticlePaths[i]);

            if (tParticle == null) Debug.LogError("Could not find Particle prefab of: " + tParticlePaths[i]);
            else
            {
                _particleReference.Add(ParticleType.DASH + i, new ParticleInformation(tParticle));
            }
        }
        _ticks = new int[tParticlePaths.Length];
    }

    void Update()
    {
        for (int i = 0; i < _particleReference.Count; i++)
        {
            ParticleInformation tParticleInformation = _particleReference[ParticleType.DASH + i];
            if (_ticks[i] > tParticleInformation.Tick)
            {
                Reset(ParticleType.DASH + i);
                _ticks[i] = 0;
            }
            if (tParticleInformation.Tick != 0)
                _ticks[i]++;
        }
        for (int i = 0; i < _particles.Count; i++)
        {
            if (_particles[i].IsDestroyable)
            {
                if (!_particles[i].ParticleSystem.IsAlive())
                {
                    _particles[i].Remove();
                    _particles.Remove(_particles[i]);
                }
            }
        }
    }

    /// <summary>
    /// Reset the specified particle.
    /// </summary>
    /// <param name="iParticleType">I particle type.</param>
    public void Reset(ParticleType iParticleType)
    {
        _particleReference[iParticleType].Reset();
    }

    #region spawners
    /// <summary>
    /// Spawn particles
    /// </summary>
    /// <param name="iParticleType">In particle type.</param>
    /// <param name="iPosition">In particle position.</param>
    public void SpawnParticle(ParticleType iParticleType, Vector3 iPosition, bool iIsDestroyable = false)
    {
        if (iIsDestroyable)
        {
            ParticleInformation tParticleInformation = GenerateDestroyableParticle(iParticleType);
            tParticleInformation.SetParticlePosition(iPosition);
        }
        else
        {
            _particleReference[iParticleType].SetParticlePosition(iPosition);
        }
    }

    /// <summary>
    /// Spawn particles
    /// </summary>
    /// <param name="iParticleType">In particle type.</param>
    /// <param name="iPosition">In particle position.</param>
    public void SpawnParticle(ParticleType iParticleType, Vector3 iPosition, Quaternion iRotation, bool iIsDestroyable = false)
    {
        if (iIsDestroyable)
        {
            ParticleInformation tParticleInformation = GenerateDestroyableParticle(iParticleType);
            tParticleInformation.SetParticlePosition(iPosition);
        }
        else
        {
            _particleReference[iParticleType].SetParticlePosition(iPosition);
        }
    }

    /// <summary>
    /// Spawn particles
    /// </summary>
    /// <param name="iParticleType">In particle type.</param>
    /// <param name="iPosition">In particle position.</param>
    public void SpawnParticle(ParticleType iParticleType, Vector3 iPosition, Vector3 iLocalRotation, bool iIsDestroyable = false)
    {
        if (iIsDestroyable)
        {
            ParticleInformation tParticleInformation = GenerateDestroyableParticle(iParticleType);
            tParticleInformation.SetParticlePosition(iPosition);
        }
        else
        {
            _particleReference[iParticleType].SetParticlePosition(iPosition);
        }
    }

    /// <summary>
    /// Spawns the particle assigned to object.
    /// </summary>
    /// <param name="iParticleType">I particle type.</param>
    /// <param name="iTransform">I transform.</param>
    public void SpawnParticleAssignedToObject(ParticleType iParticleType, Transform iTransform, bool iIsDestroyable = false)
    {

        if (iIsDestroyable)
        {
            ParticleInformation tParticleInformation = GenerateDestroyableParticle(iParticleType);
            tParticleInformation.SetParticleParent(iTransform, iTransform.localRotation.eulerAngles);
        }
        else
        {
            _particleReference[iParticleType].SetParticleParent(iTransform, iTransform.localRotation.eulerAngles);
        }

    }
    #endregion

    private ParticleInformation GenerateDestroyableParticle(ParticleType iParticleType)
    {
        GameObject tParticle = (GameObject)Resources.Load(ParticlePaths.PARTICLES[(int)iParticleType]);

        if (tParticle == null) Debug.LogError("Could not find Particle prefab of: " + iParticleType);
        else
        {
            ParticleInformation tParticleInformation = new ParticleInformation(tParticle);
            tParticleInformation.IsDestroyable = true;
            _particles.Add(tParticleInformation);
            return tParticleInformation;
        }
        return null;
    }
}