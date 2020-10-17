using System;

namespace Report.Common
{
    sealed class TempFile : IDisposable
    {
        string _path;
        public TempFile() : this(System.IO.Path.GetTempFileName()) { }

        public TempFile(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("path");
            this._path = path;
        }

        public string Path
        {
            get
            {
                if (_path == null) throw new ObjectDisposedException(GetType().Name);
                return _path;
            }
        }

        ~TempFile() { Dispose(false); }
        public void Dispose() { Dispose(true); }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
            if (_path != null)
            {
                try { System.IO.File.Delete(_path); }
                catch { } // best effort
                _path = null;
            }
        }
    }
}
