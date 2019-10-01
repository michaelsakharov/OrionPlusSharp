using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Engine
{
    public class E_ProjectileSystem
    {

        public List<E_Emitter> emitters;

        Enums.DirectionType direction;

        public void InitializeParticleSystem()
        {
            emitters = new List<E_Emitter>();
        }
        
        public void Update(RenderWindow gameWindow = null)
        {
            UpdateEmitters();
            if (gameWindow != null)
            {
                DrawEmitters(gameWindow);
            }
            else
            {
                // Default DrawWindow
            }
        }

        public void UpdateEmitters()
        {
            if(emitters.Count > 0)
            {
                foreach(E_Emitter emitter in emitters)
                {
                    emitter.UpdateParticles();
                }
            }
        }

        public void DrawEmitters(RenderWindow gameWindow)
        {
            if (emitters.Count > 0)
            {
                foreach (E_Emitter emitter in emitters)
                {
                    emitter.DrawParticles(gameWindow);
                }
            }
        }
    }
}
