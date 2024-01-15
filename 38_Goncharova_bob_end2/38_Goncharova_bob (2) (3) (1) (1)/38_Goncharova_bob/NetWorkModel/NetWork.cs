using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace _38_Goncharova_bob.NetWorkModel
{
    class NetWork
    {
        //все слои сети
        private InputLayer input_layer = null;
        private HiddenLayer hidden_layer1 = new HiddenLayer(71, 15, TypeNeuron.HiddenNeuron, nameof(hidden_layer1));
        private HiddenLayer hidden_layer2 = new HiddenLayer(32, 71, TypeNeuron.HiddenNeuron, nameof(hidden_layer2));
        private OutputLayer output_layer = new OutputLayer(10, 32, TypeNeuron.OutputNeuron, nameof(output_layer));
        //массив для хранения выходного слоя сети
        public double[] fact = new double[10];
        private double[] e_error_avr;
        //среднее значение энергии ошибки эпохи обучения
        public double[] E_error_avr
        {
            get => e_error_avr;
            set => e_error_avr = value;
        }
        public NetWork(NetWorkMode nm)
        {
            input_layer = new InputLayer(nm);
        }
        internal void ForwardPass(NetWork net, double[] netInput)
        {
            net.hidden_layer1.Data = netInput;
            net.hidden_layer1.Recognize(null, net.hidden_layer2);
            net.hidden_layer2.Recognize(null, net.output_layer);
            net.output_layer.Recognize(net, null);
        }
        public void Train(NetWork net)
        {
            int epoches = 70; //кол-во эпох
            net.input_layer = new InputLayer(NetWorkMode.Train);
            double tmpSumError;//временная переменная
            double[] errors;
            double[] temp_gsums1;//вектор градиента1
            double[] temp_gsums2;//вектор градиента2

            e_error_avr = new double[epoches];
            for (int k = 0; k < epoches; k++)
            {
                e_error_avr[k] = 0;
                for (int i = 0; i < net.input_layer.Trainset.Length; i++)
                {
                    ForwardPass(net, net.input_layer.Trainset[i].Item1);
                    tmpSumError = 0;
                    errors = new double[net.fact.Length];
                    for (int x = 0; x < errors.Length; x++)
                    {
                        if (x == net.input_layer.Trainset[i].Item2)
                        {
                            errors[x] = -(net.fact[x]-1.0);
                        }
                        else
                        {
                            errors[x] = -net.fact[x];
                        }
                            
                        tmpSumError += errors[x] * errors[x] / 2;
                    }
                    e_error_avr[k] += tmpSumError / errors.Length;
                    //обратный проход и коррекция весов
                    temp_gsums2 = net.output_layer.BackwardPass(errors);
                    temp_gsums1 = net.hidden_layer2.BackwardPass(temp_gsums2);
                    net.hidden_layer1.BackwardPass(temp_gsums1);
                }
                e_error_avr[k] /= net.input_layer.Trainset.Length; //среднее значение
            }
            net.input_layer = null;//обнуление (уборка) входноого слоя
            //запись скорректированных весов в "память"
            net.hidden_layer1.WeightInitialize(MemoryMode.SET, nameof(hidden_layer1) + "_memory.csv", hidden_layer1.Get_Weights());
            net.hidden_layer2.WeightInitialize(MemoryMode.SET, nameof(hidden_layer2) + "_memory.csv", hidden_layer2.Get_Weights());
            net.output_layer.WeightInitialize(MemoryMode.SET, nameof(output_layer) + "_memory.csv", output_layer.Get_Weights());


        }

        //internal void ForwardPass(double[] inputData)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
