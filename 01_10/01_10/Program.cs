using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_10
{
    internal class Program
    {
        // Evaluare expresie
        static string exp = "( 1 + 2 * 3 ) + 6 * / ( 1 + 8 / 4 )"; // 9
        // 1 2 3 * + 6 1 8 4 / + / +
        // 9 
        // TODO: adaugarea altor operatori binari: %, &, |
        // TODO: adaugarea de operatori unari: ++, --
        // TODO: adaugarea de functii cu un singur parametru: sqrt2, sqrt3, sin, cos
        // TODO: adauagarea functii cu mai multi parametri: min, max, pow,  
        static void Main(string[] args)
        {
            // ************** RPN ************
            //Console.WriteLine(Evaluate(exp));
            //Console.WriteLine(EvaluateRPN("1 2 3 * + 6 1 8 4 / + / +"));
            // *******************************

            // TODO: generati secvata LAS de ordin n
            // LAS = Look And Say
            // 1
            // 11
            // 21
            // 1211
            // 111221
            // 312211

            // Game of Life
            // TODO: implememntati Game of Life
        }

        private static int Evaluate(string exp)
        {
            string rpn = ReversePolishNotation("( " + exp + " )");


            return EvaluateRPN(rpn);
        }

        private static int EvaluateRPN(string rpn)
        {
            string[] tokens = rpn.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Stack<int> st = new Stack<int>();
            int opStg, opDr;
            foreach (var item in tokens)
            {
                switch(item)
                {
                    case "+":
                        opDr = st.Pop();
                        opStg = st.Pop();
                        st.Push(opStg + opDr);
                        break;
                    case "-":
                        opDr = st.Pop();
                        opStg = st.Pop();
                        st.Push(opStg - opDr);
                        break;
                    case "*":
                        opDr = st.Pop();
                        opStg = st.Pop();
                        st.Push(opStg * opDr);
                        break;
                    case "/":
                        opDr = st.Pop();
                        opStg = st.Pop();
                        st.Push(opStg / opDr);
                        break;
                    default:
                        st.Push(int.Parse(item));
                        break;
                }
            }
            return st.Pop();
        }
        static private int Priority(string op)
        {
            int ret = 0;
            switch(op)
            {
                case "+": 
                case "-":
                    ret = 1;
                    break;
                case "*":
                case "/":
                    ret = 2;
                    break;
            }
            return ret;
        }
        private static string ReversePolishNotation(string exp)
        {
            string[] tokens = exp.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string rpn = "";
            Stack<string> st = new Stack<string>();
            foreach (var item in tokens)
            {
                if (item == "(")
                    st.Push(item);
                else if (int.TryParse(item, out _))
                    rpn = rpn + item + " ";
                else if(item == ")")
                {
                    while (st.Peek() != "(")
                        rpn = rpn + st.Pop() + " ";
                    st.Pop();
                }
                else
                {
                    while (st.Peek() != "(" && 
                        Priority(st.Peek()) >= Priority(item))
                           rpn = rpn + st.Pop() + " ";
                    st.Push(item);
                }
            }

            return rpn;
        }
    }
}
