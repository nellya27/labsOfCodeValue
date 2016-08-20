using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Jobs {
	static class NativeJob {
		[DllImport("kernel32")]
		public static extern IntPtr CreateJobObject(IntPtr sa, string name);

		[DllImport("kernel32", SetLastError = true)]
		public static extern bool AssignProcessToJobObject(IntPtr hjob, IntPtr hprocess);

		[DllImport("kernel32")]
		public static extern bool CloseHandle(IntPtr h);

		[DllImport("kernel32")]
		public static extern bool TerminateJobObject(IntPtr hjob, uint code);
}

	public class Job:IDisposable
    {
		private IntPtr _hJob;
		private List<Process> _processes;
        private bool _disposed;
        private byte _sizeInByte;

		public Job(string name)
        {
            _hJob=NativeJob.CreateJobObject(IntPtr.Zero, name);
            if(_hJob==IntPtr.Zero)
            {
                throw new InvalidOperationException();
            }
            GC.AddMemoryPressure(10485760);
            _processes = new List<Process>();
		}

		public Job()
			: this(null) {
		}

		protected void AddProcessToJob(IntPtr hProcess) {
			CheckIfDisposed();

			if(!NativeJob.AssignProcessToJobObject(_hJob, hProcess))
				throw new InvalidOperationException("Failed to add process to job");
		}

	    private void CheckIfDisposed()
	    {
	        if(_disposed)
            {
                throw new ObjectDisposedException("disposed");
            }
	    }

        private void AddingMemoryPressure(byte sizeInByte)
        {
            try
            {
                GC.AddMemoryPressure(sizeInByte);
                Console.WriteLine("Job was created");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

        }

	    public void AddProcessToJob(int pid) {
			AddProcessToJob(Process.GetProcessById(pid));
		}

		public void AddProcessToJob(Process proc) {
			Debug.Assert(proc != null);
			AddProcessToJob(proc.Handle);
			_processes.Add(proc);
		}

		public void Kill()
        {
            if(_hJob!=null)
            {
                NativeJob.TerminateJobObject(_hJob,0);
            }

            _hJob = IntPtr.Zero;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    CleanProcess(); 
                }

                FreeResource();
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
         ~Job()
        {
          // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                 Dispose(false);
                 GC.RemoveMemoryPressure(10485760);
                 Console.WriteLine("was released");
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
           
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        private void CleanProcess()
        {
            foreach (Process process in _processes)
            {
                process.Dispose();
            }
        }

        private void FreeResource()
        {
            NativeJob.CloseHandle(_hJob);
            _hJob = IntPtr.Zero;
        }
    }
}
