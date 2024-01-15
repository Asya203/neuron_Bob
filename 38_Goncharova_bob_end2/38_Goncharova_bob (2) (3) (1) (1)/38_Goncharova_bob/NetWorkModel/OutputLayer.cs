using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _38_Goncharova_bob.NetWorkModel
{
    class OutputLayer : Layer
    {
        public OutputLayer(int non, int nopn, TypeNeuron nt, string type):
            base(non, nopn, nt, type)
        { }
        public override void Recognize(NetWork net, Layer nextLayer)
        {
            double e_sum = 0;
            for (int i = 0; i < Neurons.Length; ++i)
                e_sum += Neurons[i].Output;
            for (int i = 0; i < Neurons.Length; i++)
                net.fact[i] = Neurons[i].Output / e_sum;

        }
        public override double[] BackwardPass(double[] errors)
        {
            double[] gr_sum = new double[numofprevneurons + 1];
            // будет прописан код обратного прохода и коррекции весов
            for (int j = 0;j < numofprevneurons + 1; ++j)
            {
                double sum = 0;
                for(int k = 0; k < numofneurons; k++)
                {
                    sum += Neurons[k].Weights[j] * errors[k];
                } 
                gr_sum[j] = sum;
            }
            //цикл поправки весов и вычисление весов
            for (int i = 0; i < numofneurons; i++)
            {
                for (int n = 0; n < numofprevneurons + 1; n++) 
                {
                    double deltaw = 0;
                    if (n == 0)
                    {
                        deltaw = momentum * lastdeltaweights[i,0] + learningrate * errors[i];//найти формулу в лекциях
                    }
                    else
                    {
                        deltaw = momentum * lastdeltaweights[i, n] + learningrate * Neurons[i].Inputs[n - 1] * errors[i];//найти формулу в лекциях
                    }
                           
                    lastdeltaweights[i,n] = deltaw;
                    Neurons[i].Weights[n] += deltaw;//корекция весов
                }
            }
            
            return gr_sum;
        }
    }

}
