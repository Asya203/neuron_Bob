using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _38_Goncharova_bob.NetWorkModel
{
     class InputLayer
    {
        private Random random = new Random();
        //поля
        private (double[], int)[] trainset = new (double[], int)[100];//100 изображений в обучающей
        //свойства
        public(double[], int)[] Trainset
        {
            get { return trainset; }
        }
        public InputLayer(NetWorkMode nm)
        {
            //string path_file;
            switch (nm)
            {
                 //код считывания обучающего множества и формирования массива Traise
                case NetWorkMode.Train:
                string[] str_trainset = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Test_studing/TrainingSample_All.txt");
                 
                for (int i = 0; i < str_trainset.Length; i++)
                {
                    string[] temp_elemnt = str_trainset[i].Split(' ');
                    double[] tmp_w = new double[temp_elemnt.Length - 1];
                        
                    for (int j = 1; j < temp_elemnt.Length; j++)
                        {
                            tmp_w[j - 1] = double.Parse(temp_elemnt[j]);
                        }
                        //trainset[i].Item1[j] = double.Parse(temp_elemnt[j].Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                        //trainset[i].Item2 = int.Parse(temp_elemnt[0].Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                        trainset[i].Item1 = tmp_w;
                        trainset[i].Item2 = int.Parse(temp_elemnt[0]);
                    }
                break;
            case NetWorkMode.Test:
                break;
            case NetWorkMode.Recognaiz:
                break;

            }
            
            
        }
    }
}
