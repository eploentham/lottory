﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottory.object1
{
    public class FStreamLock
    {//"C:\\pic\\2558\\02\\01\\1122_1.lotto"
        public FStreamLock(String file1)
        {
            UnicodeEncoding uniEncoding = new UnicodeEncoding();
            string lastRecordText = "The last processed record number was: ";
            int textLength = uniEncoding.GetByteCount(lastRecordText);
            int recordNumber = 13;
            int byteCount = uniEncoding.GetByteCount(recordNumber.ToString());
            string tempString;

            using (FileStream fileStream = new FileStream(file1, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                // Write the original file data. 
                if (fileStream.Length == 0)
                {
                    tempString = lastRecordText + recordNumber.ToString();
                    fileStream.Write(uniEncoding.GetBytes(tempString), 0, uniEncoding.GetByteCount(tempString));
                }

                // Allow the user to choose the operation. 
                char consoleInput = 'R';
                byte[] readText = new byte[fileStream.Length];
                while (consoleInput != 'X')
                {
                    Console.Write(
                        "\nEnter 'R' to read, 'W' to write, 'L' to " +
                        "lock, 'U' to unlock, anything else to exit: ");

                    if ((tempString = Console.ReadLine()).Length == 0)
                    {
                        break;
                    }
                    consoleInput = char.ToUpper(tempString[0]);
                    switch (consoleInput)
                    {
                        // Read data from the file and  
                        // write it to the console. 
                        case 'R':
                            try
                            {
                                fileStream.Seek(0, SeekOrigin.Begin);
                                fileStream.Read(readText, 0, (int)fileStream.Length);
                                tempString = new String(uniEncoding.GetChars(readText, 0, readText.Length));
                                Console.WriteLine(tempString);
                                recordNumber = int.Parse(tempString.Substring(tempString.IndexOf(':') + 2));
                            }

                            // Catch the IOException generated if the  
                            // specified part of the file is locked. 
                            catch (IOException e)
                            {
                                Console.WriteLine("{0}: The read " +
                                    "operation could not be performed " +
                                    "because the specified part of the " +
                                    "file is locked.",
                                    e.GetType().Name);
                            }
                            break;

                        // Update the file. 
                        case 'W':
                            try
                            {
                                fileStream.Seek(textLength, SeekOrigin.Begin);
                                fileStream.Read(readText, textLength - 1, byteCount);
                                tempString = new String(uniEncoding.GetChars(readText, textLength - 1, byteCount));
                                recordNumber = int.Parse(tempString) + 1;
                                fileStream.Seek(textLength, SeekOrigin.Begin);
                                fileStream.Write(uniEncoding.GetBytes(recordNumber.ToString()), 0, byteCount);
                                fileStream.Flush();
                                Console.WriteLine("Record has been updated.");
                            }

                            // Catch the IOException generated if the  
                            // specified part of the file is locked. 
                            catch (IOException e)
                            {
                                Console.WriteLine(
                                    "{0}: The write operation could not " +
                                    "be performed because the specified " +
                                    "part of the file is locked.",
                                    e.GetType().Name);
                            }
                            break;

                        // Lock the specified part of the file. 
                        case 'L':
                            try
                            {
                                fileStream.Lock(textLength - 1, byteCount);
                                Console.WriteLine("The specified part " +
                                    "of file has been locked.");
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine(
                                    "{0}: The specified part of file is" +
                                    " already locked.", e.GetType().Name);
                            }
                            break;

                        // Unlock the specified part of the file. 
                        case 'U':
                            try
                            {
                                fileStream.Unlock(
                                    textLength - 1, byteCount);
                                Console.WriteLine("The specified part " +
                                    "of file has been unlocked.");
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine(
                                    "{0}: The specified part of file is " +
                                    "not locked by the current process.",
                                    e.GetType().Name);
                            }
                            break;

                        // Exit the program. 
                        default:
                            consoleInput = 'X';
                            break;
                    }
                }
            }
        }
    }
}
