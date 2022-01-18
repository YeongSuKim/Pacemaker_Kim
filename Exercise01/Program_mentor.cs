﻿using System;


namespace Exercise01
{
    class Program_mentor
    {

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // 실습예제 #1 데이터

        // 1) offset table:  각 station (row), waterline (column) 별 y값의 분포.  단위: mm
        //  1-1) station 수 21개
        static int[,] offsetTable1 = new int[,] {
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
        };

        //  1-2) station 수 22개
        static int[,] offsetTable2 = new int[,] {
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
            {0, 875, 2102, 3014, 3751, 4371, 4883, 5295, 5615, 5850, 6005, 6067, 6023, 5868, 5600, 5190, 4568},
        };

        //  2) station 간격.  단위: m
        static int station_interval = 16;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        // [문제 1]
        //  x 간격과 y값 3개가 주어졌을 때 면적을 구할 수 있는 simpson 함수를 완성하세요.
        static double Simpson(double dx, double y0, double y1, double y2)
        {
            return dx * (y0 + 4 * y1 + y2) / 3.0;
        }

        static double Trapezoidal(double dx, double y0, double y1)
        {
            return dx * (y0 + y1) * 0.5;
        }


        // [문제 2]
        //  주어진 waterline 에서의 수선면적 (waterline area) 구하는 함수를 완성하시오. (문제1의 함수 이용)
        static double Calculate_waterline_area(int w)
        {
            int[,] selectedTable;
            selectedTable = offsetTable2;

            // [문제 3] 문제 2를 완성 후, offsetTable2로 바꾸어 실행해 보세요. 결과가 같나요 다른가요?
            //          같다면 무엇이 문제일까요? 어떻게 처리해줘야 할까요? 코드를 보완해 보세요.
            // selectedTable = offsetTable2;


            // 문제 2 ~ 3 구현부
            double area = 0.0;

            int m = selectedTable.GetLength(0);   // number of stations
            int n = selectedTable.GetLength(1);   // number of waterlines

            double[] offsetList = new double[m];

            int i;
            for (i = 0; i < m; i++)
            {
                offsetList[i] = selectedTable[i, w] * 0.001;
            }

            for (i = 0; i < m - 2; i += 2)
            {
                double area_half_seg = Simpson(station_interval, offsetList[i], offsetList[i + 1], offsetList[i + 2]);

                area += area_half_seg * 2.0;
            }

            if (i < m - 1)
            {
                // area += station_interval * (offsetList[i] + offsetList[i+1]);

                double area_half_seg = Trapezoidal(station_interval, offsetList[i], offsetList[i + 1]);

                area += area_half_seg * 2.0;
            }

            return area;
        }


        // 진입점 중복을 방지하기 위해 Main_ 로 함수명 변경하였습니다.
        // 따라서 실행되지는 않으니 참고하세요.
        static void Main_(string[] args)
        {

            int n = offsetTable1.GetLength(1);   // number of waterlines

            while (true)
            {
                Console.Write(String.Format("Waterline 번호를 입력하시오 (0 ~ {0}) : ", n - 1));

                try
                {
                    int w = Convert.ToInt32(Console.ReadLine());

                    double area = Calculate_waterline_area(w);
                    Console.WriteLine("면적: " + area.ToString() + " m2");
                }
                catch (Exception e)
                {
                    Console.WriteLine("입력이 범위를 벗어났습니다. 종료합니다.");
                    break;
                }
            }

            // [문제 4]
            //  입력값이 허용범위를 벗어나면 에러 없이 무한루프를 탈출하여 종료할 수 있도록 프로그램의 완성도를 높여보세요.

        }
    }
}
