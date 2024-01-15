using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _38_Goncharova_bob.NetWorkModel
{
    
        class HiddenLayer : Layer
        {
            public HiddenLayer(int non, int nopn, TypeNeuron nt, string type) : base(non, nopn, nt, type) { }

            public override void Recognize(NetWork net, Layer nextLayer)
            {
                double[] hidden_out = new double[Neurons.Length];
                for (int i = 0; i < Neurons.Length; i++)
                    hidden_out[i] = Neurons[i].Output;
                nextLayer.Data = hidden_out;
            }
            public override double[] BackwardPass(double[] gr_sums)
            {
                double[] gr_sum = new double[numofprevneurons];
            for (int j = 0; j < gr_sum.Length; ++j)
            {
                double sum = 0;
                for (int k = 0; k < Neurons.Length; ++k)
                    sum += Neurons[k].Weights[j] * Neurons[k].Derivative * gr_sums[k];
                gr_sum[j] = sum;
            }
            for (int i = 0; i < numofneurons; ++i)
                for (int n = 0; n < numofprevneurons + 1; ++n)
                {
                    double deltaw = (n == 0) ? (momentum * lastdeltaweights[i, 0] + learningrate * Neurons[i].Derivative * gr_sums[i]) : (momentum * lastdeltaweights[i, n] + learningrate * Neurons[i].Inputs[n - 1] * Neurons[i].Derivative * gr_sums[i]);
                    lastdeltaweights[i, n] = deltaw;
                    Neurons[i].Weights[n] += deltaw;//найти формулу в лекциях
                }
            return gr_sum;
            }
        }
    
}
