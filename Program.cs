using System;
using System.Text;
using System.Security.Cryptography;
using EscapistsMapTools.Encryption;
using decomp;
namespace decomp
{
    class Program
    {
        public static void Main(string[] args)
        {
            BlowFish b = new BlowFish("6d6f74686b696e67");
            string key = "mothking";
            string filePath;
            string saveFilePath;
            string userOption1;
            string userOption2;
            string userOption3;
            string decryptedString;
            string[] lines;
            int sizeInitial;
            byte[] inputBytes;
            byte[] fileBytes;
            byte[] encryptedData;
            byte[] decryptedData;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" _____ _          _____                 _     _       ");
                Console.WriteLine("|_   _| |_ ___   |   __|___ ___ ___ ___|_|___| |_ ___ ");
                Console.WriteLine("  | | |   | -_|  |   __|_ -|  _| .'| . | |_ -|  _|_ -|");
                Console.WriteLine("  |_| |_|_|___|  |_____|___|___|__,|  _|_|___|_| |___|");
                Console.WriteLine("                                   |_|                ");
                Console.WriteLine("\nWelcome to the Ultimate Decompiler for The Escapists\n\nSelect an option from below:");
                Console.WriteLine("\n0. Exit Program\n1. Decrypt Any File\n2. Encrypt Any File\n3. Proj -> Cmap\n4. Proj -> Map\n5. Cmap -> Proj\n6. Cmap -> Map\n7. Map -> Proj\n8. Map -> Cmap\n9. About");
                userOption1 = Console.ReadLine();
                switch (userOption1)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        Console.WriteLine("\nEnter the file location: ");
                        filePath = Console.ReadLine();
                        if (System.IO.File.Exists(filePath))
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\nFile not found or invalid path.");
                            Console.ReadLine();
                        }                
                        fileBytes = System.IO.File.ReadAllBytes(filePath);
                        BlowfishCompat decryptionBlowfish = new BlowfishCompat(key);
                        decryptedData = decryptionBlowfish.Decrypt(fileBytes);
                        decryptedString = Encoding.ASCII.GetString(decryptedData);
                        Console.Write("\n\nEnter the file location to save the decrypted data: ");
                        saveFilePath = Console.ReadLine();
                        System.IO.File.WriteAllText(saveFilePath, decryptedString);
                        Console.WriteLine("\nData motified succesfully!");
                        Console.ReadLine();
                        break;
                    case "2":


