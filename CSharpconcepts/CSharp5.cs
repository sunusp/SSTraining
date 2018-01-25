using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpconcepts
{
    public partial class CSharp5 : Form
    {
        public CSharp5()
        {
            InitializeComponent();
        }

        /// <summary>
        /// https://www.codeproject.com/Articles/575713/What-is-the-use-of-csharp-Yield-keyword
        /// Customized iteration through a collection without creating a temporary collection.
        /// Stateful iteration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yield_Click(object sender, EventArgs e)
        {
            var result = getNumbers();   // Here use of temporary array is avoided by using YIELD keyword
            var sum = getSum();     // returns 
        }

        private IEnumerable<int> getNumbers()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            foreach (var item in array)
            {
                if (item < 5)
                    yield return item;
            }
        }

        private IEnumerable<int> getSum()
        {
            var sumNumber = 0;
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            foreach (var item in array)
            {
                sumNumber += item;
                yield return sumNumber;
            }
        }

        private int addNumbers(int num1, int num2)
            => num1 + num2;

        private int multiplyNumbers(int num1, int num2)
            => num1 * num2;

        static string str = "hello";
        delegate int arithematicOperationsDeligate(int num1, int num2);
        /// <summary>
        /// https://www.codeproject.com/Articles/772792/Delegates-and-Types-of-Delegates-in-Csharp
        /// https://msdn.microsoft.com/en-gb/library/aa288459(v=vs.71).aspx
        /// https://www.tutorialspoint.com/csharp/csharp_delegates.htm
        /// https://www.codeproject.com/Articles/4773/Events-and-Delegates-Simplified
        /// http://www.c-sharpcorner.com/uploadfile/84c85b/delegates-and-events-c-sharp-net/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delegate_Click(object sender, EventArgs e)
        {
            //Single Delegate - can be used to invoke a single method
            arithematicOperationsDeligate addNumbersDeligate = new arithematicOperationsDeligate(addNumbers);
            var result1 = addNumbersDeligate(1, 2);

            // multicast delegate
            arithematicOperationsDeligate numbersAddDeligate = new arithematicOperationsDeligate(addNumbers);
            arithematicOperationsDeligate numbersMultiplyDeligate = new arithematicOperationsDeligate(multiplyNumbers);
            arithematicOperationsDeligate multicastDelegate;
            multicastDelegate = numbersAddDeligate;
            multicastDelegate += numbersMultiplyDeligate;
            var result2 = multicastDelegate(1, 2);
        }


        void showName(string name) => MessageBox.Show(name);
        void showIntroudction(string name, string age) => MessageBox.Show($"Welcome {name}. You are {age} years old.");

        delegate void PrintName(string message);
        delegate void PrintIntroudction(string name, string age);

        private void test_Click(object sender, EventArgs e)
        {
            PrintName printName = new PrintName(showName);
            printName("Hai");

            PrintIntroudction printIntroudction = new PrintIntroudction(showIntroudction);
            printIntroudction("Sunu", "30");
        }

        /// <summary>
        /// http://www.c-sharpcorner.com/uploadfile/puranindia/static-in-C-Sharp/
        /// http://www.c-sharpcorner.com/UploadFile/1ce252/static-variables-and-static-methods-in-C-Sharp/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Static_Click(object sender, EventArgs e)
        {
            var staticProp = Employee.MyProperty;
            var nonStaticProp = new Employee().MyProperty2;
        }

        public class Employee
        {
            public static int MyProperty { get; set; } = 2;

            public int MyProperty2 { get; set; }
        }
        /// <summary>
        /// Anonymous method can be defined using the delegate keyword
        ///Anonymous method must be assigned to a delegate.
        ///Anonymous method can access outer variables or functions.        
        /// Anonymous method can be passed as a parameter.
        /// Anonymous method can be used as event handlers.
        /// </summary>
        delegate void ShowMessage();
        private void anonymousMethod_Click(object sender, EventArgs e)
        {
            ShowMessage showMessage = delegate ()
            {
                MessageBox.Show("Hello!");
            };
            showMessage();

        }
        /// ------------------------------------------------------------
        private void generics_Click(object sender, EventArgs e)
        {
            GenericMathClass<int> genericMathClass_Int = new GenericMathClass<int>();
            var sumInt = genericMathClass_Int.Add(10, 20);

            //List<GenericMathClass<string>> list = new List<GenericMathClass<string>>();
            //list.Add(new GenericMathClass<string>());

            GenericMathClass<string> genericMathClass_String = new GenericMathClass<string>();
            var sumString = genericMathClass_String.Add("Hai ", "How are you ?");
        }
        /// ------------------------------------------------------------
        private void nullable_Click(object sender, EventArgs e)
        {
            Nullable<int> intNullable = 0; // Same as int? intNullable = 0
            var intI = intNullable ?? 0;
        }

        /// ------------------------------------------------------------
        private void refOut_Click(object sender, EventArgs e)
        {
            int numberInt = 1;      // initializing value is mandatory
            DisplayInteger(ref numberInt);  // ref invoking

            double numberDecimal;   // initializing value is NOT mandatory
            DisplayDouble(out numberDecimal);   //out invoke

            DisplayInteger(1);      // method overloading
        }

        /// <summary>
        /// method overloading can be possible when one method takes a ref or out argument and the other takes the same argument without ref or out.
        /// methods cannot be overloaded if one method takes an argument as ref and the other takes an argument as an out
        /// http://www.c-sharpcorner.com/UploadFile/ff2f08/ref-vs-out-keywords-in-C-Sharp/
        /// </summary>
        /// <param name="number"></param>
        void DisplayInteger(int number)
        {
            MessageBox.Show(number.ToString());
        }

        void DisplayInteger(ref int number)
        {
            MessageBox.Show(number.ToString());
        }

        void DisplayDouble(out double number)
        {
            number = 1.1;
            MessageBox.Show(number.ToString());
        }
        /// ------------------------------------------------------------

        /// <summary>
        /// Func is built-in generic delegate type.
        ///   Func delegate type must return a value.
        ///     Func delegate type can have zero to 16 input parameters.
        ///    Func delegate type can be used with an anonymous method or lambda expression.
        /// http://www.tutorialsteacher.com/csharp/csharp-func-delegate
        /// </summary>

        private void func_Click(object sender, EventArgs e)
        {
            Func<int, int, int> findSum = addNumbers; // invoking function addNumbers with 2 input parameters and 1 output parameter
            int result = findSum(10, 20);

            Func<string> msg = showMessage; // must include one out parameter for result

            // anonymous function using delegate and FUNC
            Func<string, string> getMessage = delegate (string message)
             {
                 return message;
             };
            getMessage("Hello world!");

            // FUNC with lamda expresions
            Func<string> getMsg = () => "Hello";
            var resMessage = getMsg();

            Func<int, int, int> getSum = (int num1, int num2) => num1 + num2;
            var sum = getSum(1, 2);


        }

        string showMessage() => "Hai";


        /// ------------------------------------------------------------

        /// <summary>
        /// Action is also a delegate type defined in the System namespace. 
        /// An Action type delegate is the same as Func delegate except that the Action delegate doesn't return a value. 
        /// Action type delegate can be used without any parameters
        /// In other words, an Action delegate can be used with a method that has a void return type.
        /// http://www.tutorialsteacher.com/csharp/csharp-action-delegate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void action_Click(object sender, EventArgs e)
        {
            Action<string> getMessage = showStaticMessage; // Invoke void method with parameter
            getMessage("Hai..How are you ?");

            Action showMsg = displayMessage;    // Invoke method without parameter/return value
            showMsg();

            Action disMessage = () => MessageBox.Show("Welcome");   // Invoke method with parameter and without return value
            disMessage();

            Action<int, int> getSum = (int num1, int num2) => MessageBox.Show($"{ num1 + num2}");   //Invoke method with parameters 
            getSum(10, 40);
        }

        void showStaticMessage(string message) => MessageBox.Show(message);
        void displayMessage() => MessageBox.Show("Hai");

        /// ------------------------------------------------------------
        /// http://blog.stephencleary.com/2012/02/async-and-await.html
        /// https://msdn.microsoft.com/en-gb/library/mt674882.aspx
        /// http://www.c-sharpcorner.com/UploadFile/dacca2/asynchronous-programming-in-C-Sharp-5-0-part-1-understand-async/
        /// https://www.codeproject.com/Tips/591586/Asynchronous-Programming-in-Csharp-using-async
        /// 
        private void async_Click(object sender, EventArgs e)
        {
            CallProcess();
            this.asyncListView.Items.Add("Program finish");
        }
        public static Task LongProcess()
        {
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);
            });
        }

        public async void CallProcess()
        {
            await LongProcess();    //while using await, the execution control will come back immediately and there will be no impact on the responsiveness of your application.
            this.asyncListView.Items.Add("Long Process finish");

        }

        /// <summary>
        /// https://www.infoq.com/articles/Tasks-Async-Await
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readFileAsync_Click(object sender, EventArgs e)
        {
            var read1 = ReadFileAsync(@"D:\Projects\Sample\CSharpconcepts\CSharpconcepts\Content\Email-Screen-1.png");
            var read2 = ReadFileAsync(@"D:\Projects\Sample\CSharpconcepts\CSharpconcepts\Content\Email-Screen-2.png");

            Task.WhenAll(read1, read2).ContinueWith(task
                =>
                MessageBox.Show("All files have been read successfully.")
                );
        }
        private static Task<int> ReadFileAsync(string filePath)
        {
            var fs = File.OpenRead(filePath);
            var readBuffer = new byte[fs.Length];
            var readTask = fs.ReadAsync(readBuffer, 0, (int)fs.Length);
            readTask.ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    MessageBox.Show($"Read {task.Result} bytes successfully from file {filePath}");
                else
                    MessageBox.Show($"Exception occurred while reading file {filePath}.");

                fs.Dispose();
            });

            return readTask;
        }

        private void dependencyInjection_Click(object sender, EventArgs e)
        {
            // Constructor Injection
            new Client_ConstructorInjection(new BankingService()).Start();
            new Client_ConstructorInjection(new FinancialService()).Start();

            // Property Injection
            var client_PropertyInjection_BankingService = new Client_PropertyInjection();
            client_PropertyInjection_BankingService.Service = new BankingService();
            client_PropertyInjection_BankingService.Start();

            var client_PropertyInjection_FinancialService = new Client_PropertyInjection();
            client_PropertyInjection_FinancialService.Service = new FinancialService();
            client_PropertyInjection_FinancialService.Start();

            // Method Injection
            new Client_MethodInjection().Start(new BankingService());
            new Client_MethodInjection().Start(new FinancialService());
        }

        private void abstractFactory_Click(object sender, EventArgs e)
        {
            // TextStudyMaterial
            //  - QuestionBank
            //      - MultipleChoice
            //      - TrueOrFalse
            //  - Note
            //      - PDF
            //      - HTML
            //MultimediaStudyMaterial
            //  - Video
            //      - File
            //      - Youtube
            //  - Audio
            //      - File
            //      - Recording

            // Factory A 
            int InstituteAId = 1;
            InstituteAFactory instituteAFactory = new InstituteAFactory();
            MessageBox.Show(instituteAFactory.GetAudio(InstituteAId, AudioTypes.Recording).GetName());

            //Factory B
            int InstituteBId = 2;
            InstituteBFactory instituteBFactory = new InstituteBFactory();
            MessageBox.Show(instituteBFactory.GetQuestionBank(InstituteBId, QuestionTypes.TrueOrFalse).GetName());
        }

        private void factoryMethod_Click(object sender, EventArgs e)
        {

        }

        private void CSharp5_Load(object sender, EventArgs e)
        {

        }
    }

    #region Abstract Factory

    public interface ITextStudyMaterial
    {
        string GetName();
    }

    public interface IMultimediaStudyMaterial
    {
        string GetName();
    }

    public class StudyNote : ITextStudyMaterial
    {
        StudyNoteTypes _studyNoteType;
        string name = "No Study Note";

        public StudyNote(StudyNoteTypes studyNoteType)
        {
            _studyNoteType = studyNoteType;
        }

        public string GetName()
        {
            if (_studyNoteType == StudyNoteTypes.HTML)
                name = "HTML";
            else if (_studyNoteType == StudyNoteTypes.PDF)
                name = "PDF";
            return name;
        }

    }

    public class QuestionBank : ITextStudyMaterial
    {
        QuestionTypes _questionType;
        string name = "No Question";

        public QuestionBank(QuestionTypes questionType)
        {
            _questionType = questionType;
        }

        public string GetName()
        {
            if (_questionType == QuestionTypes.MultipleChoice)
                name = "MultipleChoice";
            else if (_questionType == QuestionTypes.TrueOrFalse)
                name = "TrueOrFalse";
            return name;

        }
    }

    public class Video : IMultimediaStudyMaterial
    {
        VideoTypes _videoType;
        string name = "No Video";
        public Video(VideoTypes videoType)
        {
            _videoType = videoType;
        }
        public string GetName()
        {
            if (_videoType == VideoTypes.MPGFile)
            {
                name = "MPGFile";
            }
            else if (_videoType == VideoTypes.Youtube)
            {
                name = "Youtube";
            }
            return name;
        }
    }

    public class Audio : IMultimediaStudyMaterial
    {
        AudioTypes _audioType;
        string name = "No Audio";
        public Audio(AudioTypes audioType)
        {
            _audioType = audioType;
        }
        public string GetName()
        {
            if (_audioType == AudioTypes.MP3File)
                name = "MP3";
            else if (_audioType == AudioTypes.Recording)
                name = "Recording";
            return name;
        }
    }

    public enum Institutes
    {
        InstitutesA,
        InstitutesB
    }

    public enum QuestionTypes
    {
        MultipleChoice,
        TrueOrFalse
    }

    public enum StudyNoteTypes
    {
        PDF,
        HTML
    }

    public enum VideoTypes
    {
        MPGFile,
        Youtube
    }

    public enum AudioTypes
    {
        MP3File,
        Recording
    }

    interface ILearingObjectFactory_ForInstitute_A
    {
        ITextStudyMaterial GetStudyNote(int Id, StudyNoteTypes studyNoteTypes);

        ITextStudyMaterial GetQuestionBank(int Id, QuestionTypes questionTypes);

        IMultimediaStudyMaterial GetVideo(int Id, VideoTypes videoTypes);

        IMultimediaStudyMaterial GetAudio(int Id, AudioTypes audioTypes);
    }

    interface ILearingObjectFactory_ForInstitute_B
    {

        ITextStudyMaterial GetQuestionBank(int Id, QuestionTypes questionTypes);

        IMultimediaStudyMaterial GetVideo(int Id, VideoTypes videoTypes);

    }

    public class InstituteAFactory : ILearingObjectFactory_ForInstitute_A
    {
        public IMultimediaStudyMaterial GetAudio(int Id, AudioTypes audioType)
        {
            return new Audio(audioType);
        }

        public ITextStudyMaterial GetQuestionBank(int Id, QuestionTypes questionType)
        {
            return new QuestionBank(questionType);
        }

        public ITextStudyMaterial GetStudyNote(int Id, StudyNoteTypes studyNoteType)
        {
            return new StudyNote(studyNoteType);
        }

        public IMultimediaStudyMaterial GetVideo(int Id, VideoTypes videoType)
        {
            return new Video(videoType);
        }
    }

    public class InstituteBFactory : ILearingObjectFactory_ForInstitute_B
    {
        public ITextStudyMaterial GetQuestionBank(int Id, QuestionTypes questionType)
        {
            return new QuestionBank(questionType);
        }

        public IMultimediaStudyMaterial GetVideo(int Id, VideoTypes videoType)
        {
            return new Video(videoType);
        }
    }

    #endregion

    #region Factory Method

    public abstract class LearningMaterial
    {

    }

    public class Question : LearningMaterial
    {

    }

    public class Quiz : LearningMaterial
    {

    }


    #endregion

    public class GenericClass1<T, U, V> where T : U
    {
    }

    public class GenericClass2<T, U, V> where U : struct
        where T : new()
    {
    }


    public class GenericMathClass<T>
    {
        // private T genericVariable;

        //public GenericClass(T value)
        //{
        //    genericVariable = value;
        //}
        void AddWithConstraints<U>(List<U> items) where U : T
        {
        }

        public void Add<U>(T num1, T num2) where U : class
        {
        }

        public T Add(T num1, T num2)
        {
            dynamic number1 = num1;
            dynamic number2 = num2;
            if (num1 == null && num2 == null)
                return default(T);      // Use of default keyword
            else
                return number1 + number2;
        }

    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    #region Dependency Injection
    public interface IService
    {
        void Serve();
    }

    public class BankingService : IService
    {
        public void Serve()
        {
            MessageBox.Show("Banking Service");
        }
    }

    public class FinancialService : IService
    {
        public void Serve()
        {
            MessageBox.Show("Financial Service");
        }
    }

    public class Client_ConstructorInjection
    {
        private IService _service;

        public Client_ConstructorInjection(IService service)
        {
            _service = service;
        }

        public void Start()
        {
            _service.Serve();
        }
    }

    public class Client_PropertyInjection
    {
        private IService _service;
        public IService Service
        {
            set
            {
                this._service = value;
            }
        }

        public void Start()
        {
            _service.Serve();
        }
    }

    public class Client_MethodInjection
    {
        private IService _service;

        public void Start(IService service)
        {
            _service = service;
            _service.Serve();
        }
    }

    #endregion
}
