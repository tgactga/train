using System;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Text;


namespace TrainRemoteControl.utilclass
{
    class Expression
    {

        object instance;
        MethodInfo method;

        /// <summary>
        /// 表达式的中的计算符号要显示
        /// </summary>
        /// <param name="expression"></param>
        public Expression(string expression)
        {
            if (expression != "")
            {
                if (expression.IndexOf("return") < 0) expression = "return " + expression + ";";
                string className = "Expression";
                string methodName = "Compute";
                CompilerParameters p = new CompilerParameters();
                p.GenerateInMemory = true;
                CompilerResults cr = new CSharpCodeProvider().CompileAssemblyFromSource(p, string.
                  Format("using System;sealed class {0}{{public double {1}(double x,double u){{{2}}}}}",
                  className, methodName, expression));
                if (cr.Errors.Count > 0)
                {
                    string msg = "Expression(\"" + expression + "\"): \n";
                    foreach (CompilerError err in cr.Errors) msg += err.ToString() + "\n";
                    throw new Exception(msg);
                }
                instance = cr.CompiledAssembly.CreateInstance(className);
                method = instance.GetType().GetMethod(methodName);
            }
        }

        public double Compute(double x, double u)
        {
            return (double)method.Invoke(instance, new object[] { x, u });
        }

    }
}
