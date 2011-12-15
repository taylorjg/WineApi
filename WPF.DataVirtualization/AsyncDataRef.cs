using System;
using System.Threading;

namespace WPF.DataVirtualization
{
    public class AsyncDataRef<TId, T> : DataRefBase<T> where T : class
    {
        private readonly TId m_Id;
        private int m_Loading;
        private readonly Func<TId, T> Load;
        private volatile T m_Data;

        public AsyncDataRef(TId id, Func<TId, T> load)
        {
            m_Id = id;
            Load = load;
        }

        public override T Data
        {
            get
            {
                if (m_Data != null)
                    return m_Data;
                if (Interlocked.Increment(ref m_Loading) == 1)
                    if (m_Data == null)
                        Load.BeginInvoke(m_Id, AsyncLoadCallback, null);
                    else
                        Interlocked.Decrement(ref m_Loading);
                else
                    Interlocked.Decrement(ref m_Loading);
                return m_Data;
            }
        }


        private void AsyncLoadCallback(IAsyncResult ar)
        {
            m_Data = Load.EndInvoke(ar);
            Interlocked.Decrement(ref m_Loading);
            // when the object is loaded, signal that all the properties have changed
            NotifyAllPropertiesChanged();
        }
    }
}
