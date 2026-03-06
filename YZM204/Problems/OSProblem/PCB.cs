using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSProblem
{
    // Process Control Block
    public class PCB
    {
        public int Pid { get; set; }
        // Highest
        public int Priority { get; set; }
        public ProcState State { get; set; }

        public override string ToString()
        {
            return $"PID={Pid}, Pr= {Priority}, State={State}";
        }
    }
}
