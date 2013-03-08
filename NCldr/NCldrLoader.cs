namespace NCldr
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;

    /// <summary>
    /// NCldrLoader loads the raw NCLDR data from an NCldr.data file
    /// </summary>
    /// <remarks>Set the NCldrLoader.NCldrDataPath property before calling NCldrLoader.Load</remarks>
    public class NCldrLoader
    {
        /// <summary>
        /// Gets or sets the path to the NCldr.dat file (includes the folder name only with no filename)
        /// </summary>
        public static string NCldrDataPath { get; set; }

        /// <summary>
        /// Loads loads the raw data from the NCldr.dat file and returns an NCldrData object
        /// </summary>
        /// <returns>An INCldrData object from the NCldr.dat file</returns>
        public static INCldrData Load()
        {
            NCldrData ncldrData = null;

#if WINDOWS_PHONE
            string ncldrDataFilename = Path.Combine(NCldrDataPath, "NCldr.json");
            var stream = System.Windows.Application.GetResourceStream(new Uri(ncldrDataFilename, UriKind.Relative));

            var sr = new StreamReader(stream.Stream);
            var str = sr.ReadToEnd();

            ncldrData = Newtonsoft.Json.JsonConvert.DeserializeObject<NCldrData>(str);

#else
            try
            {
            string ncldrDataFilename = Path.Combine(NCldrDataPath, "NCldr.dat");
            if (!File.Exists(ncldrDataFilename))
            {
                return null;
            }

            FileStream fileStream = new FileStream(ncldrDataFilename, FileMode.Open);
                var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                // Deserialize the hashtable from the file and  
                // assign the reference to the local variable.
                ncldrData = (NCldrData)formatter.Deserialize(fileStream);
                
            }
            catch (SerializationException exception)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + exception.Message);
                throw;
            }
            finally
            {
                //fileStream.Close();
            }
#endif

            return ncldrData;
        }
    }
}
