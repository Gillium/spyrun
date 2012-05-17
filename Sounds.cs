using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace SpyRun
{
    class Sounds
    {
        Song level1Music;
        Song level2Music;
        Song level3Music;
        Song gameStart;
        SoundEffect blimpEngineSE;
        SoundEffectInstance blimpEngineSEI;
        SoundEffect explosionSE;
        SoundEffect failedSE;
        SoundEffect shotSE;
        SoundEffect playerEngineSE;
        SoundEffectInstance playerEngineSEI;
        SoundEffect rewardSE;
        SoundEffect missileEngineSE;
        SoundEffectInstance missileEngineSEI;

        private int level;

        public Sounds(Song song1, Song song2, Song song3, SoundEffect blimpEngineSound, SoundEffect explosionSound, SoundEffect failedSound,
            Song gameStartSound, SoundEffect playerEngineSound, SoundEffect rewardSound, SoundEffect shotSound)
        {
            level1Music = song1;
            level2Music = song2;
            level3Music = song3;
            MediaPlayer.IsRepeating = true;


            blimpEngineSE = blimpEngineSound;
            blimpEngineSEI = blimpEngineSE.CreateInstance();
            blimpEngineSEI.IsLooped = true;
            blimpEngineSEI.Pitch = 0.0f;
            blimpEngineSEI.Pan = 0.0f;

            missileEngineSE = blimpEngineSound;
            missileEngineSEI = missileEngineSE.CreateInstance();
            missileEngineSEI.IsLooped = true;
            missileEngineSEI.Pitch = 1.0f;
            missileEngineSEI.Pan = 0.0f;

            playerEngineSE = playerEngineSound;
            playerEngineSEI = playerEngineSE.CreateInstance();
            playerEngineSEI.IsLooped = true;
            playerEngineSEI.Pitch = -1.0f;


            explosionSE = explosionSound;
            failedSE = failedSound;
            gameStart = gameStartSound;
            rewardSE = rewardSound;
            shotSE = shotSound;
        }

        public void setLevel(int lvl)
        {
            level = lvl;
        }

        public void playBackground(int level)
        {
            switch (level)
            {
                case 1:
                    MediaPlayer.Play(level1Music);
                    break;
                case 2:

                    MediaPlayer.Play(level2Music);
                    break;
                case 3:

                    MediaPlayer.Play(level3Music);
                    break;
            }
        }

        public void playBlimpEngineSE()
        {
            blimpEngineSE.Play();
        }

        public void startBlimpEngineSE()
        {
            blimpEngineSEI.Play();
        }

        public void stopBlimpEngineSE()
        {
            blimpEngineSEI.Stop();
        }

        public void playMissileEngineSE()
        {
            missileEngineSE.Play();
        }

        public void startMissileEngineSE()
        {
            missileEngineSEI.Play();
        }

        public void stopMissileEngineSE()
        {
            missileEngineSEI.Stop();
        }
        public void playExplosionSE()
        {
            explosionSE.Play();
        }

        public void playFailedSE()
        {
            failedSE.Play();
        }

        public void playShotSE()
        {
            shotSE.Play();
        }

        public void playGameStartSong()
        {
            MediaPlayer.Play(gameStart);
        }
        public void stopGameStartSong()
        {
            MediaPlayer.Stop();
        }

        public void startPlayerEngineSE()
        {
            playerEngineSEI.Play();
        }

        public void stopPlayerEngineSE()
        {
            playerEngineSEI.Stop();
        }

        public void playRewardSE()
        {
            rewardSE.Play();
        }

        public void blimpPitch(float inP)
        {
            blimpEngineSEI.Pitch = inP;
        }

        public void blimpPan(float inP)
        {
            blimpEngineSEI.Pan = inP;
        }

        public void missilePan(float inP)
        {
            missileEngineSEI.Pan = inP;
        }

        public void mediaPlayerStop()
        {
            MediaPlayer.Stop();
        }

        //public void backgoundVolume()
        //{

        //}

        //public void backgroundMute()
        //{

        //}
    }
}
