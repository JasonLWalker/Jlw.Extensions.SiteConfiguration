using System;

namespace Jlw.Extensions.SiteConfiguration
{
    public class SiteConfigurationBaseMember<T>
    {
        public DateTime CacheLastRefresh { get; protected set; } = DateTime.MinValue;
        // ReSharper disable once InconsistentNaming
        protected T _value = default;
        public T Value
        {
            get => CacheExpired ? RefreshFromCache() : _value;
            set
            {
                _value = value;
                CacheLastRefresh = DateTime.Now;
            }
        }

        public virtual bool CacheExpired => _value == null || CacheLastRefresh.Year < 2000 || DateTime.Now > CacheLastRefresh.AddDays(1);

        protected virtual T RefreshFromCache()
        {
            return _value;
        }
    }
}