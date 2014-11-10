using System;

namespace dagtasks
{
  class Program
  {
    static void Main()
    {
      var g = new Graph();
      var start = DateTime.Now;
      g.Solve();
      var span = DateTime.Now - start;
      Console.WriteLine("Completed in {0} seconds", span.TotalSeconds);
      Console.WriteLine();
      Console.WriteLine("[press any key to end]");
      Console.ReadKey();
    }
  }
}
