using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Pong
{
    public class Ball
    {
        private SpriteBatch spriteBatch;
        private Texture2D ballTex;
        public Vector2 position;
        public Vector2 speed;

        private Vector2 stage;

        private SoundEffect hitSound;
        private SoundEffect missSound;

        public int player1Score = 0;
        public int player2Score = 0;
        private bool positionChange = false;
        Vector2 ballPos;

       // PlayerString playerString = new PlayerString();
        private Random r = new Random();

       
        public Ball()
        {
            ballTex = null;
            stage = new Vector2(800, 600);
            //position = new Vector2(stage.X / 2 - ballTex.Width / 2, stage.Y / 2 - ballTex.Height / 2);
            speed = new Vector2(5, -5);
            
            
        }
        public void LoadContent(ContentManager Content)
        {
            ballTex = Content.Load<Texture2D>("Images/Ball");
            
            //create the sound when the ball was hited by the bat
            hitSound = Content.Load<SoundEffect>("Music/click");

            //create the sound when the player miss the ball
            missSound = Content.Load<SoundEffect>("Music/applause1");
        }
        public void initial()
        {
            position = new Vector2(400 - ballTex.Width / 2, 300 - ballTex.Height / 2);
            
            int random1 = r.Next(3, 9);
            int random2 = r.Next(3, 9);

            if(random1 == 2)
            {
                random2 = -random2;
            }
            if (random2 == 2)
            {
                random1 = -random1;
            }
            speed = new Vector2(random1, random2);
        }

        public void Update(GameTime gameTime)
        {
            if (positionChange)
            {
                position += speed;
            }
            
            //top wall
            if (position.Y <= 0)
            {
                speed.Y = Math.Abs(speed.Y);
                hitSound.Play();
            }
            //right wall
            if (position.X + ballTex.Width >= stage.X)
            {
                missSound.Play();
                positionChange = false;
                player1Score += 1;
                initial();
                //add player1 1 score
            }

            //left wall
            if (position.X < 0)
            {
                missSound.Play();
                positionChange = false;
                //add player2 1 score
//playerString.player1Score++;
                player2Score+=1;
                initial();
            }

            //bottom wall
            if (position.Y + ballTex.Height >= stage.Y)
            {
                speed.Y = -Math.Abs(speed.Y);
                hitSound.Play();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !positionChange)
            {
                //this.Enabled = true;
                positionChange = true;
                ballPos = new Vector2(stage.X / 2 - ballTex.Width / 2,stage.Y / 2 - ballTex.Height / 2);
                Vector2 ballSpeed = new Vector2(5, -5);

                position = ballPos;
                speed = ballSpeed;
                initial();
            }
            //base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(ballTex, position, Color.White);
           
            
        }

        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, ballTex.Width, ballTex.Height);
        }
    }
}
