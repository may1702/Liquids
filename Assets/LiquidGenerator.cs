using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace uFlex {
	public class LiquidGenerator : MonoBehaviour {

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKeyDown("space")) {
				GameObject liquid = new GameObject("liquid");
				liquid.transform.position = new Vector3(-86.6f, 65.56f, -16f);
				
				int particlesCount = 16 * 16 * 16;

			    FlexParticles part = liquid.AddComponent<FlexParticles>();
			    part.m_particlesCount = particlesCount;
			    part.m_maxParticlesCount = particlesCount;
			    part.m_particles = new Particle[particlesCount];
			    part.m_velocities = new Vector3[particlesCount];
			    part.m_restParticles = new Particle[particlesCount];
			    part.m_smoothedParticles = new Particle[particlesCount];
			    part.m_phases = new int[particlesCount];
			    part.m_particlesActivity = new bool[particlesCount];
			    part.m_densities = new float[particlesCount];
			    part.m_colours = new Color[particlesCount];
			    part.m_colour = Color.blue;
			    part.m_interactionType = FlexInteractionType.Fluid;
			    part.m_collisionGroup = -1;
			    part.m_bounds.SetMinMax(new Vector3(), new Vector3(16 * 1, 16 * 1, 16 * 1));
			    part.m_type = FlexBodyType.Fluid;

			    int i = 0;
			    float invMass = 1.0f / 1;
			    for (int x = 0; x < 16; x++)
			    {
			        for (int y = 0; y < 16; y++)
			        {
			            for (int z = 0; z < 16; z++)
			            {
		
			                part.m_particles[i].pos = new Vector3(x, y, z) * 1;
			                part.m_particles[i].invMass = invMass;
			                //   flexBody.m_colours[i] = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1.0f);
			                part.m_colours[i] = Color.blue;
			                part.m_particlesActivity[i] = true;

			                part.m_restParticles[i] = part.m_particles[i];
			                part.m_smoothedParticles[i] = part.m_particles[i];
			                //part.m_phases[i] = (int)phase;


			                if (0 != 0)
			                    part.m_particles[i].pos += UnityEngine.Random.insideUnitSphere * 0;

			                i++;
			            }
			        }
			    }

				liquid.AddComponent<FlexParticlesRenderer>();
			}
		}
	}
}
