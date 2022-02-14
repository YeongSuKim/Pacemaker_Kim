using System;
using System.IO;
using System.Collections.Generic;


namespace LiveClinic05Example
{
    class Program
    {
        /*static int[,] offsetTable1_retire = new int[,] {
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1063},
            {0, 2406, 3206, 3565, 3678, 3619, 3402, 3131, 2968, 3001, 3252, 3827, 4814, 6329, 8317, 10380, 12274},
            {1980, 6807, 8190, 9059, 9678, 10145, 10541, 10954, 11466, 12154, 13093, 14276, 15597, 16949, 18245, 19424, 20493},
            {6384, 11580, 13364, 14648, 15724, 16688, 17598, 18500, 19402, 20311, 21228, 22144, 23039, 23885, 24666, 25372, 26001},
            {11520, 16453, 18528, 20045, 21296, 22410, 23415, 24310, 25106, 25826, 26471, 27039, 27541, 27979, 28357, 28679, 28953},
            {16608, 21227, 23138, 24564, 25705, 26633, 27391, 28007, 28502, 28896, 29207, 29450, 29636, 29775, 29875, 29944, 29984},
            {21264, 25255, 26779, 27784, 28512, 29058, 29454, 29723, 29891, 29978, 30000, 30000, 30000, 30000, 30000, 30000, 30000},
            {24816, 27985, 28981, 29547, 29861, 29990, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000},
            {26736, 29221, 29818, 29997, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000},
            {27400, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000},
            {27400, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000},
            {27400, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000},
            {27400, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000},
            {27400, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000},
            {27400, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000},
            {27400, 29449, 29930, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000},
            {25788, 28535, 29419, 29851, 29975, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000, 30000},
            {21972, 26146, 27478, 28336, 28935, 29340, 29586, 29706, 29754, 29760, 29760, 29760, 29760, 29760, 29760, 29760, 29760},
            {15192, 21267, 23221, 24483, 25393, 26105, 26632, 26983, 27227, 27368, 27389, 27362, 27359, 27361, 27359, 27360, 27360},
            {5880, 12220, 14539, 16152, 17372, 18277, 19013, 19626, 20082, 20421, 20667, 20831, 20916, 20934, 20899, 20832, 20772},
            {0, 1875, 3102, 4014, 4751, 5371, 5883, 6295, 6615, 6850, 7005, 7067, 7023, 6868, 6600, 6190, 5568},
        };*/

        static double station_interval = 16.0;
        static double waterline_interval = 1.0;



        static int[,] ReadOffsetData(string filename)
        {
            int[,] offset = null;

            using (FileStream fs = new FileStream(filename, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                List<int[]> offset_list = new List<int[]>();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] str_vals = line.Split(',');
                    int[] vals = new int[str_vals.Length];

                    for (int i = 0; i < str_vals.Length; i++)
                    {
                        vals[i] = Convert.ToInt32(str_vals[i]);
                    }

                    offset_list.Add(vals);
                }

                // for return as int[,] type
                offset = new int[offset_list.Count, offset_list[0].Length];

                for (int i = 0; i < offset_list.Count; i++)
                {
                    for (int j = 0; j < offset_list[0].Length; j++)
                    {
                        offset[i, j] = offset_list[i][j];
                    }
                }
            }

            return offset;
        }


        static void WriteOffsetData(string filename, int[,] data)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    string line = "";

                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        line += ", " + data[i, j].ToString();
                    }

                    line = line.Trim(',', ' ');
                    sw.WriteLine(line);
                }
            }
        }



        static void Main(string[] args)
        {
            // Write .csv file
            // WriteOffsetData("offset_output.csv", offsetTable1);

            // Read .csv file, get offset data
            int[,] offset_data = Program.ReadOffsetData("offset_input.csv");


            HydrostaticCalculator calc = new HydrostaticCalculator_Simpson1(offset_data, station_interval, waterline_interval);
            double[] areas = calc.Calculate_waterline_areas();

            Console.WriteLine(areas.Length);
            foreach (double area in areas)
            {
                Console.WriteLine(area);
            }

        }
    }
}
