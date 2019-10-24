using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Engine
{

    public class LinearEmitter : E_Emitter
    {

        public override void InitializeEmitter()
        {
            if (!E_Graphics.ProjectileGFXInfo[picture].IsLoaded)
            {
                E_Graphics.LoadTexture(picture, 11);
            }

            int height = frmProjectile.Default.picProjectilePreview.Height;
            int width = frmProjectile.Default.picProjectilePreview.Width;

            projectiles = new List<ProjectileBullet>();
            projectiles.Add(new ProjectileBullet());

            projectiles[0].x = (width / 2) + (int)E_Graphics.ProjectileSprite[picture].Texture.Size.X / 2;
            projectiles[0].y = (height / 2) + (int)E_Graphics.ProjectileSprite[picture].Texture.Size.Y / 2;
            projectiles[0].dir = (byte)frmProjectile.Default.PreviewDirectionDropdown.SelectedIndex;

        }

        public override void UpdateParticles()
        {
         
            if(projectiles == null)
            {
                InitializeEmitter();
            }

            foreach(ProjectileBullet proj in projectiles)
            {
                // Update projectile position
                switch (proj.dir)
                {
                    case (byte)Enums.DirectionType.Up:
                        proj.x += (int)Math.Ceiling(0 * E_Loop.deltaTime);
                        proj.y += (int)Math.Ceiling(speed * E_Loop.deltaTime);
                        break;
                    case (byte)Enums.DirectionType.UpLeft:
                        break;
                    case (byte)Enums.DirectionType.UpRight:
                        break;
                    case (byte)Enums.DirectionType.Down:
                        proj.x += (int)Math.Ceiling(0 * E_Loop.deltaTime);
                        proj.y -= (int)Math.Ceiling(speed * E_Loop.deltaTime);
                        break;
                    case (byte)Enums.DirectionType.DownLeft:
                        break;
                    case (byte)Enums.DirectionType.DownRight:
                        break;
                }

                // Because were in the editor we want to Loop this, So if the projectile is outside the Preview Window (With some extra give) reset its position
                if(proj.x < -32 || proj.x > frmProjectile.Default.picProjectilePreview.Width + 32)
                {
                    if (proj.y < -32 || proj.y > frmProjectile.Default.picProjectilePreview.Height + 32)
                    {
                        proj.x = (frmProjectile.Default.picProjectilePreview.Width / 2) + (int)E_Graphics.ProjectileSprite[picture].Texture.Size.X / 2;
                        proj.y = (frmProjectile.Default.picProjectilePreview.Height / 2) + (int)E_Graphics.ProjectileSprite[picture].Texture.Size.Y / 2;
                    }
                }

            }

        }

        public override void DrawParticles(RenderWindow gameWindow)
        {

            foreach (ProjectileBullet proj in projectiles)
            {
                if (E_Graphics.ProjectileSprite.Count() > 0)
                {
                    if (!E_Graphics.ProjectileGFXInfo[picture].IsLoaded)
                    {
                        E_Graphics.LoadTexture(picture, 11);
                    }

                    E_Graphics.RenderSprite(E_Graphics.ProjectileSprite[picture], gameWindow, proj.x, proj.y,  0, 0, E_Graphics.ProjectileGFXInfo[picture].width, E_Graphics.ProjectileGFXInfo[picture].height);
                }
            }

        }

    }

}