                        Console.Write("\n\nEnter the file location: ");
                        filePath = Console.ReadLine();
                        if (System.IO.File.Exists(filePath))
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\nFile not found or invalid path.");
                        }
                        inputBytes = Encoding.ASCII.GetBytes(System.IO.File.ReadAllText(filePath));
                        BlowfishCompat encryptionBlowfish = new BlowfishCompat(key);
                        encryptedData = encryptionBlowfish.Encrypt(inputBytes);
                        Console.WriteLine("\nEnter the file location to save the encrypted data: ");
                        saveFilePath = Console.ReadLine();
                        Console.ReadLine();
                        System.IO.File.WriteAllBytes(saveFilePath, encryptedData);
                        Console.WriteLine("\nData motified succesfully!");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("\n\nEnter the file location: ");
                        filePath = Console.ReadLine();
                        if (File.Exists(filePath))
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\nFile not found or invalid path.");
                            Console.ReadLine();
                        }
                        lines = File.ReadAllLines(filePath);
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (lines[i].Contains("Custom=-1"))
                            {
                                
                                lines[i] = "Custom=2";
                                break;
                            }
                        }
                        Console.WriteLine("\nEnter the file location to save the .cmap file: ");
                        saveFilePath = Console.ReadLine();
                        File.WriteAllLines(saveFilePath, lines);
                        Console.WriteLine("\nData motified succesfully!");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("What map do you want this to be in place of?\n0. Tutorial\n1. Center Perks\n2. Stalag Flucht\n3. Shankton State Pen\n4. Jungle Compound\n5. San Pancho\n6. HMP Irongate" +
                            "\n7. Jingle Cells\n8. Banned Camp\n9. London Tower\n10. Paris Central Pen\n11. Santa's Sweatshop\n12. Duct Tapes are Forever\n13. Escape Team\n14. Alcatraz\n15. Fhurst Peak Correctional" +
                            "\n16. Camp Epsilon\n17. Fort Bamford");
                        userOption2 = Console.ReadLine();
                        switch (userOption2)
                        {
                            case "0":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 87009;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);

                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 87009;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 87009;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "1":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 87612;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 87612;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 87612;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "2":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 84119;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 84119;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 84119;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "3":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 92542;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 92542;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();

                                        sizeInitial = 92542;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "4":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 84774;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 84774;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 84774;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "5":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 83833;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 83833;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 83833;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "6":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 89084;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 89084;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 89084;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "7":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 110311;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 110311;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 110311;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "8":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 108049;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 108049;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 108049;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;

                            case "9":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 112807;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 112807;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 112807;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;

                            case "10":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();

                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 115734;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 115734;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 115734;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;

                            case "11":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 142422;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 142422;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 142422;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "12":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 134501;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 134501;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 134501;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "13":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 142829;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 142829;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 142829;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "14":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 109893;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 109893;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 109893;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "15":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 88100;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 88100;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 88100;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "16":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 103756;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 103756;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 103756;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "17":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 80414;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 80414;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 80414;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("Error");
                                Console.ReadLine();
                                break;
                        }
                        break;
                    case "5":
                        Console.Write("\n\nEnter the file location: ");
                        filePath = Console.ReadLine();
                        if (File.Exists(filePath))
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\nFile not found or invalid path.");
                        }
                        lines = File.ReadAllLines(filePath);
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (lines[i].Contains("Custom=2"))
                            {
                                lines[i] = "Custom=-1";
                                break;
                            }
                        }
                        Console.Write("\n\nEnter the file location to save the .proj file: ");
                        saveFilePath = Console.ReadLine();
                        File.WriteAllLines(saveFilePath, lines);
                        Console.WriteLine("\nData motified succesfully!");
                        Console.ReadLine();
                        break;
                    case "6":
                        Console.Clear();
                        Console.Write("What map do you want this to be in place of?\n0. Tutorial\n1. Center Perks\n2. Stalag Flucht\n3. Shankton State Pen\n4. Jungle Compound\n5. San Pancho\n6. HMP Irongate" +
                            "\n7. Jingle Cells\n8. Banned Camp\n9. London Tower\n10. Paris Central Pen\n11. Santa's Sweatshop\n12. Duct Tapes are Forever\n13. Escape Team\n14. Alcatraz\n15. Fhurst Peak Correctional" +
                            "\n16. Camp Epsilon\n17. Fort Bamford");
                        userOption2 = Console.ReadLine();
                        switch (userOption2)
                        {
                            case "0":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 87009;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);

                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 87009;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 87009;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "1":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 87612;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 87612;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 87612;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "2":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 84119;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 84119;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 84119;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "3":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 92542;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 92542;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();

                                        sizeInitial = 92542;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "4":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 84774;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 84774;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 84774;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "5":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 83833;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 83833;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 83833;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "6":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 89084;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 89084;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 89084;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "7":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 110311;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 110311;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 110311;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "8":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 108049;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 108049;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 108049;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;

                            case "9":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 112807;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 112807;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 112807;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;

                            case "10":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();

                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 115734;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 115734;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 115734;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;

                            case "11":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 142422;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 142422;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 142422;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "12":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 134501;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 134501;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 134501;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "13":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 142829;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 142829;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 142829;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "14":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 109893;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 109893;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 109893;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "15":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 88100;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 88100;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 88100;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "16":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 103756;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 103756;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 103756;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            case "17":
                                Console.WriteLine("Select the layer that is okay to remove:\n0. Vents\n1. Roof\n2. Underground\n");
                                userOption3 = Console.ReadLine();
                                switch (userOption3)
                                {
                                    case "0":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 80414;
                                        string tempFilePath1 = ModifyFileVents(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath1);
                                        Console.ReadLine();
                                        break;
                                    case "1":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 80414;
                                        string tempFilePath2 = ModifyFileRoof(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath2);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        Console.WriteLine("\nEnter the file location: ");
                                        filePath = Console.ReadLine();
                                        sizeInitial = 80414;
                                        string tempFilePath3 = ModifyFileUnderground(filePath, sizeInitial);
                                        EncryptAndSaveFile(tempFilePath3);
                                        Console.ReadLine();
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("Error");
                                Console.ReadLine();
                                break;
                        }
                        break;
                    case "7":
                        Console.WriteLine("\nEnter the file location: ");
                        filePath = Console.ReadLine();
                        if (System.IO.File.Exists(filePath))
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\nFile not found or invalid path.");
                            Console.ReadLine();
                        }
                        Console.WriteLine("Selected file: " + filePath);
                        fileBytes = System.IO.File.ReadAllBytes(filePath);
                        decryptionBlowfish = new BlowfishCompat(key);
                        decryptedData = decryptionBlowfish.Decrypt(fileBytes);                       
                        decryptedString = Encoding.ASCII.GetString(decryptedData);
                        Console.Write("\n\nEnter the file location to save the .proj file: ");
                        string tempFilePath = Console.ReadLine();
                        System.IO.File.WriteAllText(tempFilePath, decryptedString);                 
                        lines = File.ReadAllLines(tempFilePath);
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (lines[i].Contains("[Info]"))
                            {
                                string[] newLines = { "Custom=-1", "Rdy=1" };
                                lines = lines.Take(i + 1).Concat(newLines).Concat(lines.Skip(i + 1)).ToArray();
                                break;
                            }
                        }
                        System.IO.File.WriteAllLines(tempFilePath, lines);
                        Console.WriteLine("Data modified succesfully!");
                        Console.ReadLine();
                        break;
                    case "8":
                        Console.WriteLine("\nEnter the file location: ");
                        filePath = Console.ReadLine();
                        if (System.IO.File.Exists(filePath))
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\nFile not found or invalid path.");
                            Console.ReadLine();
                        }                     
                        fileBytes = System.IO.File.ReadAllBytes(filePath);
                        decryptionBlowfish = new BlowfishCompat(key);
                        decryptedData = decryptionBlowfish.Decrypt(fileBytes);
                        decryptedString = Encoding.ASCII.GetString(decryptedData);
                        Console.Write("\n\nEnter the file location to save the .cmap file: ");
                        tempFilePath = Console.ReadLine();                                             
                        System.IO.File.WriteAllText(tempFilePath, decryptedString);                       
                        lines = File.ReadAllLines(tempFilePath);
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (lines[i].Contains("[Info]"))
                            {
                                Console.WriteLine($"Found line containing '[Info]' at index {i}");
                                string[] newLines = { "Custom=2", "Rdy=1" };
                                lines = lines.Take(i + 1).Concat(newLines).Concat(lines.Skip(i + 1)).ToArray();
                                break;
                            }
                        } 
                        System.IO.File.WriteAllLines(tempFilePath, lines);
                        Console.WriteLine("\nData modified succesfully");
                        Console.ReadLine();
                        break;
                    case "9":
                        Console.Clear();
                        Console.WriteLine("About: This program was made by Isaac Lowery (Discord: iliketurtles14) With immense help from the C# Discord Server and ChatGPT.\nCredits for the Blowfish-compat algorithms - Mikeprod (Blowfish.cs), 10se1ucgo (BlowfishCompat.cs)\nFor more questions, just DM me on Discord. My DM's are always open! :)\nAll rights to The Escapists properties go to Team17/Mouldy Toof Studios.");
                        Console.WriteLine("\nTo return to the selection menu, press Enter");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
                static string ModifyFileVents(string filePath, int sizeInitial)
                {
                    string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                    string introLine = lines.FirstOrDefault(line => line.StartsWith("Intro"));
                    string ventsLine = lines.FirstOrDefault(line => line.StartsWith("[Vents]"));
                    string roofLine = lines.FirstOrDefault(line => line.StartsWith("[Roof]"));
                    int roofLineIndex = Array.IndexOf(lines, roofLine);
                    if (roofLineIndex > 0)
                        roofLineIndex--;
                    lines = lines.Where((line, index) => index < Array.IndexOf(lines, ventsLine) || index > roofLineIndex).ToArray();
                    int currentSize = CountCharacters(lines);
                    int difference = sizeInitial - currentSize;
                    if (!string.IsNullOrEmpty(introLine))
                        lines[Array.IndexOf(lines, introLine)] += new string('n', Math.Max(0, difference));
                    Console.WriteLine("Enter the file location to save the .map file: ");
                    string tempFilePath = Console.ReadLine();                     
                    File.WriteAllLines(tempFilePath, lines, Encoding.UTF8);
                    return tempFilePath;
                }
                static string ModifyFileRoof(string filePath, int sizeInitial)
                {
                    string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                    string introLine = lines.FirstOrDefault(line => line.StartsWith("Intro"));
                    string roofLine = lines.FirstOrDefault(line => line.StartsWith("[Roof]"));
                    string undergroundLine = lines.FirstOrDefault(line => line.StartsWith("[Underground]"));
                    int undergroundLineIndex = Array.IndexOf(lines, undergroundLine);
                    if (undergroundLineIndex > 0)
                        undergroundLineIndex--;
                    lines = lines.Where((line, index) => index < Array.IndexOf(lines, roofLine) || index > undergroundLineIndex).ToArray();
                    int currentSize = CountCharacters(lines);
                    int difference = sizeInitial - currentSize;
                    if (!string.IsNullOrEmpty(introLine))
                        lines[Array.IndexOf(lines, introLine)] += new string('n', Math.Max(0, difference));
                    string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                    File.WriteAllLines(tempFilePath, lines, Encoding.UTF8);
                    return tempFilePath;
                }
                static string ModifyFileUnderground(string filePath, int sizeInitial)
                {
                    string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                    string introLine = lines.FirstOrDefault(line => line.StartsWith("Intro"));
                    string undergroundLine = lines.FirstOrDefault(line => line.StartsWith("[Underground]"));
                    string objectsLine = lines.FirstOrDefault(line => line.StartsWith("[Objects]"));
                    int objectsLineIndex = Array.IndexOf(lines, objectsLine);
                    if (objectsLineIndex > 0)
                        objectsLineIndex--;
                    lines = lines.Where((line, index) => index < Array.IndexOf(lines, objectsLine) || index > objectsLineIndex).ToArray();
                    int currentSize = CountCharacters(lines);
                    int difference = sizeInitial - currentSize;
                    if (!string.IsNullOrEmpty(introLine))
                        lines[Array.IndexOf(lines, introLine)] += new string('n', Math.Max(0, difference));
                    string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                    File.WriteAllLines(tempFilePath, lines, Encoding.UTF8);
                    return tempFilePath;
                }
                static int CountCharacters(string[] lines)
                {
                    return lines.Sum(line => line.Length);
                }
                static void EncryptAndSaveFile(string tempFilePath)
                {
                    byte[] inputBytes = Encoding.ASCII.GetBytes(File.ReadAllText(tempFilePath));
                    string key = "mothking";
                    BlowfishCompat encryptionBlowfish = new BlowfishCompat(key);
                    byte[] encryptedData = encryptionBlowfish.Encrypt(inputBytes);            
                    string saveFilePath = tempFilePath;
                    File.WriteAllBytes(saveFilePath, encryptedData);
                    Console.WriteLine("Data motified successfully!");
                    Console.ReadLine();
                }
            }
        }
    }
}