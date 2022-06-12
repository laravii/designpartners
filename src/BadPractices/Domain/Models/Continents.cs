namespace BadPractices.Domain.Models
{
    public struct CountriesPerContinent
    {
        public IEnumerable<string> OceanCountries { get; private set; }
        public IEnumerable<string> EuropeCountries { get; private set; }
        public IEnumerable<string> AsiaticsCountries { get; private set; }
        public IEnumerable<string> Africanountries { get; private set; }
        public IEnumerable<string> AmericanCountries { get; private set; }
        public IEnumerable<string> AntarticCountries { get; private set; }

        public CountriesPerContinent()
        {
            OceanCountries = new string[] { "Portugal", "Espanha", "Itália", "Alemanha", "Áustria", "França" };
            EuropeCountries = new string[] { "Albânia", "França", "Polônia", "Alemanha", "Geórgia", "Portugal" };
            AsiaticsCountries = new string[] { "Afeganistão", "Emirados Árabes Unidos", "Mianmar", "Arábia Saudita", "Filipinas", "Nepal" };
            Africanountries = new string[] { "África do Sul", "Gâmbia", "Quênia", "Angola", "Gana", "República Centro-Africana" };
            AmericanCountries = new string[] { "Canadá", "Guatemala", "Brasil", "Estados Unidos", "Haiti", "Chile" };
            AntarticCountries = new string[] { "Austrália", "Kiribati", "Samoa", "Estados Federados da Micronésia", "Nauru", "Tonga" };
        }
    }
}