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
            if (!E_Graphics.ProjectileGFXInfo[picture + 1].IsLoaded)
            {
                E_Graphics.LoadTexture(picture + 1, 11);
            }

            int height = frmProjectile.Default.picProjectilePreview.Height;
            int width = frmProjectile.Default.picProjectilePreview.Width;

            projectiles = new List<ProjectileBullet>();
            projectiles.Add(new ProjectileBullet());


            projectiles[0].x = (width / 2) - (int)E_Graphics.ProjectileSprite[picture + 1].Texture.Size.X / 2 + xOffset;
            projectiles[0].y = (height / 2) - (int)E_Graphics.ProjectileSprite[picture + 1].Texture.Size.Y / 2 + yOffset;
            if (frmProjectile.Default.PreviewDirectionDropdown.SelectedIndex == -1)
            {
                projectiles[0].dir = 0;
            }
            else
            {
                projectiles[0].dir = (byte)frmProjectile.Default.PreviewDirectionDropdown.SelectedIndex;
            }


        }

        public override void UpdateParticles()
        {

            startDelayTimer += E_Loop.deltaTime; // Increase Timers
            if(startDelayTimer < startDelay)
            {
                return;
            }

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
                        proj.y -= (int)Math.Ceiling(speed * E_Loop.deltaTime);
                        E_Graphics.ProjectileSprite[picture + 1].Rotation = rotationOffset;
                        break;
                    case (byte)Enums.DirectionType.Down:
                        proj.y += (int)Math.Ceiling(speed * E_Loop.deltaTime);
                        E_Graphics.ProjectileSprite[picture + 1].Rotation = 180 + rotationOffset;
                        break;
                    case (byte)Enums.DirectionType.Left:
                        proj.x -= (int)Math.Ceiling(speed * E_Loop.deltaTime);
                        E_Graphics.ProjectileSprite[picture + 1].Rotation = -90 + rotationOffset;
                        break;
                    case (byte)Enums.DirectionType.Right:
                        proj.x += (int)Math.Ceiling(speed * E_Loop.deltaTime);
                        E_Graphics.ProjectileSprite[picture + 1].Rotation = 90 + rotationOffset;
                        break;
                    // 8 directional not implemented!
                    case (byte)Enums.DirectionType.UpLeft:
                        E_Graphics.ProjectileSprite[picture + 1].Rotation = rotationOffset;
                        break;
                    case (byte)Enums.DirectionType.UpRight:
                        E_Graphics.ProjectileSprite[picture + 1].Rotation = rotationOffset;
                        break;
                    case (byte)Enums.DirectionType.DownLeft:
                        E_Graphics.ProjectileSprite[picture + 1].Rotation = rotationOffset;
                        break;
                    case (byte)Enums.DirectionType.DownRight:
                        E_Graphics.ProjectileSprite[picture + 1].Rotation = rotationOffset;
                        break;
                }

                // Because were in the editor we want to Loop this, So if the projectile is outside the Preview Window (With some extra give) reset its position
                if ((proj.x < -32 || proj.x > frmProjectile.Default.picProjectilePreview.Width + 32) || proj.y < -32 || proj.y > frmProjectile.Default.picProjectilePreview.Height + 32)
                {
                    proj.x = (frmProjectile.Default.picProjectilePreview.Width / 2) - (int)E_Graphics.ProjectileSprite[picture + 1].Texture.Size.X / 2 + xOffset;
                    proj.y = (frmProjectile.Default.picProjectilePreview.Height / 2) - (int)E_Graphics.ProjectileSprite[picture + 1].Texture.Size.Y / 2 + yOffset;
                }

            }

        }

        public override void DrawParticles(RenderWindow gameWindow)
        {

            foreach (ProjectileBullet proj in projectiles)
            {
                if (E_Graphics.ProjectileSprite.Count() > 0)
                {
                    if (!E_Graphics.ProjectileGFXInfo[picture + 1].IsLoaded)
                    {
                        E_Graphics.LoadTexture(picture + 1, 11);
                    }
                    E_Graphics.RenderSprite(E_Graphics.ProjectileSprite[picture + 1], gameWindow, proj.x, proj.y,  0, 0, E_Graphics.ProjectileGFXInfo[picture + 1].width, E_Graphics.ProjectileGFXInfo[picture + 1].height);
                }
            }

        }

    }

}