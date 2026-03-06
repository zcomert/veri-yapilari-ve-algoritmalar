using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSProblem
{
    public class MiniOS
    {
        private List<PCB> ptable;
        private List<int> ready;
        private List<int> blocked;

        private int runningPid = -1;

        public MiniOS()
        {
            ptable = new List<PCB>();
            ready = new List<int>();
            blocked = new List<int>();
        }

        private PCB GetPCB(int pid) =>
            ptable.Find(p => p.Pid.Equals(pid));

        private bool Exist(int pid) =>
            GetPCB(pid) != null ? true : false;

        private bool RemovePid(List<int> arr, int pid)
        {
            if (arr.Count == 0) return false;

            var pcb = GetPCB(pid);
            arr.Remove(pcb.Pid);
            return true;
        }

        private bool PickHighestPriorityFromReady(out int bestPid)
        {
            bestPid = -1;
            if (ready.Count == 0) return false;
            bestPid = ready[0];
            for (int i = 1; i < ready.Count; i++)
            {
                var candPid = ready[i];
                var candPr = GetPCB(candPid).Priority;
                var bestPr = GetPCB(bestPid).Priority;
                if (candPid < bestPid || candPr > bestPr)
                {
                    bestPid = candPid;
                }
            }
            return true;
        }

        public void Create(int pid, int priority)
        {
            if (Exist(pid))
            {
                Console.WriteLine("This PID exist in the OS!");
                return;
            }

            var newPCB = new PCB()
            {
                Pid = pid,
                Priority = priority,
                State = ProcState.Ready
            };

            ready.Add(pid);
            ptable.Add(newPCB);
            Console.WriteLine($"[Create] PID {pid} is created (pr={priority})!");
        }

        public void Dispatch()
        {
            if (runningPid != -1)
            {
                Console.WriteLine($"CPU is busy, PID {runningPid} is running!");
                return;
            }

            var state = PickHighestPriorityFromReady(out runningPid);

            if (!state)
            {
                Console.WriteLine("[Dispatch] Failed!");
                return;
            }

            Console.WriteLine($"[Dispatch] Running PID {runningPid}");
            GetPCB(runningPid).State = ProcState.Running;
            RemovePid(ready, runningPid);
        }

        public void PrintState()
        {
            Console.WriteLine("----- State -----");
            var state = runningPid == -1 ? "None" : runningPid.ToString();
            Console.WriteLine($"Running: {state}");
            foreach (var item in ready)
            {
                Console.Write($"{item}, ");
            }
            foreach (var item in blocked)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine("\n-----------------");
        }
    }
}
