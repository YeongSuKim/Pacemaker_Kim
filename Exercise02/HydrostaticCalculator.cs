using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise02
{
    // Offset table을 이용해서 유체정역학적 계산을 수행합니다.
    // 사다리꼴 공식을 이용해서 적분계산을 하는 계산기입니다.
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
            // offset table의 단위변환을 위한 코드
            int m = offset_mm.GetLength(0);
            int n = offset_mm.GetLength(1);

            this.offset_m = new double[m, n];
            for (int i = 0, j; i < m; i++)
                for (j = 0; j < n; j++)
                    this.offset_m[i, j] = (double)offset_mm[i, j] * 0.001;
        }


        // 문제1: 전체 waterline area (수선면적)을 모두 계산하는 함수를 작성하시오.
        //        최대한 이미 정의된 함수를 활용하시기 바랍니다. (중복된 코드 작성 지양)
        public double[] Calculate_waterline_areas()
        {









            return null;
        }

        // 하나의 waterline area를 계산하는 함수 (w 위치)
        protected double Calculate_waterline_area(int w)
        {
            double area = 0.0;

            int m = this.offset_m.GetLength(0);   // number of stations

            for (int s = 0; s < m - 1; s++)
            {
                area += 2.0 * Trapezoidal(s, w, axis: 0);
            }

            return area;
        }


        // 문제2: 다음은 사다리꼴 공식으로 면적 계산하는 함수입니다.
        //        왜 이렇게 짰을까? 원작자의 의도가 무엇일까 아래의 관점에서 생각해 보세요.
        //         1) double 값이 아니라 인덱스를 인자로 전달한 이유?
        //         2) axis의 목적은?
        //         3) 나중에 모멘트 계산할 때는 어떻게?
        protected double Trapezoidal(int s_pos, int w_pos, int axis = 0)
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



    // 문제3: HydrostaticCalculator 클래스를 상속 받아서 HydrostaticCalculator_Simpson1 클래스를 만들어 보세요.
    //        여기서는 Simpson1 법칙을 이용해서 적분 계산을 할 수 있도록 해보세요.
    //        최대한 부모 클래스의 요소들을 재사용하고, 꼭 필요한 부분만 override 해서 작성해 보세요.
    //        부모 클래스의 함수 중 하나는 virtual을 적용해야 할 것입니다.
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


        // 문제3-1: 어떤 함수를 override 해야 할까요? 해당 함수는 부모 클래스에서 virtual을 적용하고 여기에 override 해보세요.








        // 문제3-2:  Simpson1 함수를 여기에 작성해 보세요.
        //           부모 클래스에 작성한 Trapezoidal 함수를 참고해서 작성해 보세요.
        protected double Simpson1(int s_pos, int w_pos, int axis = 0)
        {












            return 0.0;
        }

    }
}
