using Terraria.ModLoader;
using Microsoft.Xna.Framework.Audio;

namespace DeviantAnomalyRedemptionStuff.Sounds.Item
{
    class X_victory : ModSound
    {
        public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType Type)
        {

            soundInstance = sound.CreateInstance();
            soundInstance.Volume = volume;
            soundInstance.Pan = pan;
            soundInstance.Pitch = 0f;//Screw that default pitch variance crap. Weapons, I don't mind, but this stays put.
            return soundInstance;
        }
    }
}