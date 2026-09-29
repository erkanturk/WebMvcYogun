namespace _06_Custom_Helpers.Helpers
{
    public static class StringHelpers
    {
        public static string CapitalizeFirstLetter(string input)
        {
            if(string.IsNullOrWhiteSpace(input)) return input;

            return char.ToUpper(input[0])+input[1..];//input[1..] range operatörü 1. indescten sona kadar olduğu gibi kalsın
            //input.Substring(1) 
        }
        public static string CapitalizeWords(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;
            var words = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(CapitalizeFirstLetter);
            return string.Join(' ', words);

        }
        public static string WordsLength(string input) => $"\"{input}\"uzunluğu:{input.Length}";
    }
}
