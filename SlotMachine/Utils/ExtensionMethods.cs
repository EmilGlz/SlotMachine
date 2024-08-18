namespace SlotMachine.Utils
{
    internal static class ExtensionMethods
    {
        public static bool StartsWith(this List<int> list, IEnumerable<int> sequence)
        {
            if (list == null || sequence == null)
                return false;

            var enumerator = sequence.GetEnumerator();
            foreach (var item in list)
            {
                if (!enumerator.MoveNext())
                    return true;

                if (!item.Equals(enumerator.Current))
                    return false; 
            }

            return !enumerator.MoveNext();
        }
    }
}
