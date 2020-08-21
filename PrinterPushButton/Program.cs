using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrinterPushButton
{
    delegate void PushPrinterButton();

    class Program
    {
        static void Main(string[] args)
        {
            PrintButton printButton = new PrintButton();
            printButton.Click += new PushPrinterButton(StartPrint.OnPrintClick);

            Console.WriteLine("Please insert your text:");
            while (true)
            {
                string temp = Console.ReadLine();

                if (temp != "")
                {
                    StartPrint.text += temp + "\n";
                    continue;
                }
                break;
            }
            Console.WriteLine("Text has been saved. Please press on print button to Print text");

            while (true)
            {
                if (string.Equals(Console.ReadLine(), "p"))
                {
                    printButton.DoEvent();
                    break;
                }
            }

            Console.ReadLine();
        }
    }

    class StartPrint
    {
        public static string text;

        public static void OnPrintClick()
        {
            Console.WriteLine("Printing...");
            Thread.Sleep(3000);

            Console.WriteLine("Your text:\n" + text);
        }
    }

    class PrintButton 
    {
        public event PushPrinterButton Click;

        public void DoEvent()
        {
            Click?.Invoke();
        }
    }
}
