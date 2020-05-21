using System;

namespace Практика_17
{
    static class Binar
    {
        public static uint ConvertBinToDec(uint Bin)
        {
            uint temp = 0;
            if (checker(Bin))
            {
                for (int i = 0; Bin > 0; i++)
                {
                    temp += (Bin % 10) * (uint)Math.Pow(2, i);
                    Bin /= 10;
                }
            }
            return temp;
        }
        static bool checker(uint Bin)
        {
            //string NStr = N.ToString();
            uint normalCounter = 0;
            if (Bin.ToString().Length - 1 == 0 && (Bin == 0 || Bin == 1)) return true;
            else if(Bin.ToString().Length - 1 == 0) return false;
            for (int i = 0; i < Bin.ToString().Length; i++)
            {
                if (Bin.ToString().Substring(i, 1) == "0" || Bin.ToString().Substring(i, 1) == "1") normalCounter++;
            }
            
            /*            foreach (char i in N.ToString())
                        {
                            if(i=='0'||i=='1') normalCounter++;
                        }*/
            if (normalCounter == Bin.ToString().Length) return true;
            else return false;
        }
        public static uint ConvertBinToOct(uint Bin)
        {// сделаю через обычное деление, но я сделал через строки
            uint temp = 0;
            if (checker(Bin))
            {
                string nStr = Bin.ToString();
                if (nStr.Length % 3 == 1) nStr = nStr.Insert(0, "00");
                if (nStr.Length % 3 == 2) nStr = nStr.Insert(0, "0");
                for (int i = 0; i < nStr.Length - 1; i += 3)
                {
                    temp *= 10;
                    temp += ConvertBinToDec(Convert.ToUInt32(nStr.Substring(i, 3)));
                }
            }

            /*            string tempStr = N.ToString();
                        if (tempStr.Length % 3 > 0)
                        {
                            string superTempStr = "";
                            for (int i = 0; i < tempStr.Length % 3 - 1; i++)
                            {
                                superTempStr += "0";
                            }
                            tempStr = tempStr.Insert(0, superTempStr);
                        }*/
            //for()
            return temp;
        }
    }
}
