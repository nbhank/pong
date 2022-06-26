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
    class BatRight
    {
        private SpriteBatch spriteBatch;
        private Texture2D batRightTex;
        private Vector2 speed;
        private Vector2 position;
        private Vector2 stage = new Vector2(800, 600);
        private SoundEffect hitSound;
        private Ball ball;

      
        public BatRight()
        {
            speed = new Vector2(0, 4);
            position = new Vector2(780, 300);
            //position = new Vector2(stage.X - batRightTex.Width, stage.Y / 2 - batRightTex.Height / 2);
            

        }
        public void LoadContent(ContentManager Content)
        {
            batRightTex = Content.Load<Texture2D>("Images/Bat");


            //create the sound effect when the ball hit the left and right wall
            hitSound = Content.Load<SoundEffect>("Music/ding");
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Down))
            {
                position += speed;
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                position -= speed;
            }

            if (position.Y + batRightTex.Height > stage.Y)
            {
                position.Y = stage.Y - batRightTex.Height;
            }

            if (position.Y < 0)
            {
                position.Y = 0;
            }
            

        }

        public void Draw(SpriteBatch spriteBatch)
        {
           
            spriteBatch.Draw(batRightTex, position, Color.White);
            
        }

        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, batRightTex.Width, batRightTex.Height);
        }
    }
}
