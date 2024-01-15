using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace _38_Goncharova_bob.NetWorkModel
{
    //поля
    class Neuron
    {
        private TypeNeuron _type;
        private double[] _weights;
        private double[] _inputs;
        private double _output;
        private double _derivative;
        //свойства
        public double[] Weights { get => _weights; set => _weights = value; }
        public double[] Inputs { get { return _inputs; } set { _inputs = value; } }
        public double Output { get => _output; }
        public double Derivative { get => _derivative; }
        public void Activator(double[] inpt, double[] wght)
        {
            double sum = wght[0];
            //double sum = 0;
            for (int m = 0; m < inpt.Length; m++)
            {
                sum += inpt[m] * wght[m + 1];
            }

            switch (_type)
            {
                case TypeNeuron.HiddenNeuron:
                    _output = TanhFunction(sum);
                    _derivative = TanhFunction_Derivative(sum);
                    break;

                case TypeNeuron.OutputNeuron:
                    _output = Exp(sum);
                    break;
            }
        }
        //
        public Neuron(double[] weight, TypeNeuron type)
        {
            _type = type;
            _weights = weight;
        }
       
        

        private double TanhFunction(double sum)
        {
            {
                return (Exp(sum) - Exp(-sum)) / (Exp(sum) + Exp(-sum));
                //for (int i = 0; i < _inputs.Length; i++)
                //    _inputs[i] = 1 / (1 + Exp(_inputs[i]));
                //return sum;
            }
        }

        private double TanhFunction_Derivative(double sum)
        {
            return 1 - (Exp(4 * sum) - 2 * Exp(2 * sum) + 1) / (Exp(4 * sum) + 2 * Exp(2 * sum) + 1);
            //for (int i = 0; i < _inputs.Length; i++)
            //    _inputs[i] = _inputs[i] * (1 - _inputs[i]);
            //return sum;
        }
    }
}
