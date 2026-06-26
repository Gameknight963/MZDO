using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace MZDO
{
    public static class HarmonyPatches
    {
        [HarmonyPatch(typeof(DialogueTree), "PlayNode")]
        static class FixAudioPitchBug
        {
            static void Prefix(DialogueTree __instance, DialogueNode node)
            {
                DialogueEvents.OnNodePlayed?.Invoke(node);
                if (node.voiceClip)
                    __instance.GetSpeakerAudioSource(node.speakerName)?.pitch = 1f;
            }
        }
    }
}
