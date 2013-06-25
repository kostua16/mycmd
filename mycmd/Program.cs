using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CmdLine;
using TaskCommander;
using Console = System.Console;

namespace mycmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var atexit = false;
            //var helper = new ScriptHelper();
            //var ruby = IronRuby.Ruby.CreateEngine();
            var r=new Runner();
            r.Run();
            /*
            try
            {
                var args1 = CommandLine.Parse<SimpleArgs>();
            }
            catch (CommandLineException exception)
            {
                Console.WriteLine(exception.ArgumentHelp.Message);
                Console.WriteLine(exception.ArgumentHelp.GetHelpText(Console.BufferWidth));
            }
            
            while (!atexit)
            {
                
                Console.Write("cmd>");
                var cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "exit":
                        atexit = true;
                        break;
                    case "runrb":break;
                    case "set":
                        Console.Write("Name:");var n = Console.ReadLine();
                        Console.Write("Value:");var v = Console.ReadLine();
                        var el=helper.System.Load<DbSetting>("Settings/" + n);
                        if (el == null)
                        {
                            helper.System.Store(new DbSetting { Name = n, Value = v });
                        }
                        else
                        {
                            el.Value = v;
                        }
                        helper.System.SaveChanges();
                        break;
                    case "get":
                        Console.Write("Name:");var n1 = Console.ReadLine();
                        var el1 = helper.System.Load<DbSetting>("Settings/" + n1);
                        if (el1 != null)
                        {
                            Console.WriteLine(el1.Name+":");
                            Console.WriteLine(el1.Value);
                        }
                        else
                        {
                            Console.WriteLine("Not exists!");
                        }
                        break;
                    default:
                        var scr = helper.System.Load<DbScript>("Scripts/" + cmd);
                        if (scr != null)
                        {
                            var scope = ruby.CreateScope();
                            ruby.Execute(scr.Value, scope);
                        }
                        
                        break;
                }
            }
             * */
        }
    }
}
