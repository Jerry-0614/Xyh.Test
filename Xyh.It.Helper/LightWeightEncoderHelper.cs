using System;
using System.Text;

namespace Xyh.It.Helper
{
    public class LightWeightEncoderHelper
    {
        public static string EncodeString(string encodeString)
        {
            if (encodeString == null)
            {
                return null;
            }
            try
            {
                var bytes = Encoding.Default.GetBytes(encodeString);
                for (int i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = (byte)(bytes[i] + 1);
                }
                //string t = Encoding.ASCII.GetString(bytes);
                encodeString = Convert.ToBase64String(bytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return encodeString;
            
        }

        public static string DecodeString(string encodeString)
        {
            if (encodeString == null)
            {
                return null;
            }
            try
            {
                var bytes = Convert.FromBase64String(encodeString);
                for (int i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = (byte)(bytes[i] - 1);
                }
                encodeString = Encoding.ASCII.GetString(bytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return encodeString;
            
        }
    }
}
