using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Pong
{
    public class BatLeft
    {
        private SpriteBatch spriteBatch;
        private Texture2D batLeftTex;
        private Vector2 speed;
        private Vector2 position;
        private Vector2 stage;
        private SoundEffect hitSound;



       
        public BatLeft()
        {
            stage = new Vector2(800, 600);
            speed = new Vector2(0, 4);
            position = new Vector2(-5,300);
           //position = new Vector2(0, stage.Y / 2 - batLeftTex.Height / 2);
            
        }

        public void LoadContent(ContentManager Content)
        {
            batLeftTex = Content.Load<Texture2D>("Images/Bat");

           
            //create the sound effect when the ball hit the left and right wall
            hitSound = Content.Load<SoundEffect>("Music/ding");
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Z))
            {
                position += speed;
            }
            if (ks.IsKeyDown(Keys.A))
            {
                position -= speed;
            }

            if (position.Y + batLeftTex.Height > stage.Y)
            {
                position.Y = stage.Y- batLeftTex.Height;
            }

            if (position.Y < 0)
            {
                position.Y = 0;
            }

            
            
        }
        

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(batLeftTex, position, Color.White);
          
            
        }

        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, batLeftTex.Width, batLeftTex.Height);
        }
    }
}
