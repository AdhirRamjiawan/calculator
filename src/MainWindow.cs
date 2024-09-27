using System;
using Gtk;
using static calculator.ICalculator;
using UI = Gtk.Builder.ObjectAttribute;

namespace calculator
{
    class MainWindow : Window
    {
        private ICalculator _calculator;

        [UI] private Entry _answer = null;
        [UI] private Button _btn1, _btn2, _btn3, _btn4, _btn5, _btn6, _btn7, _btn8, _btn9, _btn0 = null;

        [UI] private Button _btnAdd, _btnSubtract, _btnMultiply, _btnDivide, _btnEquals = null;

        [UI] private Button _btnClear, _btnMemoryPush, _btnMemoryPop = null;

        public MainWindow() : this(new Builder("MainWindow.glade"))
        {

        }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            _calculator = new Calculator();
            _calculator.SetNumber(0);

            DeleteEvent += Window_DeleteEvent;
            //_button1.Clicked += Button1_Clicked;

            _answer = (Entry)builder.GetObject("txtAnswer");

            _btn0 = (Button)builder.GetObject("btn0");
            _btn1 = (Button)builder.GetObject("btn1");
            _btn2 = (Button)builder.GetObject("btn2");
            _btn3 = (Button)builder.GetObject("btn3");
            _btn4 = (Button)builder.GetObject("btn4");
            _btn5 = (Button)builder.GetObject("btn5");
            _btn6 = (Button)builder.GetObject("btn6");
            _btn7 = (Button)builder.GetObject("btn7");
            _btn8 = (Button)builder.GetObject("btn8");
            _btn9 = (Button)builder.GetObject("btn9");

            _btn0.Clicked += btn0_clicked_cb;
            _btn1.Clicked += btn1_clicked_cb;
            _btn2.Clicked += btn2_clicked_cb;
            _btn3.Clicked += btn3_clicked_cb;
            _btn4.Clicked += btn4_clicked_cb;
            _btn5.Clicked += btn5_clicked_cb;
            _btn6.Clicked += btn6_clicked_cb;
            _btn7.Clicked += btn7_clicked_cb;
            _btn8.Clicked += btn8_clicked_cb;
            _btn9.Clicked += btn9_clicked_cb;

            _btnAdd = (Button)builder.GetObject("btnAdd");
            _btnSubtract = (Button)builder.GetObject("btnSubtract");
            _btnMultiply = (Button)builder.GetObject("btnMultiply");
            _btnDivide = (Button)builder.GetObject("btnDivide");
            _btnEquals = (Button)builder.GetObject("btnEquals");

            _btnAdd.Clicked += btnAdd_clicked_cb;
            _btnSubtract.Clicked += btnSubtract_clicked_cb;
            _btnMultiply.Clicked += btnMultiply_clicked_cb;
            _btnDivide.Clicked += btnDivide_clicked_cb;
            _btnEquals.Clicked += btnEquals_clicked_cb;

            _btnClear = (Button)builder.GetObject("btnClear");
            _btnClear.Clicked += btnClear_clicked_cb;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void btnMemoryPop_clicked_cb(object sender, EventArgs e)
        {

        }

        private void btnMemoryPush_clicked_cb(object sender, EventArgs e)
        {
            
        }

        private void btnClear_clicked_cb(object sender, EventArgs e)
        {
            _calculator.Clear();
            _answer.Text = 0.ToString();
        }

        private void btn9_clicked_cb(object sender, EventArgs e) => SetNumber(9);
        private void btn8_clicked_cb(object sender, EventArgs e) => SetNumber(8);
        private void btn7_clicked_cb(object sender, EventArgs e) => SetNumber(7);
        private void btn6_clicked_cb(object sender, EventArgs e) => SetNumber(6);
        private void btn5_clicked_cb(object sender, EventArgs e) => SetNumber(5);
        private void btn4_clicked_cb(object sender, EventArgs e)  => SetNumber(4);
        private void btn3_clicked_cb(object sender, EventArgs e) => SetNumber(3);
        private void btn2_clicked_cb(object sender, EventArgs e) => SetNumber(2);
        private void btn1_clicked_cb(object sender, EventArgs e) => SetNumber(1);
        private void btn0_clicked_cb(object sender, EventArgs e) => SetNumber(0);

        private void btnAdd_clicked_cb(object sender, EventArgs e) => SetOperation(Operation.Add);

        private void btnSubtract_clicked_cb(object sender, EventArgs e) => SetOperation(Operation.Subtract);
        private void btnMultiply_clicked_cb(object sender, EventArgs e) => SetOperation(Operation.Multiply);
        private void btnDivide_clicked_cb(object sender, EventArgs e)  => SetOperation(Operation.Divide);

        private void btnEquals_clicked_cb(object sender, EventArgs e) 
        {
            _calculator.ApplyOperation();
            _answer.Text = _calculator.GetResult().ToString();
        }

        private void SetNumber(decimal number)
        {
            _calculator.SetNumber(number);
            _answer.Text = number.ToString();
        }

        private void SetOperation(Operation operation)
        {
            _calculator.SetOperation(operation);
            //_answer.Text = _calculator.GetResult().ToString();
        }
        
        // 1 + 1 = 2
    }
}