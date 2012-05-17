using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace SpyRun
{
    /// <summary>
    /// Rewards Class
    ///Display rewards and power capsules (battery) along the hills
    /// 03/29/2012
    /// </summary>
    class Rewards
    {
       
        private Texture2D spriteSheet;
        private int rewardType;
        private float velocity;

        private Hills hills;

        public Sprite goldSprite;
        public Sprite batterySprite;
        public Sprite sawSprite;
        public List<Sprite> rewardsList = new List<Sprite>();

        
        private Random rand;
        public double rewardtime = 3;

        private int goldBarSpriteOffset;
        private int goldBarFrameCount;
        private int goldBarFrameIndex;
        private int goldBarFrameWidth;
        private int goldBarFrameHeight;
        private int goldBarRadius;
        private int batterySpriteOffset;
        private int batteryFrameCount;
        private int batteryFrameIndex;
        private int batteryFrameWidth;
        private int batteryFrameHeight;
        private int batteryRadius;
        private int sawSpriteOffset;
        private int sawFrameCount;
        private int sawFrameIndex;
        private int sawFrameWidth;
        private int sawFrameHeight;
        private int sawRadius;


        public int goldValue = 25;
        public int batteryValue = 50;
        private Texture2D texture;
        private int removeIndex;

        public Rewards(Texture2D texture, float number, Hills hills)
        {
            spriteSheet = texture;
            velocity = number;
            this.hills = hills;
            this.texture = texture;

            rand = new Random();

            goldBarSpriteOffset = 562;
            goldBarFrameCount = 2;
            goldBarFrameIndex = 0;
            goldBarFrameWidth = 174;
            goldBarFrameHeight = 91;
            goldBarRadius = 43;

            batterySpriteOffset = 484;
            batteryFrameCount = 4;
            batteryFrameIndex = 0;
            batteryFrameWidth = 74;
            batteryFrameHeight = 61;
            batteryRadius = 20;

            sawSpriteOffset = 660;
            sawFrameCount = 3;
            sawFrameIndex = 0;
            sawFrameWidth = 179;
            sawFrameHeight = 64;
            sawRadius = 20;

        }


        public int RewardType
        {
            get { return rewardType; }
            set { rewardType = value; }
        }

        public float Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public void generateReward()
        {

            int checkLocation = rand.Next(0, hills.pixelCount);

            
            if (hills.HillsPixels[checkLocation].Location.X > 790.0f)
            {
                rewardType = rand.Next(0, 4);
                //rewardType = 2;//bd test
                switch (rewardType)
                {
                    case 0:
                        //generate a gold bar pile
                        goldSprite = new Sprite(
                        new Vector2(500, 400),
                        texture,
                        new Rectangle(0, goldBarSpriteOffset, goldBarFrameWidth, goldBarFrameHeight),
                        Vector2.Zero);

                        for (int x = 1; x < goldBarFrameCount; x++)
                        {
                            goldSprite.AddFrame(
                                new Rectangle(
                                    goldBarFrameIndex + (goldBarFrameWidth * x),
                                    goldBarSpriteOffset,
                                    goldBarFrameWidth,
                                    goldBarFrameHeight));
                        }

                        goldSprite.Scale = 0.5f;

                        goldSprite.HillIndex = checkLocation;

                        goldSprite.Location.X = hills.HillsPixels[goldSprite.HillIndex].Location.X - (goldBarFrameWidth / 2);

                        goldSprite.Location.Y = hills.HillsPixels[goldSprite.HillIndex].Location.Y - (goldBarFrameHeight / 2) - 20.0f;

                        goldSprite.Rotation = (float)Math.Atan(hills.getSlope((int)goldSprite.Location.X));

                        goldSprite.CollisionRadius = goldBarRadius;

                        rewardsList.Add(goldSprite);
                      
                        break;

                    case 1:

                        //generate a battery power pod
                        batterySprite = new Sprite(
                        new Vector2(500, 400),
                        texture,
                        new Rectangle(0, batterySpriteOffset, batteryFrameWidth, batteryFrameHeight),
                        Vector2.Zero);

                        for (int x = 1; x < batteryFrameCount; x++)
                        {
                            batterySprite.AddFrame(
                            new Rectangle(
                            batteryFrameIndex + (batteryFrameWidth * x),
                            batterySpriteOffset,
                            batteryFrameWidth,
                            batteryFrameHeight));
                        }

                        batterySprite.Scale = 0.5f;

                        batterySprite.HillIndex = checkLocation;

                        batterySprite.Location.X = hills.HillsPixels[batterySprite.HillIndex].Location.X - (batteryFrameWidth / 2);

                        batterySprite.Location.Y = hills.HillsPixels[batterySprite.HillIndex].Location.Y - (batteryFrameHeight / 2) - 20.0f;

                        batterySprite.Rotation = (float)Math.Atan(hills.getSlope((int)batterySprite.Location.X));

                        batterySprite.CollisionRadius = batteryRadius;

                        rewardsList.Add(batterySprite);
                        break;

                    case 2:

                        //generate a saw 
                        sawSprite = new Sprite(
                        new Vector2(0, 0),
                        texture,
                        new Rectangle(0, sawSpriteOffset, sawFrameWidth, sawFrameHeight),
                        Vector2.Zero);

                        for (int x = 1; x < sawFrameCount; x++)
                        {
                            sawSprite.AddFrame(
                            new Rectangle(
                            sawFrameIndex + (sawFrameWidth * x),
                            sawSpriteOffset,
                            sawFrameWidth,
                            sawFrameHeight));
                        }

                        sawSprite.Scale = 0.4f;

                        sawSprite.HillIndex = checkLocation;

                        sawSprite.Location.X = hills.HillsPixels[sawSprite.HillIndex].Location.X - (sawFrameWidth / 2);

                        sawSprite.Location.Y = hills.HillsPixels[sawSprite.HillIndex].Location.Y - (sawFrameHeight / 2) - 20.0f;

                        sawSprite.Rotation = (float)Math.Atan(hills.getSlope((int)sawSprite.Location.X));

                        sawSprite.CollisionRadius = sawRadius;

                        rewardsList.Add(sawSprite);
                        break;
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            //draw
            foreach (Sprite rewardsSprite in rewardsList)
            {
                    rewardsSprite.Draw(spriteBatch);
            }

        }

        public void Update(GameTime gameTime)
        {
            removeIndex = -1;
            foreach (Sprite rewardsSprite in rewardsList)
            {
                if (rewardsSprite.Location.X <= 0.0f)
                {   //when the object goes off the screen remove the sprite object from the list
                    removeIndex = rewardsList.IndexOf(rewardsSprite);
                }else
                {   //move the sprite
                    rewardsSprite.Location.X = hills.HillsPixels[rewardsSprite.HillIndex].Location.X - (rewardsSprite.Destination.Width/2);
                    rewardsSprite.Location.Y = hills.HillsPixels[rewardsSprite.HillIndex].Location.Y - (rewardsSprite.Destination.Height/2) - 20.0f;
                    rewardsSprite.Rotation = (float)Math.Atan(hills.getSlope((int)rewardsSprite.Location.X));
                }

                rewardsSprite.Update(gameTime);
           
            }

            if (removeIndex >= 0)
            {   //remove object from the list and compress the list
                rewardsList.RemoveAt(removeIndex);
                rewardsList.TrimExcess();
            }

            if (hills.Velocity < -100.0f)
            {           
                generateReward();
            }

        }
    }
}

