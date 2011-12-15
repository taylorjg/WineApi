using System;

namespace WPF.DataVirtualization
{
    public class DataRef<TId, T> : DataRefBase<T> where T : class
    {
        private readonly TId m_Id;
        private T m_Data;

        private readonly Func<TId, T> Load;

        public DataRef(TId id, Func<TId, T> load)
        {
            m_Id = id;
            Load = load;
        }

        public override T Data
        {
            get
            {
                if (m_Data == null)
                    m_Data = Load(m_Id);
                return m_Data;
            }
        }
    }
}
