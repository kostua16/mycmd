using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskCommander;

namespace mycmd
{
    [Task(Name = "ruby", Description = "runs ruby code")]
    class RubyRuner:ITask
    {
        public Prompt Run(IDictionary<string, string> args, IConsole console)
        {
            /*foreach (var arg in args)
            {
                console.Write(arg.Key);
                console.WriteLine(":"+arg.Value);
            }
             */
            var ruby = IronRuby.Ruby.CreateEngine();
            try
            {
                ruby.Execute(args.ElementAtOrDefault(0).Value);
            }
            catch (Exception)
            {
            }
            return Prompt.Continue;
        }
    }
}
