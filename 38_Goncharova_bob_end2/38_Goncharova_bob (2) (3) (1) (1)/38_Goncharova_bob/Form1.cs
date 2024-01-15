using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using _38_Goncharova_bob.NetWorkModel;
using static System.Windows.Forms.AxHost;


namespace _38_Goncharova_bob
{
    public partial class Form1 : Form
    {
        NetWork netWork;
        Neuron neuron;
        Layer layer;
        OutputLayer outputLayer;
        InputLayer inputLayer;
        HiddenLayer hiddenLayer;

        NetWorkModel.NetWork network;

        public Form1()
        {
            InitializeComponent();
            network = new NetWorkModel.NetWork(NetWorkModel.NetWorkMode.Recognaiz);
        }
        
            private double[] inputData = new double[15];
       
        private void ChngStatButton(Button b, int index)
        {
            if (b.BackColor == Color.White)
            {
                b.BackColor = Color.Black;
                inputData[index] = 1;
            }
            else if (b.BackColor == Color.Black )
            { b.BackColor = Color.White;
                inputData[index] = 0;
            }
        } 

        

        private void button1_Click(object sender, EventArgs e)
        {
           ChngStatButton(button1, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
              ChngStatButton(button2, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
                ChngStatButton(button3, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
                ChngStatButton(button4, 3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
                ChngStatButton(button5, 4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChngStatButton(button6, 5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChngStatButton(button7, 6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChngStatButton(button8, 7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChngStatButton(button9, 8);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ChngStatButton(button10, 9);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ChngStatButton(button11, 10);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ChngStatButton(button12, 11);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ChngStatButton(button13, 12);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ChngStatButton(button14, 13);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ChngStatButton(button15, 14);
        }
        //*
    private string docPath = AppDomain.CurrentDomain.BaseDirectory + "Test_studing/TrainingSample_One.txt";

        private void button_TrainOne_Click(object sender, EventArgs e)
        {
            string strDate = numericUpDown1.Value.ToString();
            for (int i = 0; i < inputData.Length; i++)
            {
                strDate += " " + inputData[i].ToString();
            }
            File.AppendAllText(docPath, strDate + Environment.NewLine);
        }
        //*
        private string docPath1 = AppDomain.CurrentDomain.BaseDirectory + "Test_studing/TrainingSample_All.txt";
        private void button_TrainAll_Click(object sender, EventArgs e)
        {
            string strDate = numericUpDown1.Value.ToString();
            for (int i = 0; i < inputData.Length; i++)
            {
                strDate += " " + inputData[i].ToString();
            }
            File.AppendAllText(docPath1, strDate + Environment.NewLine);
        }
        //
        
        public double[] NetOutput
        {
        set
        {
            Label_Output.Text = value.ToList().IndexOf(value.Max()).ToString();
        }
        }

        private void rec_Click(object sender, EventArgs e)
        {
            //netWork.ForwardPass(netWork, inputData);
            //Label_Output.Text = Array.IndexOf(netWork.fact, netWork.fact.Max()).ToString();
            //netWork.ForwardPass(inputData);
            //int maxIndex = Array.IndexOf(netWork.fact, netWork.fact.Max());
            //Label_Output.Text = maxIndex.ToString();
            network.ForwardPass(network, inputData);
            Label_Output.Text = Array.IndexOf(network.fact, network.fact.Max()).ToString();
        }

        //*
        private void Traing_Click(object sender, EventArgs e)
        {
            network.Train(network);
            chart1.Series[0].Points.Clear();
            //double[] Y = netWork.E_error_avr;
            for (int i = 0; i < network.E_error_avr.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i + 1, network.E_error_avr[i]);
            }
            //здесь код построения графика построения ошибки по эпохам
        }
               
        private void Save_Click(object sender, EventArgs e)
        {
            //PathFileTest = AppDomain.CurrentDomain.BaseDirectory + "Test_studing/TrainingSample_One.txt";
            //textLine = 
            //docPath1 = AppDomain.CurrentDomain.BaseDirectory + "Test_studing/TrainingSample_One.txt";
            string strDate = numericUpDown1.Value.ToString() + " ";
            for (int i = 0; i < inputData.Length; i++)
            {
                if (i < inputData.Length - 1)
                    strDate += inputData[i].ToString() + " ";
                else
                    strDate += inputData[i].ToString();
            }
            strDate += "\n";

            if (!File.Exists(docPath1))
            {
                MessageBox.Show("Нет такого файла");
                File.WriteAllText(docPath1, strDate);
            }
            else
            {
                File.AppendAllText(docPath1, strDate);
            }
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
    

}