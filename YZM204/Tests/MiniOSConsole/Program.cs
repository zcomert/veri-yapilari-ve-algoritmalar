using OSProblem;

MiniOS oS = new MiniOS();
oS.Create(1, 4);
oS.Create(2, 4);
oS.Create(3, 2);
oS.Create(2, 2);
oS.PrintState();
oS.Dispatch();
oS.PrintState();
oS.Dispatch();