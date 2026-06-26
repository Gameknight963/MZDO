using System.IO;

namespace MZDO
{
    public class NodeAudioManager
    {
        static readonly string speakPath = Path.Combine(Core.tmp, "Speak");

        public static string GetNodeAudioPath(int treeIndex, int nodeId)
        {
            if (!Directory.Exists(Core.tmp)) return null;
            string[] files = Directory.GetFiles(Core.tmp, $"{treeIndex}_{nodeId}.*");
            return files.Length > 0 ? files[0] : null;
        }

        public static string GetSpeakerChirp(string speakerName)
        {
            string[] files = Directory.GetFiles(speakPath, $"{speakerName}.*");
            if (files.Length == 0) return null;
            return files[0];
        }

        public static bool TryGetSpeakerChirp(string speakerName, out string path)
        {
            string[] files = Directory.GetFiles(speakPath, $"{speakerName}.*");
            if (files.Length == 0)
            {
                path = null;
                return false;
            }
            path = files[0];
            return true;
        }
    }
}
