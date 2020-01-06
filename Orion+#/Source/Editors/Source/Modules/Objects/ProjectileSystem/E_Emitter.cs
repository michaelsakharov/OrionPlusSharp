using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Engine
{

    public class ProjectileBullet
    {
        public Sprite sprite;
        public int x;
        public int y;
        public byte dir;
    }
    public class E_Emitter
    {
        // Public variables
        public string emitterName = "";

        public int picture = 0;
        public int count = 1;
        public int xOffset = 0;
        public int yOffset = 0;
        public int rotationOffset = 0;
        public int range = 1;
        public int speed = 1;
        public int additionalDamage = 0;
        public float startDelay = 0;
        public float startDelayTimer = 0;

        //Internal Emitter Variables
        public List<ProjectileBullet> projectiles;
        
        public virtual void InitializeEmitter() {  }
        public virtual void UpdateParticles() {  }
        public virtual void DrawParticles(RenderWindow gameWindow) { }

        public virtual void ResetEmitter()
        {
            InitializeEmitter();
        }

    }
}
