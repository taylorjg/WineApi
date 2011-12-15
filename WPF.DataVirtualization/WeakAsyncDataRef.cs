using System;
using System.Threading;

namespace WPF.DataVirtualization
{
    public class WeakAsyncDataRef<TId,TData>: DataRefBase<TData> where TData: class
    {
        private readonly TId m_Id;
        private int m_Loading;
        private readonly Func<TId, TData> Load;
        private readonly WeakReference m_Data = new WeakReference(null);
        
        public WeakAsyncDataRef(TId id, Func<TId,TData> load)
        {
            m_Id = id;
            Load = load;
        }

        public override TData Data
        {
            get
            {
                TData data = (TData)m_Data.Target;
                if (data != null)
                    return data;
                if (Interlocked.Increment(ref m_Loading) == 1)
                {
                    data = (TData)m_Data.Target;
                    if (data != null)
                    {
                        Interlocked.Decrement(ref m_Loading);
                        return data;
                    }
                    Load.BeginInvoke(m_Id, AsyncLoadCallback, null);
                }
                else
                    Interlocked.Decrement(ref m_Loading);
                return data;
            }
        }


        private void AsyncLoadCallback(IAsyncResult ar)
        {
            m_Data.Target = Load.EndInvoke(ar);
            Interlocked.Decrement(ref m_Loading);
            NotifyAllPropertiesChanged();
        }
    }
}
