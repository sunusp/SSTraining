using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpconcepts
{
    public partial class CSharpProblems : Form
    {
        public CSharpProblems()
        {
            InitializeComponent();
        }

        private long FindSumEven(int[] array)
        {
            return array.Where(i => i % 2 == 0).Sum(i => (long)i);
        }
        private void arrayCount_Click(object sender, EventArgs e)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MessageBox.Show(FindSumEven(array).ToString());

        }

        private void convertToDecimal_Click(object sender, EventArgs e)
        {
            var itemModified = string.Empty;
            var array = new double[] { 1000, 10.24, 15, 200.67, 12345, 78263874, 646.82623, 52376, 2635 };
            List<decimal> decArray = new List<decimal>();

            foreach (var item in array)
            {
                if (!(item - Math.Round(item) != 0))
                {
                    itemModified = (item / 100).ToString("F");
                    decArray.Add(Convert.ToDecimal(itemModified));
                }
            }
        }

        private void Day1_SumOfDigits_Click(object sender, EventArgs e)
        {
            var puzzleArray = day1_Sum_part1.Text?
                .Select(n => Convert.ToInt32(n.ToString()))
                .ToList();
            var puzzleArrayCount = puzzleArray?.Count();
            var sum = 0;

            if (puzzleArrayCount > 1)
            {
                for (var count = 0; count < puzzleArrayCount - 1; count++)
                {
                    if(puzzleArrayCount > 2)
                    {
                        if (puzzleArray.ElementAt(count) == puzzleArray.ElementAt(count + 1))
                            sum += puzzleArray.ElementAt(count);
                    }
                }

                if (puzzleArray.ElementAt(0) == puzzleArray.ElementAt(puzzleArray.Count() - 1))
                {
                    sum += puzzleArray.ElementAt(0);
                }
            }

            MessageBox.Show(sum.ToString());
        }

        private void Day1_SumOfDigits_part2_Click(object sender, EventArgs e)
        {
            var sum = 0;
            var puzzleArray = day1_Sum_part2.Text?
                .Select(n => Convert.ToInt32(n.ToString()))
                .ToList();

            var puzzleArrayCount = puzzleArray.Count();
            if (puzzleArrayCount % 2 == 0)
            {
                var puzzleArray1 = puzzleArray.Take(puzzleArrayCount / 2);
                var puzzleArray2 = puzzleArray.Skip(puzzleArrayCount / 2);

                for (var count = 0; count < puzzleArrayCount / 2; count++)
                {
                    if (puzzleArray1.ElementAt(count) == puzzleArray2.ElementAt(count))
                    {
                        sum += puzzleArray1.ElementAt(count) + puzzleArray2.ElementAt(count);
                    }
                }
                MessageBox.Show(sum.ToString());
            }
            else
                MessageBox.Show("Please enter a valid number.");

        }



        private void day2_checksum_Click(object sender, EventArgs e)
        {
            var array1 = day2_findCheckSum_array1.Text?
                .Split(' ')
                .Select(n => Convert.ToInt32(n.ToString()))
                .ToList();
            var array2 = day2_findCheckSum_array2.Text?
                .Split(' ')
                .Select(n => Convert.ToInt32(n.ToString()))
                .ToList();
            var array3 = day2_findCheckSum_array3.Text?
                .Split(' ')
                .Select(n => Convert.ToInt32(n.ToString()))
                .ToList();
            var array4 = day2_findCheckSum_array4.Text?
                .Split(' ')
                .Select(n => Convert.ToInt32(n.ToString()))
                .ToList();

            var array1_difference = array1.Max() - array1.Min();
            var array2_difference = array2.Max() - array2.Min();
            var array3_difference = array3.Max() - array3.Min();
            var array4_difference = array4.Max() - array4.Min();

            var arrayChecksum = array1_difference + array2_difference + array3_difference + array4_difference;

            MessageBox.Show($"Checksum={array1_difference}" +
                $"+{array2_difference}" +
                $"+{array3_difference}" +
                $"+{array4_difference}" +
                $"={arrayChecksum}");
        }

        private void day4_EntropyPassphrases_Click(object sender, EventArgs e)
        {
            var entropyPassphrasesArray = day4_EntropyPassphrases_input.Text?
                .Split(' ')
                .ToList();

            var validItemsCount = entropyPassphrasesArray
                .GroupBy(x => x)
                 .Where(g => g.Count() == 1)
                 .Count();

            var invalidItemsCount = entropyPassphrasesArray
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Count();

            MessageBox.Show($"Valid passphrases : {validItemsCount.ToString()}, " +
                            $"Invalid passphrases: { invalidItemsCount.ToString()}");
        }
    }
}
