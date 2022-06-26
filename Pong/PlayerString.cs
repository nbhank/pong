using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Pong
{
    public class PlayerString 
    {
        private SpriteBatch spriteBatch;
        private Ball ball;
        private SpriteFont font;
        private string player1Name, player2Name,player1Score,player2Score;
        //public int player1Score, player2Score;
        private Vector2 playerLeftPos, playerRightPos;
        private Vector2 playerScoreLeftPos, playerScoreRightPos, pressSpaceBarPos;




        public PlayerString() 
        {
            ball = new Ball();
            
            playerLeftPos = new Vector2(100, 450);
            playerRightPos = new Vector2(600, 450);
            playerScoreLeftPos = new Vector2(230, 450);
            playerScoreRightPos = new Vector2(680, 450);
            pressSpaceBarPos = new Vector2(335, 460);
            player1Name = "Hoang Quan Tran :" +player1Score ;
            player2Name = "Someone :"+ player2Score;
            
          
        }

        public void LoadContent(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("Font");
        }

        public void Update(GameTime gameTime)
        {
            player1Score = ball.player1Score.ToString();
            player2Score = ball.player2Score.ToString();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
           
            spriteBatch.DrawString(font, player1Name, playerLeftPos, Color.Red);
            spriteBatch.DrawString(font, player2Name, playerRightPos, Color.Red);
           spriteBatch.DrawString(font, player1Score, playerScoreLeftPos, Color.Red);
           spriteBatch.DrawString(font, player2Score, playerScoreRightPos, Color.Red);



        }
    }
}
