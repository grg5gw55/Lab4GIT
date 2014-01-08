using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Alg_Lab2
{
    public partial class Form1 : Form
    {
        int[] Arr = new int[500];
        int[] Arr2 = new int[500];
        int countArr = 0;
        int countArr2 = 0;
        Random rnd = new Random();
        int count1 = 0, count2 = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int tbInt = Convert.ToInt32(textBox1.Text);
                Arr[countArr] = tbInt;
                Arr2[countArr] = tbInt;
                ++countArr;
                ++countArr2;
                updateArr();
                textBox1.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Введено не число!");
            }
        }

        private void updateArr()
        {
            if (countArr > 0)
            {
                label1.Text = "";
                label1.Text = label1.Text + Arr[0];
                for (int i = 1; i < countArr; ++i)
                    label1.Text = label1.Text + " " + Arr[i];
            }
            else label1.Text = "Элементы отсутствуют";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int tbInt = Convert.ToInt32(textBox2.Text);
                countArr = 0;
                countArr2 = 0;
                for (int i = 0; i < tbInt; ++i)
                {
                    Arr[i] = Arr2[i] = rnd.Next(0, 10);
                    ++countArr;
                    ++countArr2;
                }
                updateArr();
                textBox2.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Введено не число!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShellSort();
            updateArr();
            MessageBox.Show("Число сравнений: " + count1 + "\n" +
                            "Число перестановок: " + count2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShekerSort();
            updateArr();
            MessageBox.Show("Число сравнений: " + count1 + "\n" +
                            "Число перестановок: " + count2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < countArr; ++i)
                Arr[i] = Arr2[i];
            updateArr();
        }

        /* Сортировка Шелла */
        private void ShellSort()
        {
            int j;
            int step = countArr / 2;
            while (step > 0)
            {
                for (int i = 0; i < (countArr - step); i++)
                {
                    j = i;
                    ++count1;
                    while ((j >= 0) && (Arr[j] > Arr[j + step]))
                    {
                        ++count2;
                        int tmp = Arr[j];
                        Arr[j] = Arr[j + step];
                        Arr[j + step] = tmp;
                        j--;
                    }
                }
                step = step / 2;
            }
        }

        /* Шейкерная сортировка */
        void ShekerSort()
        {
            int i, left, right, b, t;
            for (right = countArr - 1, left = 0, b = -1; b != 0; )
            {
                b = 0;
                for (i = left; i < right; i++)
                {
                    ++count1;
                    if (Arr[i] > Arr[i + 1])
                    { t = Arr[i]; Arr[i] = Arr[i + 1]; Arr[i + 1] = t; b = i; ++count2; }
                }
                right = b;
                for (i = right; i > left; i--)
                {
                    ++count1;
                    if (Arr[i - 1] > Arr[i])
                    { t = Arr[i]; Arr[i] = Arr[i - 1]; Arr[i - 1] = t; b = i; ++count2; }
                }
                left = b;
            }
        }
    }
}
