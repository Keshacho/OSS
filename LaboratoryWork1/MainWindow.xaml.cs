﻿using Microsoft.Win32;
using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LaboratoryWork1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ArrayList CurrentArray = new ArrayList();

        public MainWindow()
        {
            InitializeComponent();
            string[] TasksArray = { "Расчет №1", "Расчет №2", "Задание №1", "Задание №2", "Задание №3", "Задание №4", "Задание №5", "Задание №6", "[Blue] Задание №2", "[Green] Задание №3", "[Green] Задание №6", "[Green] Задание №7" };
            for (int index = 0; index < TasksArray.Length; index++)
            {
                comboBox_tasks.Items.Add(TasksArray[index]);
            }
            comboBox_tasks.SelectedIndex = 0;
        }

        private void GenArrList(ArrayList myAL, int ItemCount)
        {
            Random rnd1 = new Random();
            int number;
            for (int index = 0; index < ItemCount; index++)
            {
                number = -100 + rnd1.Next(200);
                myAL.Add(number);
            }
        } //Генерация ArrayList случайными числами

        private void OutArrList(ArrayList myAL, ListBox myLB)
        {
            for (int index = 0; index < myAL.Count; index++)
            {
                myLB.Items.Add(myAL[index]);
            }
        } //Вывод ArrayList в ListBox

        private int Task1(ArrayList myAL) //1. Дан массив из n чисел. Сколько элементов массива больше своих «соседей»,­ т.е. предыдущег­о и последующе­го. Первый и последний элементы не рассматрив­ать.
        {
            int testcout = 0;
            for (int i = 1; i < myAL.Count - 1; i++)
            {
                if ((int)myAL[i] > (int)myAL[i - 1] && (int)myAL[i] > (int)myAL[i + 1]) testcout++;
            }
            return testcout;
        }

        private int Task2(ArrayList myAL) //2. Для массива из n чисел найти номер первого элемента, большего 25.
        {
            int item_number = -1;
            for (int i = 0; i < myAL.Count; i++)
            {
                if ((int)myAL[i] > 25)
                {
                    item_number = i;
                    break;
                }
            }
            return item_number;
        }

        private int Task3(ArrayList myAL) //3. В массиве из n чисел найти сумму элементов больших, чем второй элемент этого массива.
        {
            int sum = 0;
            for (int i = 0; i < myAL.Count; i++)
            {
                if ((int)myAL[i] > (int)myAL[1])
                {
                    sum += (int)myAL[i];
                }
            }
            return sum;
        }

        private int Task4(ArrayList myAL, int k) //4. Для массива из n чисел найти номер первого элемента большего K, где K вводится в отдельном дочернем или диалоговом окне.
        {
            int Item_number = -1;
            for (int i = 0; i < myAL.Count; i++)
            {
                if ((int)myAL[i] > k)
                {
                    Item_number = i;
                    break;
                }
            }
            return Item_number;
        }

        private int Task5(ArrayList myAL, int k) //5. В массиве из n чисел найти сумму элементов больших, чем K-ый по счету элемент этого массива, где K вводится в отдельном дочернем или диалоговом окне
        {
            int sum = 0;
            for (int i = 0; i < myAL.Count; i++)
            {
                if ((int)myAL[i] > (int)myAL[k-1])
                {
                    sum += (int)myAL[i];
                }
            }
            return sum;
        }

        private void Task6(ArrayList myAL, ListBox myLB) //6*. Дан массив из n чисел. Выделите, те элементы массива, что больше своих «соседей»,­ т.е. предыдущег­о и последующе­го. Первый и последний элементы не рассматрив­ать.
        {
            for (int i = 0; i < myAL.Count; i++)
            {
                if (i > 0 && i < myAL.Count - 1)
                {
                    if ((int)myAL[i] > (int)myAL[i - 1] && (int)myAL[i] > (int)myAL[i + 1])
                    {
                        myLB.Items.Add(new ListBoxItem() { Content = myAL[i], Foreground = Brushes.RoyalBlue });
                    }
                    else myLB.Items.Add(myAL[i]);
                }
                else myLB.Items.Add(myAL[i]);
            }
        }

        private int BlueTask2(ArrayList myAL) //2. Дан массив из K чисел. Сколько элементов массива меньше своих «соседей», т.е. предыдущего и последующего. Первый и последний элементы массива считаются соседними, т.е. массив представляет из себя кольцевой список.
        {
            int count = 0;
            for (int i = 0; i < myAL.Count; i++)
            {
                if (i == 0 && ((int)myAL[i] > (int)myAL[myAL.Count - 1] && (int)myAL[i] > (int)myAL[i + 1]))
                {
                    count++;
                }
                if (i == myAL.Count - 1 && ((int)myAL[i] > (int)myAL[i - 1] && (int)myAL[i] > (int)myAL[0]))
                {
                    count++;
                }
                if ((i != 0 && i != myAL.Count - 1) && ((int)myAL[i] > (int)myAL[i - 1] && (int)myAL[i] > (int)myAL[i + 1]))
                {
                    count++;
                }
            }
            return count;
        }

        private int GreenTask3(ArrayList myAL) //3. Для массива из K чисел найти номер самого малого по значению элемента, значение которого больше среднего значения элементов массива.
        {
            int min, sum, average;
            sum = average = min = 0;
            for (int i = 0; i < myAL.Count; i++)
            {
                sum += (int)myAL[i];
            }
            average = sum / myAL.Count;
            for (int i = 0; i < myAL.Count; i++)
            {
                if ((int)myAL[i] > average && min == 0)
                {
                    min = (int)myAL[i];
                }
                else if (min > (int)myAL[i] && (int)myAL[i] > average)
                {
                    min = (int)myAL[i];
                }
            }
            return myAL.IndexOf(min) + 1;
        }

        private void GreenTask6(ArrayList myAL) //6. Дан массив из K чисел. Выведите к исходному массиву вместо значений элементов их отклонение от среднего значения элементов массива.
        {
            int sum, average;
            sum = average = 0;
            for (int i = 0; i < myAL.Count; i++)
            {
                sum += (int)myAL[i];
            }
            average = sum / myAL.Count;
            for (int i = 0; i < myAL.Count; i++)
            {
                myAL[i] = (int)myAL[i] - average;
            }
        }

        private void GreenTask7(ArrayList myAL) //7. Дан массив из K чисел. Найдите среднее значение элементов массива. Замените все элементы массива, отклонение от среднего значения которых больше половины среднего отклонения всех элементов, на среднее значение.
        {
            int sum = 0;
            double average, average_deviation;
            average = average_deviation = 0;
            for (int i = 0; i < myAL.Count; i++)
            {
                sum += (int)myAL[i];
            }
            average = sum / myAL.Count;
            for (int i = 0; i < myAL.Count; i++)
            {
                average_deviation += Math.Pow(((int)myAL[i] - average),2);
            }
            average_deviation = Math.Sqrt(average_deviation / myAL.Count);
            for (int i = 0; i < myAL.Count; i++)
            {
                if (Math.Abs((int)myAL[i] - average) > (average_deviation / 2))
                {
                    myAL[i] = Math.Round(average, 2);
                }
            }
        }

        private void button_task_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int itemCount = Convert.ToInt32(tbN.Text);

                if (comboBox_tasks.Text == "Расчет №1")
                {
                    lbMain.Items.Clear();
                    lbMain.Items.Add("Сгенерированный массив:");
                    ArrayList myAL = new ArrayList();
                    GenArrList(myAL, itemCount);
                    CurrentArray = myAL;
                    OutArrList(myAL, lbMain);
                }

                if (comboBox_tasks.Text == "Расчет №2")
                {
                    lbMain.Items.Clear();
                    lbMain.Items.Add("Сгенерированный массив:");
                    ArrayList myAL = new ArrayList();
                    GenArrList(myAL, itemCount);
                    OutArrList(myAL, lbMain);
                    myAL.Sort();
                    CurrentArray = myAL;
                    lbMain.Items.Add("Отсортированный массив:");
                    OutArrList(myAL, lbMain);
                }

                if (comboBox_tasks.Text == "Задание №1")
                {
                    lbMain.Items.Clear();
                    lbMain.Items.Add("Сгенерированный массив:");
                    ArrayList myAL = new ArrayList();
                    GenArrList(myAL, itemCount);
                    CurrentArray = myAL;
                    OutArrList(myAL, lbMain);
                    lbMain.Items.Add("Кол-во элементов массива больше своих «соседей»: " + Task1(myAL));
                }

                if (comboBox_tasks.Text == "Задание №2")
                {
                    lbMain.Items.Clear();
                    lbMain.Items.Add("Сгенерированный массив:");
                    ArrayList myAL = new ArrayList();
                    GenArrList(myAL, itemCount);
                    CurrentArray = myAL;
                    OutArrList(myAL, lbMain);
                    int item_num = Task2(myAL);
                    if (item_num == -1)
                    {
                        lbMain.Items.Add("В массиве нет элементов больше 25");
                    }
                    else lbMain.Items.Add("Номер первого элемента, больше 25: " + (item_num+1));
                }

                if (comboBox_tasks.Text == "Задание №3")
                {
                    lbMain.Items.Clear();
                    lbMain.Items.Add("Сгенерированный массив:");
                    ArrayList myAL = new ArrayList();
                    GenArrList(myAL, itemCount);
                    CurrentArray = myAL;
                    OutArrList(myAL, lbMain);
                    lbMain.Items.Add("Cумма элементов больших, чем второй элемент\nэтого массива: " + Task3(myAL));
                }

                if (comboBox_tasks.Text == "Задание №4")
                {
                    Window1 GetK = new Window1();

                    if (GetK.ShowDialog() == true)
                    {
                        int k = GetK.K;
                        lbMain.Items.Clear();
                        lbMain.Items.Add("Сгенерированный массив:");
                        ArrayList myAL = new ArrayList();
                        GenArrList(myAL, itemCount);
                        CurrentArray = myAL;
                        OutArrList(myAL, lbMain);
                        int item_num = Task4(myAL,k);
                        if (item_num == -1)
                        {
                            lbMain.Items.Add($"В массиве нет элементов больше " + k);
                        }
                        else lbMain.Items.Add($"Номер первого элемента, больше " + k + ": " + (item_num + 1));
                    }
                }

                if (comboBox_tasks.Text == "Задание №5")
                {
                    Window1 GetK = new Window1();

                    if (GetK.ShowDialog() == true)
                    {
                        int k = GetK.K;
                        lbMain.Items.Clear();
                        lbMain.Items.Add("Сгенерированный массив:");
                        ArrayList myAL = new ArrayList();
                        GenArrList(myAL, itemCount);
                        CurrentArray = myAL;
                        OutArrList(myAL, lbMain);
                        lbMain.Items.Add($"Cумма элементов больших, чем " + k + " элемент\nэтого массива: " + Task5(myAL,k));
                    }
                }

                if (comboBox_tasks.Text == "Задание №6")
                {
                    lbMain.Items.Clear();
                    lbMain.Items.Add("Сгенерированный массив:");
                    ArrayList myAL = new ArrayList();
                    GenArrList(myAL, itemCount);
                    CurrentArray = myAL;
                    Task6(myAL, lbMain);
                }

                if (comboBox_tasks.Text == "[Blue] Задание №2")
                {
                    lbMain.Items.Clear();
                    lbMain.Items.Add("Сгенерированный массив:");
                    ArrayList myAL = new ArrayList();
                    GenArrList(myAL, itemCount);
                    CurrentArray = myAL;
                    OutArrList(myAL, lbMain);
                    lbMain.Items.Add("Кол-во элементов массива больше своих «соседей»: " + BlueTask2(myAL));
                }

                if (comboBox_tasks.Text == "[Green] Задание №3")
                {
                    lbMain.Items.Clear();
                    lbMain.Items.Add("Сгенерированный массив:");
                    ArrayList myAL = new ArrayList();
                    GenArrList(myAL, itemCount);
                    CurrentArray = myAL;
                    OutArrList(myAL, lbMain);
                    lbMain.Items.Add("Номер самого малого по значению элемента, значение\nкоторого больше среднего значения элементов: " + GreenTask3(myAL));
                }

                if (comboBox_tasks.Text == "[Green] Задание №6")
                {
                    lbMain.Items.Clear();
                    lbMain.Items.Add("Сгенерированный массив:");
                    ArrayList myAL = new ArrayList();
                    GenArrList(myAL, itemCount);
                    OutArrList(myAL, lbMain);
                    lbMain.Items.Add("Измененный массив:");
                    GreenTask6(myAL);
                    CurrentArray = myAL;
                    OutArrList(myAL, lbMain);
                }

                if (comboBox_tasks.Text == "[Green] Задание №7")
                {
                    lbMain.Items.Clear();
                    lbMain.Items.Add("Сгенерированный массив:");
                    ArrayList myAL = new ArrayList();
                    GenArrList(myAL, itemCount);
                    OutArrList(myAL, lbMain);
                    lbMain.Items.Add("Измененный массив:");
                    GreenTask7(myAL);
                    CurrentArray = myAL;
                    OutArrList(myAL, lbMain);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка. Проверьте корректность введенных данных.", "Ошибка");
            }
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "Текст(*.TXT)|*.TXT" + "|Все файлы (*.*)|*.* ";

            if (myDialog.ShowDialog() == true)
            {
                string filename = myDialog.FileName;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false))
                {
                    foreach (Object item in lbMain.Items)
                    {
                        file.WriteLine(item);
                    }
                }
            }
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            lbMain.Items.Clear();
        }

        private void button_about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Авторы:\nТитова Д.С. - МФиИ, Группа 121171(3Б)\nЛасточкин К.И. - МФиИ, Группа 121171(3Б)", "Об авторе");
        }

        private void button_hist_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentArray.Count > 0)
            {
                histogram Hist = new histogram();
                Hist.CreatingHistogram(CurrentArray);
                Hist.Show();
            }
        }
    }
}