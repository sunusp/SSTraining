using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.DateTime;
using static System.Math;

namespace CSharpconcepts
{
    public partial class CSharp6 : Form
    {
        public CSharp6()
        {
            InitializeComponent();
        }



        private void conditionalOperator_Click(object sender, EventArgs e)
        {
            List<Employee> employees1 = new List<Employee>();
            employees1.Add(new Employee { Id = 1, FirstName = "Emp 1" });
            employees1.Add(new Employee { Id = 2, LastName = "Emp 2" });

            int? length1 = employees1?.Count;   // if not null, get Count
            int length2 = employees1?.Count ?? 0;   // if not null, get Count. If null, get 0
            int empId = employees1?[0].Id ?? 0;     // if not null, get Id property value of first index
            int idSum = employees1?.Sum(i => i.Id) ?? 0;    // if not null, get sum of Id property. If null, get 0
        }

        private void indexInitializer_Click(object sender, EventArgs e)
        {
            var numbers = new Dictionary<int, string>
            {
                [7] = "seven",
                [9] = "nine",
                [13] = "thirteen"
            };
        }

        private void autoProperty_Click(object sender, EventArgs e)
        {
            MessageBox.Show(new Employee().ToString());
            //  new Employee().Email = "new Email";   --> This is not possible as the property is read-only
        }

        private void stringExpressions_Click(object sender, EventArgs e)
        {
            string myName = "sunu";
            int? myAge = 30;
            var introduction1 = $"My name is {myName}. I am {myAge} years old.";
            var introduction2 = $"My name is {myName}. I am {myAge:D3} years old.";
            var introduction3 = $"My name is {myName}. I am {myAge ?? 0} years old.";

            Employee employee = new Employee();
            var objects = $"Employee Id is {employee.Id}";

        }

        private void staticUsing_Click(object sender, EventArgs e)
        {
            var currentTime = Now.TimeOfDay; // System.DateTime is defined as static
            var number = Math.Floor(1.7);   // System.Math is defined as static
        }

        private void expressionBodiedFunction_Click(object sender, EventArgs e)
        {
            MessageBox.Show(addNumbers(1, 2).ToString());   // addNumbers is defined as expression bodied function
        }

        private double addNumbers(int number1, int number2)
            => number1 + number2; //expression Bodied Function

        public string helloWorld(string name)
            => $"Your name is {name}";

        private void helloWorld()
            => MessageBox.Show("Hai Sunu");

        private void exceptionFiltering_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            var randomExceptions = random.Next(400, 402);
            try
            {
                throw new Exception(randomExceptions.ToString());
            }
            catch (Exception ex) when (ex.Message.Equals("400"))
            {
                MessageBox.Show("Bad Request");
            }
            catch (Exception ex) when (ex.Message.Equals("401"))
            {
                MessageBox.Show("Unauthorized");
            }
            catch (Exception ex) when (ex.Message.Equals("402"))
            {
                MessageBox.Show("Payment Required");
            }
        }

        private void awaitInTryCatchFinally_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => GetWeather());
        }
        private async static Task GetWeather()
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync
                ("http://api.openweathermap.org/data/2.5/weather?q=Dhaka,bd");
                MessageBox.Show(result);
            }
            catch (Exception exception)
            {
                try
                {
                    /* If the first request throws an exception, 
                	this request will be executed. 
                        Both are asynchronous request to a weather service*/

                    var result = await client.GetStringAsync
                    ("http://api.openweathermap.org/data/2.5/weather?q=NewYork,us");

                    MessageBox.Show(result);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void primaryConstructors_Click(object sender, EventArgs e)
        {

        }

        private void nameofExpressions_Click(object sender, EventArgs e)
        {

        }
    }

    public class Employee
    {
        public int Id { get; set; } = 10;
        public string FirstName { get; set; } = "Sunu";

        public string LastName { get; set; } = "Surendran"; // 

        public string FullName => $"{FirstName}-{LastName}"; //expression Bodied Property

        public override string ToString() => FullName; // overriden method

        public string Email { get; } = "My Email";  // Read only property

    }
}
