using System;

namespace WPF.DataVirtualization
{
    public class WeakDataRef<TId, T> : DataRefBase<T> where T : class
    {
        private readonly TId m_Id;
        private readonly WeakReference m_Data = new WeakReference(null);
        private readonly Func<TId, T> Load;

        public WeakDataRef(TId id, Func<TId, T> load)
        {
            m_Id = id;
            Load = load;
        }


        public override T Data
        {
            get
            {
                var data = (T)m_Data.Target;
                if (data == null)
                    m_Data.Target = data = Load(m_Id);
                return data;
            }
        }
    }
}
