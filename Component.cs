using System;
using System.Globalization;
using System.Threading.Tasks;

namespace dagtasks
{
  class Component
  {
    readonly int m_id;
    readonly int[] m_parents;
    public Component(int id, params int[] parents)
    {
      m_id = id;
      m_parents = parents;
    }
    public async Task<string> SolveAsync(Graph graph)
    {
      const int duration = 1000;
      var start = DateTime.Now;
      string rc = m_id.ToString(CultureInfo.InvariantCulture);
      for (int i = 0; i < m_parents.Length; i++)
      {
        var parent_task = graph.GetTask(m_parents[i]);
        rc += "=>" + await parent_task;
      }

      System.Threading.Thread.Sleep(duration);
      var span = DateTime.Now - start;
      Console.WriteLine("solved {0}, {1}, {2}", m_id, rc, span.TotalSeconds);
      return rc;
    }
  }
}
