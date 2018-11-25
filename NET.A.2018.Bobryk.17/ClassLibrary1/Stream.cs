﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamExtencion
{
    public static class Stream
    {
        #region Public members

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        /// <summary>
        /// Implement by block copy logic using class-decorator BufferedStream.
        /// </summary>
        /// <param name="sourcePath">Source</param>
        /// <param name="destinationPath">Destination</param>
        /// <returns>Amount of bytes</returns>
        public static int BufferedCopy(string source, string destination)
        {
            CheckFiles(source, destination);

            int bytesCount = 0;

            using (FileStream firstStream = new FileStream(source, FileMode.Open, FileAccess.Read))
            {
                using (FileStream secondStram = new FileStream(destination, FileMode.Open, FileAccess.Write))
                {
                    using (BufferedStream buffered = new BufferedStream(firstStream))
                    {
                        while (true)
                        {
                            int @byte = buffered.ReadByte();

                            if (@byte == -1)
                            {
                                break;
                            }

                            secondStram.WriteByte((byte)@byte);
                            bytesCount++;
                        }
                    }
                }
            }

            return bytesCount;
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        /// <summary>
        /// Implement by block copy logic using FileStream buffer.
        /// </summary>
        /// <param name="sourcePath">Source</param>
        /// <param name="destinationPath">Destination</param>
        /// <returns>Amount of bytes</returns>
        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            CheckFiles(sourcePath, destinationPath);

            using (FileStream firstStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream secondStream = new FileStream(destinationPath, FileMode.Open, FileAccess.Write))
                {
                    firstStream.CopyTo(secondStream);
                }

                return (int)firstStream.Length;
            }
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        /// <summary>
        /// Implement by byte copy logic using class MemoryStream as a backing store stream.
        /// </summary>
        /// <param name="sourcePath">Source</param>
        /// <param name="destinationPath">Destination</param>
        /// <returns>Amount of bytes</returns>
        public static int InMemoryByByteCopy(string source, string destination)
        {
            CheckFiles(source, destination);

            string entireFile = string.Empty;

            using (StreamReader reader = new StreamReader(source))
            {
                entireFile = reader.ReadToEnd();
            }

            Encoding encoding = Encoding.ASCII;
            int byteCount = encoding.GetByteCount(entireFile.ToCharArray());
            byte[] bytes = new byte[byteCount];
            encoding.GetBytes(entireFile, 0, byteCount, bytes, bytes.GetLowerBound(0));

            byte[] buffer = new byte[bytes.Length];
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(buffer, 0, bytes.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);

                for (int i = 0; i < memoryStream.Length; i++)
                {
                    buffer[i] = (byte)memoryStream.ReadByte();
                }
            }

            char[] content = encoding.GetChars(buffer);

            using (StreamWriter streamWriter = new StreamWriter(destination))
            {
                foreach (char symbol in content)
                {
                    streamWriter.Write(symbol);
                }
            }

            return buffer.Length;
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        /// <summary>
        /// Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter
        /// </summary>
        /// <param name="sourcePath">Source</param>
        /// <param name="destinationPath">Destination</param>
        /// <returns>Amount line</returns>
        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            using (FileStream firstStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream secondStream = new FileStream(destinationPath, FileMode.Open, FileAccess.Write))
                {
                    List<string> list = new List<string>();

                    using (StreamReader streamReader = new StreamReader(firstStream))
                    {
                        while (true)
                        {
                            string line = streamReader.ReadLine();

                            if (line == null)
                            {
                                break;
                            }

                            list.Add(line);
                        }
                    }

                    using (StreamWriter streamWriter = new StreamWriter(secondStream))
                    {
                        foreach (string line in list)
                        {
                            streamWriter.WriteLine(line);
                        }
                    }

                    return list.Count;
                }
            }
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        /// <summary>
        /// Implement content comparison logic of two files 
        /// </summary>
        /// <param name="sourcePath">Source</param>
        /// <param name="destinationPath">Destination</param>
        /// <returns>Comparison result</returns>
        public static bool IsContentEquals(string source, string destination)
        {
            int firstByte, secondByte;

            using (FileStream firstFile = new FileStream(source, FileMode.Open))
            {
                using (FileStream secondFile = new FileStream(destination, FileMode.Open))
                {
                    if (firstFile.Length != secondFile.Length)
                    {
                        return false;
                    }

                    do
                    {

                        firstByte = firstFile.ReadByte();
                        secondByte = secondFile.ReadByte();

                    } while ((firstByte == secondByte) && (firstByte != -1));
                }
            }

            return ((firstByte - secondByte) == 0);
        }

        #endregion

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .
        /// <summary>
        /// Implement by byte copy logic using class FileStream as a backing store stream
        /// </summary>
        /// <param name="sourcePath">Source</param>
        /// <param name="destinationPath">Destination</param>
        /// <returns>Amount of bytes</returns>
        public static int ByByteCopy(string source, string destination)
        {
            CheckFiles(source, destination);

            List<int> bytes = new List<int>();

            using (FileStream firstFile = new FileStream(source, FileMode.Open, FileAccess.Read))
            {
                for (int i = 0; i < firstFile.Length; i++)
                {
                    bytes.Add(firstFile.ReadByte());
                }
            }

            using (FileStream secondFile = new FileStream(destination, FileMode.Open, FileAccess.Write))
            {
                foreach (int @byte in bytes)
                {
                    secondFile.WriteByte((byte)@byte);
                }

                return (int)secondFile.Length;
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        /// <summary>
        /// Implement by block copy logic using MemoryStream.
        /// </summary>
        /// <param name="sourcePath">Source</param>
        /// <param name="destinationPath">Destination</param>
        /// <returns>Amount of bytes</returns>
        public static int InMemoryByBlockCopy(string source, string destination)
        {
            CheckFiles(source, destination);

            string readingString = string.Empty;

            using (StreamReader stream = new StreamReader(source, Encoding.UTF8))
            {
                readingString = stream.ReadToEnd();
            }

            byte[] readingBytes = Encoding.UTF8.GetBytes(readingString);
            byte[] writeBytes = new byte[readingBytes.Length];

            using (MemoryStream memoryStream = new MemoryStream(readingBytes, 0, readingBytes.Length))
            {
                memoryStream.Write(readingBytes, 0, readingBytes.Length);
                writeBytes = memoryStream.ToArray();
            }

            char[] line = Encoding.UTF8.GetChars(writeBytes);

            using (StreamWriter streamWriter = new StreamWriter(destination))
            {
                streamWriter.Write(line);
            }

            return writeBytes.Length;
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void CheckFiles(string source, string destination)
        {
            if (!File.Exists(source))
            {
                throw new ArgumentException(nameof(source), $"File {source} does not exist!");
            }

            if (!File.Exists(destination))
            {
                throw new ArgumentException(nameof(destination), $"File {destination} does not exist!");
            }
        }

        #endregion

        #endregion
    }
}

