using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace calculator
{
    class MainWindow : Window
    {
        //[UI] private Label _label1 = null;
        //[UI] private Button _button1 = null;

        private int _counter;


        public MainWindow() : base(new Builder("MainWindow.glade").GetRawOwnedObject("MainWindow"))
        {
            DeleteEvent += Window_DeleteEvent;
            //_button1.Clicked += Button1_Clicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void Button1_Clicked(object sender, EventArgs a)
        {
            _counter++;
            //_label1.Text = "Hello World! This button has been clicked " + _counter + " time(s).";
        }

        private void btnMemoryPop_clicked_cb(object sender, EventArgs e)
        {

        }

        private void btnMemoryPush_clicked_cb(object sender, EventArgs e)
        {
            
        }

        private void btnClear_clicked_cb(object sender, EventArgs e)
        {
            
        }

        private void btn9_clicked_cb(object sender, EventArgs e) {}
        private void btn8_clicked_cb(object sender, EventArgs e) {}
        private void btn7_clicked_cb(object sender, EventArgs e) {}
        private void btn6_clicked_cb(object sender, EventArgs e) {}
        private void btn5_clicked_cb(object sender, EventArgs e) {}
        private void btn4_clicked_cb(object sender, EventArgs e) {}
        private void btn3_clicked_cb(object sender, EventArgs e) {}
        private void btn2_clicked_cb(object sender, EventArgs e) {}
        private void btn1_clicked_cb(object sender, EventArgs e) {}
        private void btn0_clicked_cb(object sender, EventArgs e) {}

        private void btnAdd_clicked_cb(object sender, EventArgs e) {}
        private void btnSubtract_clicked_cb(object sender, EventArgs e) {}
        private void btnMultiply_clicked_cb(object sender, EventArgs e) {}
        private void btnDivide_clicked_cb(object sender, EventArgs e) {}

        private void btnEquals_clicked_cb(object sender, EventArgs e) {}
    }
}
