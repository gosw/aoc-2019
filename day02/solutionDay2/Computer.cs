using System;

namespace csharp.gosw.solutionDay2
{
    public class Computer : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        protected int[] Program { get; private set; }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                Dispose(disposed);
                // Free any other managed objects here.
            }

            disposed = true;
        }

        public Computer Instance (int[] program)
        {
            return new Computer { Program = program };
        }

        public int RunProgram(int noun, int verb)
        {
            Program[1] = noun;
            Program[2] = verb;

            for (int i = 0; i < Program.Length; i += 4)
            {
                switch (Program[i])
                {
                    case 99:
                        break;

                    case 1:
                        Program[Program[i + 3]] = Program[Program[i + 1]] + Program[Program[i + 2]];
                        break;

                    case 2:
                        Program[Program[i + 3]] = Program[Program[i + 1]] * Program[Program[i + 2]];
                        break;

                    default:
                        break;
                }
            }
            return Program[0];
        }
    }
}
