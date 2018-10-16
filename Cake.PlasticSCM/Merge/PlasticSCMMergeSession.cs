using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cake.PlasticSCM.Merge
{
    public class PlasticSCMMergeSession : IDisposable
    {
        private bool _disposed;
        public string SolvedConflictsFilePath { get; }
        public string MergeResultFile { get; }

        /// <inheritdoc />
        public PlasticSCMMergeSession()
        {
            SolvedConflictsFilePath = Path.GetTempFileName();
            MergeResultFile = Path.GetTempFileName();
            DeleteFiles();
        }

        private void DeleteFiles()
        {
            if (File.Exists(SolvedConflictsFilePath))
                File.Delete(SolvedConflictsFilePath);

            if (File.Exists(MergeResultFile))
                File.Delete(MergeResultFile);

        }

        #region IDisposable

        /// <inheritdoc />
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                DeleteFiles();
            }
        }

        #endregion
    }

}
