using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace uFlex {
	public class LiquidGenerator : MonoBehaviour {
        GameObject Syringe;

        // Use this for initialization
        void Start () {
            Syringe = GameObject.Find("free_injector_FBX");
		}

        int count = 0;
        bool shouldSpawn = true;
        // Update is called once per frame
        void Update () {
            int dimX = 1;
            int dimY = 1;
            int dimZ = 1;

            if (count > 1)
            {
                count = 0;
                shouldSpawn = true;
            }

			if (shouldSpawn && Input.GetKey(KeyCode.L)) {
                GameObject liquid = new GameObject("liquid");
                liquid.SetActive(false);
                liquid.transform.position = new Vector3(Syringe.transform.position.x - 0.5f, Syringe.transform.position.y, Syringe.transform.position.z + 10f);

                int particlesCount = dimX * dimY * dimZ;

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
                part.m_bounds.SetMinMax(new Vector3(), new Vector3(dimX * 1, dimY * 1, dimZ * 1));
                part.m_type = FlexBodyType.Fluid;

                part.m_initialVelocity = new Vector3(0f, 0f, 12f);
                part.m_collisionGroup = 1;

                int i = 0;
                float invMass = 1.0f / 1;
                for (int x = 0; x < dimX; x++)
                {
                    for (int y = 0; y < dimY; y++)
                    {
                        for (int z = 0; z < dimZ; z++)
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
                liquid.GetComponent<FlexParticlesRenderer>().m_size = 2;
                liquid.GetComponent<FlexParticlesRenderer>().m_radius = 2;
                //liquid.GetComponent<FlexParticlesRenderer>().m_minDensity = 0.01f;
                //liquid.GetComponent<FlexParticlesRenderer>().m_showDensity = true;
                shouldSpawn = false;

                liquid.SetActive(true);
            }

            count++;
		}
	}
}
