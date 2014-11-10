using System.Threading.Tasks;

namespace dagtasks
{
  class Graph
  {
    readonly Component[] m_all_components;
    public Graph()
    {
      m_all_components = new Component[20];
      m_all_components[0] = new Component(0, 8, 5);
      m_all_components[1] = new Component(1, 0);
      m_all_components[2] = new Component(2);
      m_all_components[3] = new Component(3);
      m_all_components[4] = new Component(4);
      m_all_components[5] = new Component(5, 8);
      m_all_components[6] = new Component(6, 8, 5);
      m_all_components[7] = new Component(7);
      m_all_components[8] = new Component(8);
      m_all_components[9] = new Component(9, 1);
      m_all_components[10] = new Component(10, 2);
      m_all_components[11] = new Component(11, 2);
      m_all_components[12] = new Component(12, 2);
      m_all_components[13] = new Component(13, 5);
      m_all_components[14] = new Component(14, 5, 2, 7, 8);
      m_all_components[15] = new Component(15);
      m_all_components[16] = new Component(16);
      m_all_components[17] = new Component(17);
      m_all_components[18] = new Component(18, 0, 15);
      m_all_components[19] = new Component(19, 0);
    }

    Task<string>[] m_all_tasks;
    public Task<string> GetTask(int index)
    {
      if (index < 0)
        return null;
      return m_all_tasks[index];
    }
    public void Solve()
    {
      m_all_tasks = new Task<string>[m_all_components.Length];
      for( int i=0; i<m_all_tasks.Length; i++)
      {
        var component = m_all_components[i];
        m_all_tasks[i] = new Task<string>(() => component.SolveAsync(this).Result);
      }

      foreach (var task in m_all_tasks)
        task.Start();

      Task.WaitAll(m_all_tasks);
    }
  }
}
