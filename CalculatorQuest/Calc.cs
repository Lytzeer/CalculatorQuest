using System;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace CalculatorQuest
{
    class Calc
    {
        private static string[] _signs = new []{"+","-","x","/","%"};
        
        public Calc(){}
        public static string Operator(string ope)
        {
            if (ope == "")
            {
                return "Please enter an operation";
            }
            int nbOperator=0;
            string sign="";
            string oper = "";
            string[] numbers = ope.Split(_signs, StringSplitOptions.RemoveEmptyEntries);
            
            if (ope[0]=='-'){
                sign="-";
                ope=ope.Substring(1);
            }  

            for (int i=0; i<_signs.Length;i++){
                for (int j=0; j<ope.Length;j++){
                    //conditon si c'est une addition ou une soustraction par exemple si c'est -6-6 ou 6--6
                    if(ope[j]=='-'&& sign=="-" && (ope[j-1]!= 'x' || ope[j-1]=='/')){
                        nbOperator++;
                        ope= ope.Replace("-","+");
                        oper="+";
                        j+=2;
                    }else if (ope[j] == _signs[i][0] && ope[j + 1] == '-')
                    {
                        oper = _signs[i];
                        nbOperator=1;
                        sign += "-";
                        ope = ope.Substring(0, j + 1)+ope.Substring(j+2);
                        j+=2;
                    }else if (ope[j]==_signs[i][0]){
                        nbOperator++;
                        oper=_signs[i];
                    }
                }
            }

            if (nbOperator!=1 || numbers.Length!=2){
                return "Only one operation please";
            }
            else
            {
                float rep=0;
                if (sign == "-" && oper == "+")
                {
                    //sign = "";
                    rep = float.Parse(numbers[1]) + float.Parse(numbers[0]);
                }else if (oper=="+"){
                    rep= float.Parse(numbers[0])+float.Parse(numbers[1]);
                }else if (oper=="-"){
                    rep= float.Parse(numbers[0])-float.Parse(numbers[1]);
                }else if (oper=="x"){
                    rep= float.Parse(numbers[0])*float.Parse(numbers[1]);
                }else if (oper=="/"){
                    if (float.Parse(numbers[1])==0){
                        return "Division by 0 is IMPOSSIBLE";
                    }else{
                        rep= float.Parse(numbers[0])/float.Parse(numbers[1]);
                    }
                }else if(oper =="%"){
                    if (float.Parse(numbers[1])==0){
                        return "Modulo by 0 is IMPOSSIBLE";
                    }else{
                        rep= float.Parse(numbers[0])%float.Parse(numbers[1]);
                    }
                }

                if (sign.Length % 2 == 0)
                {
                    return rep.ToString();
                }
                return sign+rep.ToString();
            }
        }

        public static string Sqrt(string ope)
        {
            if (ope == "" || ope=="Please enter an operation" || ope=="Only one operation please"){ return "Please enter an operation"; }
            if (float.Parse(ope) >= 0) { return Math.Sqrt(float.Parse(ope)).ToString(); }
            return "No sqrt for negative number";
        }

        public static string Square(string ope)
        {
            if (ope == "" || ope=="Please enter an operation" || ope=="Only one operation please") { return "Please enter an operation"; }
            return Math.Pow(double.Parse(ope), 2).ToString();
        }

        public static string Invert(string ope)
        {
            if (ope == "" || ope=="Please enter an operation" || ope=="Only one operation please") { return "Please enter an operation"; }
            return (1 / double.Parse(ope)).ToString();
        }
    }
}

