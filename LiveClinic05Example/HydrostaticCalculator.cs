using System;


namespace LiveClinic05Example
{
    class HydrostaticCalculator
    {
        // offset table과 station 간격을 저장할 멤버 변수 (둘 다 meter 단위)
        protected double[,] offset_m;
        protected double ds_m;
        protected double dw_m;


        // 생성자 (m 단위로 입력되는 경우)
        public HydrostaticCalculator(double[,] offset_m, double ds_m, double dw_m)
        {
            this.offset_m = offset_m;
            this.ds_m = ds_m;
            this.dw_m = dw_m;
        }

        // 생성자 (mm 단위로 입력되는 경우)
        public HydrostaticCalculator(int[,] offset_mm, double ds_m, double dw_m)
            : this((double[,])null, ds_m, dw_m)
        {
            int m = offset_mm.GetLength(0);
            int n = offset_mm.GetLength(1);

            this.offset_m = new double[m, n];
            for (int i = 0, j; i < m; i++)
                for (j = 0; j < n; j++)
                    this.offset_m[i, j] = (double)offset_mm[i, j] * 0.001;
        }

        // 전체 waterline area (수선면적)을 모두 계산하는 함수
        public double[] Calculate_waterline_areas()
        {
            int n = this.offset_m.GetLength(1);   // number of waterlines

            double[] areas = new double[n];

            for (int w = 0; w < n; w++)
            {
                areas[w] = Calculate_waterline_area(w);
            }

            return areas;
        }

        // 하나의 waterline area를 계산하는 함수 (w 위치)
        protected virtual double Calculate_waterline_area(int w)
        {
            double area = 0.0;

            int m = this.offset_m.GetLength(0);   // number of stations

            for (int s = 0; s < m - 1; s++)
            {
                area += 2.0 * Trapezoidal(s, w, axis: 0);
            }

            return area;
        }

        // 사다리꼴 공식으로 면적 계산
        //  나중에 함수를 인자로 전달하여 일반화 해보자 (모멘트 계산 등에 사용할 수 있도록)
        protected double Trapezoidal(int s_pos, int w_pos, int axis=0)
        {
            double x, y1, y2;
            if (axis == 0)
            {
                x = this.ds_m;
                y1 = this.offset_m[s_pos, w_pos];
                y2 = this.offset_m[s_pos + 1, w_pos];
            }
            else if (axis == 1)
            {
                x = this.dw_m;
                y1 = this.offset_m[s_pos, w_pos];
                y2 = this.offset_m[s_pos, w_pos + 1];
            }
            else
            {
                throw new Exception("axis가 범위를 벗어났습니다.");
            }

            return 0.5 * x * (y1 + y2);
        }

    }



    class HydrostaticCalculator_Simpson1 : HydrostaticCalculator
    {

        public HydrostaticCalculator_Simpson1(double[,] offset_m, double ds_m, double dw_m)
            : base(offset_m, ds_m, dw_m)
        {
        }

        public HydrostaticCalculator_Simpson1(int[,] offset_mm, double ds_m, double dw_m)
            : base(offset_mm, ds_m, dw_m)
        {
        }

        protected override double Calculate_waterline_area(int w)
        {
            double area = 0.0;

            int m = this.offset_m.GetLength(0);   // number of stations

            int s;
            for (s = 0; s < m - 2; s += 2)
            {
                area += 2.0 * Simpson1(s, w, axis: 0);
            }

            if (s < m - 1)
            {
                area += 2.0 * Trapezoidal(s, w, axis: 0);
            }
            return area;
        }

        protected double Simpson1(int s_pos, int w_pos, int axis = 0)
        {
            double x, y1, y2, y3;
            if (axis == 0)
            {
                x = this.ds_m;
                y1 = this.offset_m[s_pos, w_pos];
                y2 = this.offset_m[s_pos + 1, w_pos];
                y3 = this.offset_m[s_pos + 2, w_pos];
            }
            else if (axis == 1)
            {
                x = this.dw_m;
                y1 = this.offset_m[s_pos, w_pos];
                y2 = this.offset_m[s_pos, w_pos + 1];
                y3 = this.offset_m[s_pos, w_pos + 2];
            }
            else
            {
                throw new Exception("axis가 범위를 벗어났습니다.");
            }

            return x * (y1 + 4 * y2 + y3) / 3.0;
        }

    }

}
