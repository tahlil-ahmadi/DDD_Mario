using System.Collections.Concurrent;

namespace PartyManagement.Domain.Model.Parties.States
{
    public static class PartyStateFactory
    {
        private static ConcurrentDictionary<string, PartyState> _cachedValues = new ConcurrentDictionary<string, PartyState>();
        public static PartyState Create<T>() where T : PartyState, new()
        {
            var name = typeof(T).Name;
            if (_cachedValues.ContainsKey(name)) return _cachedValues[name];

            //if you want to avoid instantiating state, use double-checked lock pattern
            var state = new T();
            _cachedValues.TryAdd(name, state);
            return state;
        }
    }
}
