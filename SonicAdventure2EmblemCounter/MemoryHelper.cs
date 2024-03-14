using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SonicAdventure2EmblemCounter
{
    public class MemoryHelper
    {
        /// <summary>
        ///     The value representing the WM_READ access rights for a process.
        /// </summary>
        public const int PROCESS_WM_READ = 0x0010;

        /// <summary>
        ///     Opens an existing process object for manipulation.
        /// </summary>
        /// <param name="dwDesiredAccess">The access to the process object.</param>
        /// <param name="bInheritHandle">Indicates whether the returned handle is inheritable.</param>
        /// <param name="dwProcessId">The identifier of the process to be opened.</param>
        /// <returns>
        ///     If the function succeeds, the return value is an open handle to the specified process.
        ///     If the function fails, the return value is IntPtr.Zero and GetLastError returns the error code.
        /// </returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        /// <summary>
        ///     Opens an existing process object for manipulation and reads the memory from a specified address.
        /// </summary>
        /// <param name="hProcess">The process to read from.</param>
        /// <param name="lpBaseAddress">The base address from where to read from.</param>
        /// <param name="lpBuffer">The buffer to read data into.</param>
        /// <param name="dwSize">The (length in bytes) to read.</param>
        /// <param name="lpNumberOfBytesRead">The number of bytes read.</param>
        /// <returns>
        ///     Returns a byte array containing the data read from the process memory.
        /// </returns>
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        
        /// <summary>
        ///     Reads a sequence of bytes from the specified address in the process' memory.
        /// </summary>
        /// <param name="address">The starting address to read from.</param>
        /// <param name="length">The number of bytes to read.</param>
        /// <returns>
        ///     An array of bytes read from the process' memory.
        /// </returns>
        public static byte[] ReadBytes(int address, int length)
        {
            byte[] bytes = new byte[length];

            try
            {
                Process? process = Process.GetProcessesByName("sonic2app").FirstOrDefault();

                if (process == null)
                    throw new Exception("Sonic2App process not running");

                int bytesRead = 0;
                IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, process.Id);
                ReadProcessMemory((int)processHandle, address, bytes, length, ref bytesRead);
            }
            catch
            {
                throw new InvalidOperationException("Couldn't read from Sonic Adventure 2 Process.");
            }

            return bytes;
        }

        /// <summary>
        ///     Reads a single byte from the specified address in the process' memory and converts it to a 32-bit signed integer.
        /// </summary>
        /// <param name="address">The starting address to read from.</param>
        /// <returns>
        /// A 32-bit signed integer representing the value of the byte read from the process' memory.
        /// </returns>
        public int ReadInt(int address)
        {
            byte[] bytes = ReadBytes(address, 1);
            
            if (bytes.Length < 1)
                throw new InvalidOperationException("Not enough bytes read from memory to convert to Int32.");
            
            return bytes[0];
        }
    }
}
